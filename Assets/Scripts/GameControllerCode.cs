using UnityEngine;
using System.Collections;

public class GameControllerCode : MonoBehaviour {

	public GameObject Dude;
	public GameObject Food;

	public int numberOfDudesToSpawn;
	public int numberOfFoodsToSpawn;
	public int spawnRadius;

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
