using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

	List<Item> Items = new List<Item>();

	public Inventory() {

	}

	public bool isEmpty() {
		bool empty=false;

		if (Items.Count==0) empty=true;

		return empty;
	}

	public void putItem(Item itemToPut) {
		Items.Add(itemToPut);
	}

	public void retrieveItem(Item itemToRetrieve) {
		Items.Remove(itemToRetrieve);
	}

}
