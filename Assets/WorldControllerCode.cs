using UnityEngine;
using System.Collections;

public class WorldControllerCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//custom methods

	public static Vector3 GetRandomSpawnLocation() {
		int xcoord=Random.Range(-Parameters.Field_SpawnRadius,Parameters.Field_SpawnRadius);
		int ycoord=Random.Range(-Parameters.Field_SpawnRadius,Parameters.Field_SpawnRadius);

		return new Vector3(xcoord,1,ycoord);
	}
}
