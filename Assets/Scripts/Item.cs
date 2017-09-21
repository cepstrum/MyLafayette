using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype {CARROT, GRAPE};


public class Item : MonoBehaviour {

	public Inventory inventory;

	public Itemtype type;
	public Sprite spriteNuetral;
	public Sprite spriteHighlighted;
	public int cost;



	public int maxSize;

	public void Use()
	{
		switch (type) {
		case Itemtype.CARROT:
			Debug.Log ("I just used a carrot");
			break;
		case Itemtype.GRAPE:
			Debug.Log ("I just used a grape");
			break;
		}
	
	}
//	public void AddItemToInventory(string itemName)
//	{
//		switch (itemName) {
//		case "grape":
//			Seed grapeSeed = new Seed();
//			inventory.AddItem (grapeSeed);
//			break;
//		}
//	}
//

}
