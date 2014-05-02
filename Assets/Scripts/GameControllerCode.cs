using UnityEngine;
using System.Collections;

public class GameControllerCode : MonoBehaviour {

	public GameObject Dude;
	public GameObject Food;

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
			Instantiate(Dude,new Vector3(Random.Range(-spawnRadius,spawnRadius),1,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
		}
	}

	void SpawnFood() {
		for (int counter=0;counter<numberOfFoodsToSpawn;counter++) {
			Instantiate(Food,new Vector3(Random.Range(-spawnRadius,spawnRadius),1,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
		}
	}
}
