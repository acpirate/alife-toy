using UnityEngine;
using System.Collections;

public class DudeController : MonoBehaviour {

	DudeProperties myProperties;
	DudeDecisions myDecisions;
	DudeActions myActions;

	//if this is true show the unit stats
	bool showUnitStats=false;

	//unity methods


	// Use this for initialization
	void Awake() {
		myProperties=gameObject.GetComponent<DudeProperties>();
		myDecisions=gameObject.GetComponent<DudeDecisions>();
		myActions=gameObject.GetComponent<DudeActions>();
	}

	void Start () {
	
	}

	//happens every frame
	void FixedUpdate() {
		//metabolism goes down every turn
		myActions.ConsumeMetabolism();

		switch (myProperties.getBehavior()) {
			case DudeBehavior.Idle :
				IdleBehavior();
			break;

			case DudeBehavior.LookingForFood:
				FoodSearch();
			break;
		}


		//check for hunger
		myDecisions.CheckHungry();

	}

	void OnGUI() {
		if (showUnitStats) ShowUnitStats();
	}

	void OnMouseEnter() {
		showUnitStats=true;
	}
	
	void OnMouseOver() {
		showUnitStats=true;
	}
	
	void OnMouseExit() {
		showUnitStats=false;
	}




	//display methods
	void ShowUnitStats() {
		GUI.Label(new Rect(10,10,1000,100),"Life: "+myProperties.getLife());
		GUI.Label(new Rect(10,30,1000,100),"Metabolism: "+ myProperties.getMetabolism());
		GUI.Label(new Rect(10,50,1000,100),"Status: "+ myProperties.getStatus());
		GUI.Label(new Rect(10,70,1000,100),"Behavior: "+ myProperties.getBehavior());
		//GUI.Label(new Rect(10,90,1000,100),"FoodTarget: "+ foodTarget);
		GUI.Label(new Rect(10,110,1000,100),"Destination: "+ myProperties.getDestination().getCoordinates());
	}

	void IdleBehavior() {
		myDecisions.CheckHungry();
	}

	void FoodSearch() {

	}


}
