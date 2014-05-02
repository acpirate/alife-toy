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
	
	}

	void OnGUI() {

	}


	// My functions
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
