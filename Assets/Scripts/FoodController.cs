﻿using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

	float Nutrition = 0;
	GameObject Claimer = null;
	bool showUnitStats=false;

	void Awake() {
		if (gameObject.GetComponent<Attributes>().WhatAmI==ObjectType.FOOD)
			Nutrition=Parameters.Food_StartingNutrition;
		if (gameObject.GetComponent<Attributes>().WhatAmI==ObjectType.CORPSE)
			Nutrition=Parameters.Corpse_StartingNutrition;
	}
	

	// Update is called once per frame
	void FixedUpdate () {
			
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

	public float getNutrition() {
		return Nutrition;
	}

	void NotClaimed() {
		Claimer=null;
	}

	public void BeEaten(int eatIncrement) {
		Nutrition-=eatIncrement;
		if (Nutrition<=0) {
			Claimer.GetComponent<DudeActions>().FoodGone();
			Destroy(gameObject);
		}

	}

	public void FoodGrowth() {
		Nutrition+=Parameters.Food_GrowthRate;
	}

}
