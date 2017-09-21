using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerClickHandler {

	private Stack<Item> items;

	public Stack<Item> Items
	{
		get { return items; }
		set {items = value;}
	}

	public Text stackTxt;

	public Sprite slotEmpty; 

	public bool IsEmpty
	{
		get { return items.Count == 0; }
	}

	public Item CurrentItem {
		get { return items.Peek (); }
	}

	public bool IsAvailable {
		get {return CurrentItem.maxSize > items.Count; }
	}



	// Use this for initialization
	void Start () {

		items = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform txtRect = stackTxt.GetComponent<RectTransform> ();

		int txtScaleFactor = (int)(slotRect.sizeDelta.x * 0.60);
		stackTxt.resizeTextMaxSize = txtScaleFactor;
		stackTxt.resizeTextMinSize = txtScaleFactor;

		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem (Item item)
	{
		items.Push(item);

		if (items.Count > 1)
		{
			stackTxt.text = items.Count.ToString ();
		}

		ChangeSprite (item.spriteNuetral);
	}

	public void AddItems(Stack<Item> items)
	{
		this.items = new Stack<Item> (items);

		stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;

		ChangeSprite (CurrentItem.spriteNuetral);
	}

	private void ChangeSprite(Sprite neutral)
	{
		GetComponent<Image> ().sprite = neutral;
	}


	private void UseItem()
	{
		if (!IsEmpty) {
			items.Pop ().Use ();

			stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;

			if (IsEmpty) {
				ChangeSprite (slotEmpty);

				Inventory.EmptySlots++;

			}
		}
	}




		public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right) {
			UseItem ();
		}
	}

	public void ClearSlot()
	{
		items.Clear ();
		ChangeSprite (slotEmpty);
		stackTxt.text = string.Empty;
	}

}



