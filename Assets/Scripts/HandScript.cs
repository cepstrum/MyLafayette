using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {
	


	public int ToolInHand;

	void Start () {
		ToolInHand = 0;
	}
	public void HandEquipTheHoe(){
		Debug.Log ("the click happened");
		
		if (ToolInHand == 0) { // 0 means nothing
			Debug.Log ("in the if");

			ToolInHand = 1; // 1 means hoe

		} else if (ToolInHand == 1) {

			ToolInHand = 0; 
		}
	}

	public void HandEquipTheShovel(){
		ToolInHand = 2; // 2 means shovel
	}

}

