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

	public void HungerChoices() {

	}
}
