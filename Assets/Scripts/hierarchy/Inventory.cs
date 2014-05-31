using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

	List<Item> items;

	public Inventory() {
		items=new List<Item>();
	}

	public bool isEmpty() {
		bool empty=false;

		if (items.Count==0) empty=true;

		return empty;
	}

	public void putItem(Item itemToPut) {
		items.Add(itemToPut);
	}

	public void retrieveItem(Item itemToRetrieve) {
		items.Remove(itemToRetrieve);
	}

	public List<Item> getItems() {
		return items;
	}

}
