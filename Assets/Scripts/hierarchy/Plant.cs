using UnityEngine;
using System.Collections;

public class Plant : Creature {

	int FoodCount=0;
	Food myFood;

	PLANTTYPE myType;

	public Plant(int inLife, int inFoodCount) : 
		base(inLife)
	{
		FoodCount=inFoodCount;
	}

	public void setFood() {

	}



}
