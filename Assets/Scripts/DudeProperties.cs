using UnityEngine;
using System.Collections;


public enum DudeBehavior { Idle, Eating, LookingForFood, MovingToDestination };
public enum DudeStatus { Normal, Hungry };

public class DudeProperties : MonoBehaviour {

	int Metabolism=Parameters.Dude_StartingMetabolism;
	int Life=Parameters.Dude_StartingLife;
	
	DudeBehavior behavior=DudeBehavior.Idle;
	DudeStatus status=DudeStatus.Normal;
	Destination destination=new Destination();

	GameObject claimedFood=null;
	GameObject foodTarget=null;
	//unity methods

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//my  methods
	public DudeBehavior getBehavior() {
		return behavior;
	}

	public Destination getDestination() {
		return destination;
	}

	public GameObject getClaimedFood() {
		return claimedFood;
	}

	public int getLife() {
		return Life;
	}

	public int getMetabolism() {
		return Metabolism;
	}

	public GameObject getFoodTarget() {
		return foodTarget;
	}

	public DudeStatus getStatus() {
		return status;
	}

	public void setBehavior(DudeBehavior behaviorToSet) {
		behavior=behaviorToSet;
	}

	public void setClaimedFood(GameObject foodToClaim) {
		claimedFood=foodToClaim;
	}

	public void setFoodTarget(GameObject foodTargetToSet) {
		foodTarget=foodTargetToSet;
	}

	public void setMetabolism(int metabolismToSet) {
		Metabolism=metabolismToSet;
	}

	public void setStatus(DudeStatus statusToSet) {
		status=statusToSet;
	}

	public void unsetDestination() {
		destination.isSet=false;
	}
}

public class Destination {

	Vector2 coordinates=Vector2.zero;
	public bool isSet=false;

	//constructor
	public Destination() {

	}
	
	public Vector2 getCoordinates() {
		return coordinates;
	}

	public void setCoordinates(Vector2 inCoordinates) {
		coordinates=inCoordinates;
		isSet=true;
	}
	
	public void Arrived() {
		isSet=false;
	}
}