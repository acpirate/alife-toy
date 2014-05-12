using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerCode : MonoBehaviour {

	public GameObject TransferDude;
	public GameObject TransferFood;
	public GameObject TransferCorpse;
	public GameObject TransferPredator;

	public GameObject TransferDudeContainer;
	public GameObject TransferFoodContainer;
	public GameObject TransferCorpseContainer;
	public GameObject TransferPredatorContainer;

	static GameObject Dude=null;
	static GameObject Food=null;
	static GameObject Corpse=null;
	static GameObject Predator=null;
	
	static GameObject DudeContainer=null;
	static GameObject FoodContainer=null;
	static GameObject CorpseContainer=null;
	static GameObject PredatorContainer=null;

	static List<Animal> Animals=new List<Animal>();
	static List<Plant> Plants=new List<Plant>();


	int numberOfDudesToSpawn=Parameters.Field_NumberOfDudesToSpawn;
	int numberOfFoodsToSpawn=Parameters.Field_NumberOfFoodsToSpawn;
	int numberOfPredatorsToSpawn=Parameters.Field_NumberOfPredatorsToSpawn;
	int spawnRadius=Parameters.Field_SpawnRadius;

	//monobehaviors

	void Awake() {
		//use transfer method to move editor variables to static objects
		if (Dude==null) Dude=TransferDude;
		if (Food==null) Food=TransferFood;
		if (Corpse==null) Corpse=TransferCorpse;
		if (Predator==null) Predator=TransferPredator;
		
		if (DudeContainer==null) DudeContainer=TransferDudeContainer;
		if (FoodContainer==null) FoodContainer=TransferFoodContainer;
		if (CorpseContainer==null) CorpseContainer=TransferCorpseContainer;
		if (PredatorContainer==null) PredatorContainer=TransferPredatorContainer;

		//initialize Parameters
		Parameters.Initialize();

		//spawn stuff

		SpawnAnimals();
		SpawnPlants();

		//SpawnFood();
		//SpawnPredators();




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
	

	//right now dudes are the only kind of animal
	void SpawnAnimals() {
		//spawn dudes

		//number of dudes is taken from parameters
		for (int counter=0;counter<numberOfDudesToSpawn;counter++) {
			Animal tempAnimal=new Animal(Parameters.Dude_StartingLife,Parameters.Dude_StartingMetabolism,ANIMALTYPE.DUDE);
			Animals.Add(tempAnimal);
			//instantiate the gameobject
			GameObject tempDude=(GameObject)
				Instantiate(Parameters.DudePrefab,
				            WorldControllerCode.GetRandomSpawnLocation(),
				            Quaternion.identity);
			tempDude.transform.parent=DudeContainer.transform;

			tempAnimal.setWorldObject(tempDude);
		}
	}

	void SpawnPlants() {
		//spawn mushrooms
		
		//number of dudes is taken from parameters
		for (int counter=0;counter<numberOfFoodsToSpawn;counter++) {
			Plant tempPlant=new Plant(1,Parameters.Food_StartingNutrition);
			Plants.Add(tempPlant);
			//instantiate the gameobject
			GameObject tempMushroom=(GameObject)
				Instantiate(Parameters.MushroomPrefab,
				            WorldControllerCode.GetRandomSpawnLocation(),
				            Quaternion.identity);
			tempMushroom.transform.parent=FoodContainer.transform;
			
			tempPlant.setWorldObject(tempMushroom);
		}

	}

	void SpawnFood() {
		for (int counter=0;counter<numberOfFoodsToSpawn;counter++) {
			GameObject tempFood=(GameObject)
				Instantiate(Food,new Vector3(Random.Range(-spawnRadius,spawnRadius),1,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
			tempFood.transform.parent=FoodContainer.transform;
		}
	}

	void SpawnPredators() {
		for (int counter=0;counter<numberOfPredatorsToSpawn;counter++) {
			GameObject tempPredator=(GameObject)
				Instantiate(Predator,new Vector3(Random.Range(-spawnRadius,spawnRadius),1.5f,Random.Range(-spawnRadius,spawnRadius)),Quaternion.identity);
			tempPredator.transform.parent=PredatorContainer.transform;
		}
	}

	public static void DudeDeath(GameObject dudeWhoDied) {
		GameObject tempCorpse=(GameObject) Instantiate(
			Corpse, dudeWhoDied.transform.position,dudeWhoDied.transform.rotation);
		Destroy(dudeWhoDied);
		tempCorpse.transform.parent=CorpseContainer.transform;

	}
}
