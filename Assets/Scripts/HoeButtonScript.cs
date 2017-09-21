using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeButtonScript : MonoBehaviour {

	public GameObject Hand;

	[SerializeField] private Sprite button_up;
	[SerializeField] private Sprite button_down;

	public HandScript handScript;


	public void OnMouseDown(){
		Debug.Log ("I pressed the button");
		handScript = Hand.GetComponent<HandScript> ();
		if (handScript.ToolInHand == 0) { // 0 means nothing
			GetComponent<SpriteRenderer>().sprite = button_down;
			handScript.ToolInHand = 1; // 1 means hoe
		} else if (handScript.ToolInHand == 1) {
			GetComponent<SpriteRenderer>().sprite = button_up;
			handScript.ToolInHand = 0;
		}
		//handScript.ToolInHand = "hoe";
		Debug.Log ("you are " + handScript.ToolInHand);
	}

		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
