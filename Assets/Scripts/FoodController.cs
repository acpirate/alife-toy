﻿using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

	float Nutrition = Parameters.Food_StartingNutrition;
	GameObject Claimer = null;
	bool showUnitStats=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//lose nutrition if someone is eating it
		if (Claimer!=null) Nutrition-=Parameters.Dude_EatingRate;
		//destroy if it has no nutrition left
		if (Nutrition<=0) { 
			if (Claimer!=null) {
				//Eater.GetComponent<DudeCode>().FoodGone();
			}
			Destroy(transform.gameObject);
		}
	
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
	
	//begin custom functions
	void ShowUnitStats() {
		GUI.Label(new Rect(10,10,1000,100),"Nutrion: "+Nutrition);
		GUI.Label(new Rect(10,30,1000,100),"Claimed By: "+ Claimer);
		//Debug.Log("Metabolism: "+Metabolism+" Life: "+Life);
	}
	public void setClaimer(GameObject claimerToSet) {
		Claimer=claimerToSet;
	}

	public GameObject getClaimer() {
		return Claimer;
	}

	void NotClaimed() {
		Claimer=null;
	}
}
