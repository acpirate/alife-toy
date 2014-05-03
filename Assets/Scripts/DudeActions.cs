using UnityEngine;
using System.Collections;

public class DudeActions : MonoBehaviour {

	DudeProperties myProperties;
	DudeDecisions myDecisions;
	//unity methods

		// Use this for initialization
	void Awake() {
		myProperties=gameObject.GetComponent<DudeProperties>();
		myDecisions=gameObject.GetComponent<DudeDecisions>();
	}

	//behavior methods
	public void ConsumeMetabolism() {
		myProperties.setMetabolism(
			myProperties.getMetabolism()-
			Parameters.Dude_MetabolismDrainRate);
	}
	
	public void ClaimFood() {
		//find things in eating range
		Collider[] thingsInEatingRange = Physics.OverlapSphere(transform.position,Parameters.Dude_EatingDistance);
		//iterate over list of things in eating range
		foreach (Collider thingInEatingRange in thingsInEatingRange) {
			//if the thing it found is food
			if (thingInEatingRange.gameObject.name=="Banana(Clone)") {
				//if the food isn't already claimed
				if (thingInEatingRange.gameObject.GetComponent<FoodController>().getClaimer()==null) {
					myProperties.setClaimedFood(thingInEatingRange.gameObject);
					myProperties.getClaimedFood().GetComponent<FoodController>().setClaimer(gameObject);
					/*Debug.Log("" +
					          "my corrdinates: " + transform.position +
					          "food coordinates: " + myProperties.getClaimedFood().transform.position
					          );
					Debug.Break();*/
					myProperties.setBehavior(DudeBehavior.Eating);
					//clear his destination and foodtarget
					myProperties.unsetDestination();
					myProperties.setFoodTarget(null);
					//dude stops checking once he claims food
					break;
				}
			}
		}		
	}

	public void IsHungry() {
		myProperties.setStatus(DudeStatus.Hungry);
		myProperties.setBehavior(DudeBehavior.LookingForFood);
	}

	public void NotHungry() {
		myProperties.setStatus(DudeStatus.Normal);
		myProperties.setBehavior(DudeBehavior.Idle);
	}

	public void FindFood() {
		//first start eating any unclaimed food next to dude
		ClaimFood();
		if (myProperties.getClaimedFood()==null) {
			LookForFood();
			//if there isn't food next to dude but there is food in his sight range then start moving towards it
			if (myProperties.getFoodTarget()!=null) {
				myProperties.setBehavior(DudeBehavior.MovingToDestination);
				myProperties.getDestination().setCoordinates(new Vector2(myProperties.getFoodTarget().transform.position.x,
			    	                                                     myProperties.getFoodTarget().transform.position.z));
				myProperties.getDestination().isSet=true;
			}
			//if there isn't food next to dude and there isn't any food in his sight range 
			//and he isn't already going somewhere then he will pick a random spot on the map to move towards
			if (!myProperties.getDestination().isSet) {
				myProperties.getDestination().isSet=true;
				myProperties.getDestination().setCoordinates(new Vector2(Random.Range(0,Parameters.Field_Size)-Parameters.Field_Size/2,
				                                                         Random.Range(0,Parameters.Field_Size)-Parameters.Field_Size/2));
				myProperties.setBehavior(DudeBehavior.MovingToDestination);
			}

		}

	}

	public void LookForFood() {
		//only look for new food if you don't already have a food target
		if (myProperties.getFoodTarget()==null) {
			//find things in eating range
			Collider[] thingsInSightRange = Physics.OverlapSphere(transform.position,Parameters.Dude_SightDistance);
			//iterate over list of things in eating range
			foreach (Collider thingInSightRange in thingsInSightRange) {
				//if the thing it found is food
				if (thingInSightRange.gameObject.name=="Banana(Clone)") {
					//if the food isn't already claimed
					if (thingInSightRange.gameObject.GetComponent<FoodController>().getClaimer()==null) {
						myProperties.setFoodTarget(thingInSightRange.gameObject);
						//dude stops checking once he sees unclaimed food
						break;
					}
				}
			}
		}
	}

	public void MoveToDestination() {
		//move to where dude wants to go
		transform.position=Vector3.MoveTowards(
			transform.position,
			new Vector3(myProperties.getDestination().getCoordinates().x,1,myProperties.getDestination().getCoordinates().y),Parameters.Dude_Speed);
		//after you move check to see if there is any food
		FindFood();
		//if we arrived stop moving
		if (transform.position.x==myProperties.getDestination().getCoordinates().x &&
		    transform.position.z==myProperties.getDestination().getCoordinates().y) {
			myProperties.unsetDestination();
			myProperties.setBehavior(DudeBehavior.Idle);
		}

	}

	public void EatFood() {
		//decrease food nutrition by eating rate
		if (myProperties.getClaimedFood()!=null) myProperties.getClaimedFood().GetComponent<FoodController>().BeEaten(Parameters.Dude_EatingRate);
		//increase metabolism by gain rate
		myProperties.setMetabolism(myProperties.getMetabolism()+Parameters.Dude_EatingGain);
	}

	public void FoodGone() {
		myProperties.setClaimedFood(null);
		myProperties.setBehavior(DudeBehavior.Idle);
	}
}
