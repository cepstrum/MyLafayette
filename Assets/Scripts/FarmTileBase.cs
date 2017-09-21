using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTileBase : MonoBehaviour {
	[SerializeField] private Sprite farm_tile;
	[SerializeField] private Sprite soil_tile;

	public GameObject Hand;
	public HandScript handScript;


	public Crops carrot;



	public void OnMouseDown() {
		Debug.Log ("I pressed the button");
		handScript = Hand.GetComponent<HandScript> ();
		if (handScript.ToolInHand == 1) { // 0 means nothing
			GetComponent<SpriteRenderer> ().sprite = soil_tile;
		}
			else if (handScript.ToolInHand == 2){
				GetComponent<SpriteRenderer> ().sprite = farm_tile;
			}

		} 
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = farm_tile;
		carrot = new Crops("carrot", 5);
		Debug.Log (carrot.daysUntilHarvested);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
