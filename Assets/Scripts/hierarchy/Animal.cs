using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animal : Creature {

	int metabolism;
	public int maxMetabolism;
	public ANIMALTYPE animalType;
	public int reach;
	public int hungryThreshold;
	public int starvingThreshold;
	public FOODTYPE preferredFood;
	public int metabolismConsumptionRate;
	public int starvationRate;
	public int biteValue;

	BEHAVIORTYPE behavior = BEHAVIORTYPE.IDLE;
	STATUS status = STATUS.NORMAL;

	public override void FixedUpdate() {
		base.FixedUpdate();
		consumeMetabolism();
		checkHunger();

		//do stuff based on the current behavior
		switch (behavior) {
			case BEHAVIORTYPE.IDLE:
				if (status==STATUS.HUNGRY) behavior=BEHAVIORTYPE.LOOKINGFORFOOD;
			break;

			case BEHAVIORTYPE.LOOKINGFORFOOD:
				lookForFood();
			break;

			case BEHAVIORTYPE.EATING:
				biteFood();
			break;

			case BEHAVIORTYPE.HARVESTING:
				harvestFood();
			break;
		}

	}

	public override void Awake() {
		base.Awake();
		metabolism=maxMetabolism;
	}
	
	public int getMetabolism() {
		return metabolism;
	}

	public void setMetabolism(int inMetabolism) {
		metabolism=inMetabolism;
	}

	public void setBehavior(BEHAVIORTYPE inBehavior) {
		behavior=inBehavior;
	}

	void consumeMetabolism() {
		metabolism-=metabolismConsumptionRate;
		if (metabolism<=0) {
			takeStarvationDamage();
			metabolism=0;
		}
	}

	void checkHunger() {
		status=STATUS.NORMAL;

		if (metabolism<hungryThreshold) status=STATUS.HUNGRY;

	}

	void takeStarvationDamage() {
		setLife(getLife()-starvationRate);
	}

	void lookForFood() {
		//first see if we are carrying any food
		foreach (Item item in inventory.getItems()) {
			if (item is Food)  { 
				behavior=BEHAVIORTYPE.EATING;
				break;
			}
		}
		//if no food is found in the invetory then see if we are standing near it
		if (behavior==BEHAVIORTYPE.LOOKINGFORFOOD) {
			List<GameObject> stuffInReach=WorldController.stuffInRadius(transform.position,reach);
			foreach (GameObject inReachThing in stuffInReach) {
				if (inReachThing.GetComponent<Plant>()!=null) {
					if (inReachThing.GetComponent<Plant>().getPlantType()==preferredFood) {
						behavior=BEHAVIORTYPE.HARVESTING;
						break;
					}
				}
			}
		}
		//if no food plant is near then look for it in sight radius



	}

	void biteFood() {
		Food tempFood=null;
		foreach (Item item in inventory.getItems()) {
			if (item is Food) {
				tempFood=(Food) item;
				break;
			}
		}
		//last bite can be too big, fix later
		if (tempFood!=null) {
			tempFood.beEaten(biteValue);
			metabolism+=biteValue;
			if (tempFood.isGone()) inventory.retrieveItem(tempFood);
		}

		behavior=BEHAVIORTYPE.IDLE;

	}

	void harvestFood() {

		List<GameObject> stuffInReach=WorldController.stuffInRadius(transform.position,reach);
		foreach (GameObject inReachThing in stuffInReach) {
			if (inReachThing.GetComponent<Plant>()!=null) {
				if (inReachThing.GetComponent<Plant>().getPlantType()==preferredFood) {
					inventory.putItem(inReachThing.GetComponent<Plant>().harvestFood());
					break;
				}
			}
		}
		behavior=BEHAVIORTYPE.IDLE;

	}


}
