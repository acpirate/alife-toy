using UnityEngine;
using System.Collections;

public enum FOODTYPE { MUSHROOM_PART, MEAT };

public class Food : Item {

	FOODTYPE myFoodType;
	int nutritionAmount;

	public Food(FOODTYPE inFoodType, int inNutritionAmount) {
		myFoodType=inFoodType;
		nutritionAmount=inNutritionAmount;
	}

	public FOODTYPE getFoodType() {
		return myFoodType;
	}

	public void beEaten(int biteValue) {
		nutritionAmount-=biteValue;
	}

	public bool isGone() {
		bool tempGone=false;
		if (nutritionAmount<=0) tempGone=true;

		return tempGone;
	}

}
