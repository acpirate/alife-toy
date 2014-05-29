using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldController : MonoBehaviour {

	public int numberOfDudesToSpawn;
	public int numberOfShroomsToSpawn;
	public int numberOfPredatorsToSpawn;
	public int spawnRadius;

	public GameObject DudePrefab;
	public GameObject ShroomPrefab;

	//list of all corpses in the game, kept here so decay can be processed
	List<Corpse> corpseList;

	void Awake() {
	
		spawnDudes();
		spawnShrooms();

	}

	
	// Update is called once per frame
	void FixedUpdate () {
	
	}


	//my functions
	public void addCorpse(Corpse inCorpse) {
		corpseList.Add(inCorpse);
	}


	void decayTimer() {
		//iterate over corpse list and do stuff
	}

	void spawnObject(GameObject objectToSpawn) {
		bool spawnClear=false;

		while (!(spawnClear)) {
			Vector3 tempLocation=getLocationInSpawnRadius();

			spawnClear=isClear(tempLocation);
		}

		Instantiate(objectToSpawn,getLocationInSpawnRadius(),Quaternion.identity);
	}

	Vector3 getLocationInSpawnRadius() {
		int xpos=Random.Range(-spawnRadius,spawnRadius);
		int zpos=Random.Range(-spawnRadius,spawnRadius);

		return new Vector3(xpos, 1, zpos);
	}

	void leaveCorpse(Corpse corpseToLeave, Vector3 corpseLocation) {
		//here is where a corpse would be left when I implement corpses
	}

	//initialization functions
	void spawnDudes() {
		for (int counter=0;counter<numberOfDudesToSpawn;counter++) {
			spawnObject(DudePrefab);
		}
	}

	void spawnShrooms() {
		for (int counter=0;counter<numberOfShroomsToSpawn;counter++) {
			spawnObject(ShroomPrefab);
		}
	}

	bool isClear(Vector3 proposedLocation) {
		bool locationClear=true;
		Collider[] nearColliders = Physics.OverlapSphere(proposedLocation, 5);
		if (nearColliders.Length>0) locationClear=false;

		return locationClear;
	}


}
