using UnityEngine;
using System.Collections;

public class GrowthController : MonoBehaviour {

	FoodController myFoodController;
	float myScale=1;

	void Awake() {
		myFoodController=gameObject.GetComponent<FoodController>();
	}

	void FixedUpdate() {
		Growth();
		transform.localScale=new Vector3(myScale,myScale,myScale);
	}

	//custom methods

	void Growth() {
		if (myFoodController.getClaimer()==null) {
			myFoodController.FoodGrowth();
			myScale=myFoodController.getNutrition()/Parameters.Food_StartingNutrition;
		}
	}

}
