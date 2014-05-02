using UnityEngine;
using System.Collections;


public enum DudeBehavior { Idle, Eating, LookingForFood };
public enum DudeStatus { Normal, Hungry };

public class DudeCode : MonoBehaviour {

	int Metabolism=Parameters.Dude_StartingMetabolism;
	int Life=Parameters.Dude_StartingLife;

	DudeBehavior behavior=DudeBehavior.Idle;
	DudeStatus status=DudeStatus.Normal;

	GameObject myFood=null;
	GameObject foodTarget=null;
	Vector2 destination=Vector2.zero;


	bool showUnitStats=false;
	//monobehavior methods
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//decrease your metabolism level every frame
		Metabolism-=Parameters.Dude_MetabolismDrainRate;
		//starvation damage
		if (Metabolism<=0) {
			//metabolism can't get below 0
			Metabolism=0;
			Life-=Parameters.Dude_StarvationDamageRate;
		}
		//Die at 0 life
		if (Life<=0) Destroy(transform.gameObject);
		//get hungry at less than hunger threshold
		if (Metabolism<Parameters.Dude_HungerThreshold) {
			status=DudeStatus.Hungry;
		}
		if (Metabolism>=Parameters.Dude_HungerThreshold) {
			status=DudeStatus.Normal;
		}
		// if he is hungry check if there is food near him
		if (status==DudeStatus.Hungry && behavior!=DudeBehavior.Eating) EatNearbyFood();
		// if he is still hungry (there was no food near him) then look for food and move to it
		if (status==DudeStatus.Hungry && myFood==null)  {
			LookForFood();
			MoveToFood();
		}

		// if he is eating then increase his metabolism by the eating gain rate
		if (behavior==DudeBehavior.Eating) {
			Metabolism+=Parameters.Dude_EatingGain;
			if (Metabolism>=Parameters.Dude_StartingMetabolism) {
				if (myFood!=null) {
					myFood.GetComponent<FoodController>().SetEater(null);
					myFood=null;
					behavior=DudeBehavior.Idle;
				}

			}
		}


	}
	
	void OnGUI() {
		DrawHealthBar();

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

	//begin custom functions
	void ShowUnitStats() {
		GUI.Label(new Rect(10,10,1000,100),"Life: "+Life);
		GUI.Label(new Rect(10,30,1000,100),"Metabolism: "+ Metabolism);
		GUI.Label(new Rect(10,50,1000,100),"Status: "+ status);
		GUI.Label(new Rect(10,70,1000,100),"Behavior: "+ behavior);
		GUI.Label(new Rect(10,90,1000,100),"FoodTarget: "+ foodTarget);
		GUI.Label(new Rect(10,110,1000,100),"Destination: "+ destination);
		//Debug.Log("Metabolism: "+Metabolism+" Life: "+Life);
	}

	void DrawHealthBar() {
		//learn how to draw a health bar
		
	}

	void DudeAction(DudeStatus myStatus) {
		if (myStatus==DudeStatus.Hungry) {

		}
	}

	void EatNearbyFood() {
		//find things in eating range
		Collider[] thingsInEatingRange = Physics.OverlapSphere(transform.position,Parameters.Dude_EatingDistance);
		//iterate over list of things in eating range
		foreach (Collider thingInEatingRange in thingsInEatingRange) {
			//if the thing it found is food
			if (thingInEatingRange.gameObject.name=="Banana(Clone)") {
				//if the food isn't being eaten
				if (thingInEatingRange.gameObject.GetComponent<FoodController>().GetEater()==null) {
					myFood=thingInEatingRange.gameObject;
					myFood.GetComponent<FoodController>().SetEater(gameObject);
					behavior=DudeBehavior.Eating;
					//clear his destination and foodtarget
					destination=Vector2.zero;
					foodTarget=null;
				}
			}
		}
	}

	void LookForFood() {
		//if you are going to food, and someone else gets there first, then pick a new target
		if (foodTarget!=null && foodTarget.GetComponent<FoodController>().GetEater()!=null) foodTarget=null;
		//find things in sight range
		Collider[] thingsInSightRange = Physics.OverlapSphere(transform.position,Parameters.Dude_SightDistance);
		//iterate over list of close things
		foreach (Collider thingInSightRange in thingsInSightRange) {
			//if the thing it found is food
			if (thingInSightRange.gameObject.name=="Banana(Clone)") {
				//if the food isn't being eaten
				if (thingInSightRange.gameObject.GetComponent<FoodController>().GetEater()==null) {
					foodTarget=thingInSightRange.gameObject;
				}
			}
		}
	}

	void MoveToFood() {

		//if he arrived but there is no food there the zero out the destination and the target
		if (transform.position.x-destination.x<Parameters.Dude_EatingDistance/2 &&
		    transform.position.y-destination.y<Parameters.Dude_EatingDistance/2) {
			foodTarget=null;
			destination=Vector2.zero;
		}
		//if he doesnt know where he is going then pick a random spot to move to
		if (foodTarget==null && destination==Vector2.zero) destination=new Vector2(Random.Range(0,Parameters.Field_Size)-Parameters.Field_Size/2,
		                                              Random.Range(0,Parameters.Field_Size)-Parameters.Field_Size/2);
		// if he does see food move toward it
		if (foodTarget!=null) destination=new Vector2(foodTarget.transform.position.x,foodTarget.transform.position.z);
	
		if (destination!=Vector2.zero) transform.position=Vector3.MoveTowards(transform.position,new Vector3(destination.x,1,destination.y),Parameters.Dude_Speed);
	}

	public void FoodGone() {
		myFood=null;
		behavior=DudeBehavior.Idle;
	}



}

