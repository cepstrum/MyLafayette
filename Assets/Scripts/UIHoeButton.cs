using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoeButton : MonoBehaviour {

	public GameObject Hand;
	public HandScript handScript;

	public void EquipTheHoe(){
		handScript = Hand.GetComponent<HandScript> ();
			handScript.ToolInHand = 1; // 1 means hoe
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
