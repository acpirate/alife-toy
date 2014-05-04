using UnityEngine;
using System.Collections;

public class GameControllerCode : MonoBehaviour {

	public static GameObject Dude;
	public static GameObject Food;
	public static GameObject Corpse;

	public static GameObject DudeContainer;
	public static GameObject FoodContainer;
	public static GameObject CorpseContainer;

	int numberOfDudesToSpawn=Parameters.Field_NumberOfDudesToSpawn;
	int numberOfFoodsToSpawn=Parameters.Field_NumberOfFoodsToSpawn;
	int spawnRadius=Parameters.Field_SpawnRadius;

	//monobehaviors

	void Awake() {
		//spawn dudes
		SpawnDudes();
		SpawnFood();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Tab)) MoveCameraToDude();
	
	}

	void OnGUI() {

	}


	// My functions

	void MoveCameraToDude() {
		GameObject DudeTarget=GameObject.Find("Dude(Clone)");
		Camera.main.transform.position=new Vector3(DudeTarget.transform.position.x,Camera.main.transform.position.y,
		                                           DudeTarget.transform.position.z);
	}

	void SpawnDudes() {
		for (int counter=0;counter<numberOfDudesToSpawn;counter++) {
			GameObject tempDude=(GameObject)
				Instantiate(Dude,new Vector3(Random.Range(-spawnRadius,spawnRadius),1,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
			tempDude.transform.parent=DudeContainer.transform;
		}
	}

	void SpawnFood() {
		for (int counter=0;counter<numberOfFoodsToSpawn;counter++) {
			GameObject tempFood=(GameObject)
				Instantiate(Food,new Vector3(Random.Range(-spawnRadius,spawnRadius),1,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
			tempFood.transform.parent=FoodContainer.transform;
		}
	}
}
