using UnityEngine;
using System.Collections;

public class TransferController : MonoBehaviour {

	public GameObject TransferDudePrefab;
	public static GameObject DudePrefab;

	public GameObject TransferMushroomPrefab;
	public static GameObject MushroomPrefab;

	// Use this for initialization
	void Awake () {
		DudePrefab=TransferDudePrefab;
		MushroomPrefab=TransferMushroomPrefab;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
