using UnityEngine;
using System.Collections;

public class Parameters {

	//world parameters

	public static readonly int Field_Size=1000; //size of the play field
	public static readonly int Field_SpawnRadius=450; //distance from center objects can spawn
	public static readonly int Field_NumberOfDudesToSpawn=50;
	public static readonly int Field_NumberOfFoodsToSpawn=100;

	//dude parameters

	public static readonly int Dude_StartingLife=1000;
	public static readonly int Dude_StartingMetabolism=1000;
	public static readonly int Dude_HungerThreshold=700; //level below which the dude gets hungry
	public static readonly int Dude_CannibalismThreshold=400;
	public static readonly int Dude_EatingRate=1; //number of nutrition units consumed from food every frame of eating
	public static readonly int Dude_EatingDistance=5; //food within this radius can be claimed and eaten
	public static readonly int Dude_MetabolismDrainRate=1; //number of metabolism units lost every frame
	public static readonly int Dude_EatingGain=3; //number of metabolism units gained every turn of eating
	public static readonly int Dude_StarvationDamageRate=1; //number of life units lost for each frame of starvation
	public static readonly int Dude_SightDistance=50; //how far dudes can see
	public static readonly int Dude_Speed=1; //how fast the dude moves

	//food parameters

	public static readonly int Food_StartingNutrition=600;
	public static readonly float Food_GrowthRate=.5f;

	//corpse parameters

	public static readonly int Corpse_StartingNutrition=500;
}
