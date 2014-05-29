using UnityEngine;
using System.Collections;

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

	BEHAVIORTYPE behavior;


	public override void FixedUpdate() {
		base.FixedUpdate();
		consumeMetabolism();

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

	void takeStarvationDamage() {
		setLife(getLife()-starvationRate);
	}
}
