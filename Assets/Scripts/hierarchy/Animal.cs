using UnityEngine;
using System.Collections;

public class Animal : Creature {

	int Metabolism;

	ANIMALTYPE animalType;

	public Animal(int inLife, int inMetabolism, ANIMALTYPE inType) :
		//parent constructure
		base(inLife)
	{
		animalType=inType;

		Metabolism=inMetabolism;
	}

	public int getMetabolism() {
		return Metabolism;
	}

	public void setMetabolism(int inMetabolism) {
		Metabolism=inMetabolism;
	}
}
