using UnityEngine;
using System.Collections;

public class Parameters {

	//world parameters

	public static readonly int Field_Size=1000; //size of the play field
	public static readonly int Field_SpawnRadius=450; //distance from center objects can spawn
	public static readonly int Field_NumberOfDudesToSpawn=100;
	public static readonly int Field_NumberOfFoodsToSpawn=100;

	//dude parameters

	public static readonly int Dude_StartingLife=100000;
	public static readonly int Dude_StartingMetabolism=10000;
	public static readonly int Dude_HungerThreshold=9000; //level below which the dude gets hungry
	public static readonly int Dude_EatingRate=1; //number of nutrition units consumed from food every frame of eating
	public static readonly int Dude_EatingDistance=10; //food within this radius can be claimed and eaten
	public static readonly int Dude_MetabolismDrainRate=1; //number of metabolism units lost every frame
	public static readonly int Dude_EatingGain=2; //number of metabolism units gained every turn of eating
	public static readonly int Dude_StarvationDamageRate=1; //number of life units lost for each frame of starvation

	//food parameters

	public static readonly int Food_StartingNutrition=2000;

}
