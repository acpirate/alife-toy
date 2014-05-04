using UnityEngine;
using System.Collections;

public class DudeDecisions : MonoBehaviour {

	DudeProperties myProperties;
	DudeActions myActions;

	//initialize
	void Awake() {
		myProperties=gameObject.GetComponent<DudeProperties>();
		myActions=gameObject.GetComponent<DudeActions>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckHungry() {
		myActions.NotHungry();

		//if the metabolism is less than the threshold then set status to hungry
		if (myProperties.getMetabolism()<Parameters.Dude_HungerThreshold) {
			myActions.IsHungry();
		}

	}

	public void CheckFullness() {
		//if dude is full, stop eating
		if (myProperties.getMetabolism()>=Parameters.Dude_StartingMetabolism) {
			myProperties.setMetabolism(Parameters.Dude_StartingMetabolism);
			myProperties.setBehavior(DudeBehavior.Idle);
			//release food when dude is done
			if (myProperties.getClaimedFood()!=null)
				myProperties.getClaimedFood().GetComponent<FoodController>().setClaimer(null);
			myProperties.setClaimedFood(null);
		}
	}

}
