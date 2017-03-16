using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTileBase : MonoBehaviour {
	[SerializeField] private Sprite farm_tile;
	[SerializeField] private Sprite soil_tile;

	public void OnMouseDown() {
		GetComponent<SpriteRenderer> ().sprite = soil_tile;
	}
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = farm_tile;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
