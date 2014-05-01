using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public int CameraSpeed;
	public int CameraRunMultiplier;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		CameraMove();	
	}

	void CameraMove() {
		float xMove=0;
		float zMove=0;

		xMove=Input.GetAxis("Horizontal") * CameraSpeed;
		zMove=Input.GetAxis("Vertical") * CameraSpeed;

		//shift to "run"
		if (Input.GetKey(KeyCode.LeftShift)) {
			xMove*=CameraRunMultiplier;
			zMove*=CameraRunMultiplier;
		}

		transform.position+=new Vector3(xMove,0,zMove);

	}
}
