using UnityEngine;
using System.Collections;

public class Thing {

	//gameobject used to display and interact with the thing
	GameObject WorldObject;
	//world position stored on thing for easier syntax
	Vector3 WorldPosition;
	//whether or not the thing is visible in the gameworld
	bool ShowThing = false;

	public Thing() {

	}

	public void setWorldObject(GameObject inGameObject) {
		WorldObject=inGameObject;
	}

	public GameObject getWorldObject() {
		return WorldObject;
	}
}
