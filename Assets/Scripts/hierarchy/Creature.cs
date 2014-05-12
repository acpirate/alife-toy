using UnityEngine;
using System.Collections;

public class Creature : Agent {

	int Life;

	public Creature(int inLife) {
		Life=inLife;
	}

	public int getLife() {
		return Life;
	}

	public void setLife(int inLife) {
		Life=inLife;
	}

}
