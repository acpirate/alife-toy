using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BEHAVIORTYPE { IDLE, EATING, LOOKINGFORFOOD, MOVINGTODESTINATION };

public class Agent : MonoBehaviour {

	public int sightRadius;
	Inventory inventory;
	
	public virtual void FixedUpdate() {
		
	}

	public virtual void Awake() {

	}

	public virtual void OnTriggerStay() {

	}

	public List<GameObject> stuffICanSee() {
		List<GameObject> tempStuffList=new List<GameObject>();

		Collider[] collidersInSightRange = Physics.OverlapSphere(transform.position,sightRadius);

		foreach (Collider colliderInSightRange in collidersInSightRange) {
			if (colliderInSightRange.gameObject!=gameObject) tempStuffList.Add(colliderInSightRange.gameObject);
		}


		return tempStuffList;
	}

	public void imDead() {
		Destroy(gameObject);
	}

	public void imDead(Corpse myCorpse) {

	}

}
