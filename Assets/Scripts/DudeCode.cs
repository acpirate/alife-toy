﻿using UnityEngine;
using System.Collections;


public enum DudeBehavior { Idle, Eating };
public enum DudeStatus { Normal, Hungry };

public class DudeCode : MonoBehaviour {

	int Metabolism=10000;
	int Life=10000;

	DudeBehavior behavior=DudeBehavior.Idle;
	DudeStatus status=DudeStatus.Normal;

	GameObject myFood=null;

	bool showUnitStats=false;
	//monobehavior methods
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//decrease your metabolism level every frame
		Metabolism--;
		//starvation damage
		if (Metabolism<=0) {
			//metabolism can't get below 0
			Metabolism=0;
			Life--;
		}
		//Die at 0 life
		if (Life<=0) Destroy(transform.gameObject);
		//get hungry at less than 9000 metabolism
		if (Metabolism<9000) {
			status=DudeStatus.Hungry;
		}
		if (Metabolism>=9000) {
			status=DudeStatus.Normal;
		}
		// if he is hungry check if there is food near him
		if (status==DudeStatus.Hungry && behavior!=DudeBehavior.Eating) CheckForFood();
		if (behavior==DudeBehavior.Eating) {
			Metabolism+=2;
			if (Metabolism>=10000) {
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
		//Debug.Log("Metabolism: "+Metabolism+" Life: "+Life);
	}

	void DrawHealthBar() {
		//learn how to draw a health bar
		
	}

	void DudeAction(DudeStatus myStatus) {
		if (myStatus==DudeStatus.Hungry) {

		}
	}

	void CheckForFood() {
		//find close things
		Collider[] closeThings = Physics.OverlapSphere(transform.position,10);
		//iterate over list of close things
		foreach (Collider closeThing in closeThings) {
			//if the thing it found is food
			if (closeThing.gameObject.name=="Banana(Clone)") {
				//if the food isn't being eaten
				if (closeThing.gameObject.GetComponent<FoodController>().GetEater()==null) {
					myFood=closeThing.gameObject;
					myFood.GetComponent<FoodController>().SetEater(gameObject);
					behavior=DudeBehavior.Eating;
				}
			}
			//Debug.Log(closeThing.gameObject.name);
		}
	}

	public void FoodGone() {
		myFood=null;
		behavior=DudeBehavior.Idle;
	}



}

