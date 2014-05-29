using UnityEngine;
using System.Collections;

public class Creature : Agent {

	int lifePoints;
	public int maxLifePoints;
	public int moveRate;

	Corpse corpse;
	Vector3 destination;



	public override void FixedUpdate() {
		checkDeath();
	}

	public override void Awake() {
		lifePoints=maxLifePoints;
	}

	public int getLife() {
		return lifePoints;
	}
	
	public void setLife(int inLife) {
		lifePoints=inLife;
	}

	public Corpse getCorpse() {
		return corpse;
	}

	public void setCorpse(Corpse inCorpse) {
		corpse=inCorpse;
	}

	void checkDeath() {
		if (lifePoints<=0) imDead();
	}

}
