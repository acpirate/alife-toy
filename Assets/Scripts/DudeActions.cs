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
					myProperties.setBehavior(DudeBehavior.Eating);
					//clear his destination and foodtarget
					myProperties.unsetDestination();
					myProperties.setFoodTarget(null);
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
}
