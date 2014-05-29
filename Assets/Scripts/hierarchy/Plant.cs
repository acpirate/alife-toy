using UnityEngine;
using System.Collections;

public class Plant : Creature {

	public int growthTime;
	public int startingFoodCount;

	int foodCount;
	int growthTimer=0;

	bool growth=true;

	public override void Awake ()
	{
		foodCount=startingFoodCount;
		base.Awake ();
	}

	public override void FixedUpdate ()
	{
		base.FixedUpdate ();
		checkEmpty();
		if (growth) growPlant();
		growth=true;
	}

	public override void OnTriggerStay() {
		growth=false;
	}

	void checkEmpty() {
		//if the plant is fully harvested destroy it
		if (foodCount==0) {
			setLife(0);
		}
	}

	void growPlant() {
		growthTimer++;
		if (growthTimer>=growthTime) {
			growthTimer=0;
			foodCount++;
		}
		float sizeRatio=(float)foodCount/(float)startingFoodCount;
		transform.localScale=new Vector3(sizeRatio,sizeRatio,sizeRatio);

	}


}
