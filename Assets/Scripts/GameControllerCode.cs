using UnityEngine;
using System.Collections;

public class GameControllerCode : MonoBehaviour {

	public GameObject TransferDude;
	public GameObject TransferFood;
	public GameObject TransferCorpse;

	public GameObject TransferDudeContainer;
	public GameObject TransferFoodContainer;
	public GameObject TransferCorpseContainer;

	static GameObject Dude=null;
	static GameObject Food=null;
	static GameObject Corpse=null;
	
	static GameObject DudeContainer=null;
	static GameObject FoodContainer=null;
	static GameObject CorpseContainer=null;


	int numberOfDudesToSpawn=Parameters.Field_NumberOfDudesToSpawn;
	int numberOfFoodsToSpawn=Parameters.Field_NumberOfFoodsToSpawn;
	int spawnRadius=Parameters.Field_SpawnRadius;

	//monobehaviors

	void Awake() {
		//use transfer method to move editor variables to static objects
		if (Dude==null) Dude=TransferDude;
		if (Food==null) Food=TransferFood;
		if (Corpse==null) Corpse=TransferCorpse;
		
		if (DudeContainer==null) DudeContainer=TransferDudeContainer;
		if (FoodContainer==null) FoodContainer=TransferFoodContainer;
		if (CorpseContainer==null) CorpseContainer=TransferCorpseContainer;


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

	public static void DudeDeath(GameObject dudeWhoDied) {
		GameObject tempCorpse=(GameObject) Instantiate(
			Corpse, dudeWhoDied.transform.position,dudeWhoDied.transform.rotation);
		Destroy(dudeWhoDied);
		tempCorpse.transform.parent=CorpseContainer.transform;

	}
}
