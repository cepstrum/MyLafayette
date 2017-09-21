using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGrapeButton : MonoBehaviour {

	public Inventory inventory;

	public void AddItemToInventory(GameObject theItem)
	{
		inventory.AddItem (theItem.GetComponent<Item> ());
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
