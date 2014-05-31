using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BEHAVIORTYPE { IDLE, EATING, LOOKINGFORFOOD, MOVINGTODESTINATION, HARVESTING};
public enum STATUS { NORMAL, HUNGRY };

public class Agent : MonoBehaviour {

	public int sightRadius;
	protected Inventory inventory=new Inventory();
	
	public virtual void FixedUpdate() {
		
	}

	public virtual void Awake() {

	}

	public virtual void OnTriggerStay() {

	}

	public void imDead() {
		Destroy(gameObject);
	}

	public void imDead(Corpse myCorpse) {

	}

}
