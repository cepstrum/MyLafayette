using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private RectTransform inventoryRect;

	private float inventoryWidth, inventoryHeight;

	public int slots, rows;

	public float slotPaddingLeft, slotPaddingTop;

	public float slotSize;

	public GameObject slotPrefab;

	private SlotScript from, to;

	private List<GameObject> allSlots;

	private static int emptySlots;

	public static int EmptySlots 
	{
		get { return emptySlots; }
		set { emptySlots = value; }
	}







	// Use this for initialization
	void Start () {

		CreateLayout ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void CreateLayout()
	{
		allSlots = new List<GameObject> ();

		emptySlots = slots;

		inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

		inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

		inventoryRect = GetComponent<RectTransform> ();

		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inventoryWidth);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inventoryHeight);

		int columns = slots / rows;

		for (int y = 0; y < rows; y++)
		{
			for (int x = 0; x < columns; x++)
			{
				GameObject newSlot = (GameObject)Instantiate (slotPrefab);

				RectTransform slotRect = newSlot.GetComponent<RectTransform> ();

				newSlot.name = "Slot";

				newSlot.transform.SetParent (this.transform.parent);

				slotRect.localPosition = inventoryRect.localPosition + new Vector3 (slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));

				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);

				allSlots.Add (newSlot);


			


			}
		}
	}

	public bool AddItem (Item item)
	{
		if (item.maxSize == 1) {
			PlaceEmpty (item);
			return true;
		} 
		else 
		{
			foreach (GameObject slot in allSlots)
			{
				SlotScript tmp = slot.GetComponent<SlotScript> ();

					if (!tmp.IsEmpty)
					{
						if (tmp.CurrentItem.type == item.type && tmp.IsAvailable)
						{
							tmp.AddItem(item);
							return true;
						}
					}
			}

			if (emptySlots > 0)
			{
				PlaceEmpty(item);
			}
		}


		return false;
	
	}


	private bool PlaceEmpty(Item item)
	{
		if (emptySlots > 0)
		{
			foreach (GameObject slot in allSlots)
			{
				SlotScript tmp = slot.GetComponent<SlotScript> ();

				if (tmp.IsEmpty)
				{
					tmp.AddItem(item);
					emptySlots--;
					return true;
				}
			}
		}
		return false;
	}

	public void MoveItem(GameObject clicked)
	{
		if (from == null) {
			if (!clicked.GetComponent<SlotScript> ().IsEmpty) {
				from = clicked.GetComponent<SlotScript> ();
				from.GetComponent<Image> ().color = Color.gray;
			}
		} 
		else if (to == null) 
		{
			to = clicked.GetComponent<SlotScript> ();
		}
		if (to != null && from != null) 
		{
			Stack<Item> tmpTo = new Stack<Item> (to.Items);
			to.AddItems (from.Items);

			if (tmpTo.Count == 0) 
			{
				from.ClearSlot ();
			} 
			else 
			{
				from.AddItems (tmpTo);
			}

			from.GetComponent<Image> ().color = Color.white;
			to = null;
			from = null;

		}
	}

}
