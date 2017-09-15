using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grills : MonoBehaviour {
    public List<SingleGrill> itemslotScript = new List<SingleGrill>();
    public List<GameObject> itemSlot = new List<GameObject>();
    public List<GameObject> ItemObj = new List<GameObject>();

    public GameObject itemslotGameobject;
    public int itemslotRows;
    public Vector3 pos;
    public GameObject inventory;
    public SingleGrill itemSelected;

    public Image imageOnMouse;
    public Hamburger itemToMove;
    public SingleGrill usedItemslot;

    void Start()
    {
        itemslotRows = itemslotRows * 4 - 1;
        for (int i = 0; i < itemslotRows; i++)
        {
            itemSlot.Add(Instantiate(itemslotGameobject, pos, Quaternion.identity) as GameObject);
            itemSlot[i].transform.parent = inventory.transform;
            itemslotScript.Add(null);
            itemslotScript[i] = itemSlot[i].GetComponent<SingleGrill>();
        }
    }

    private void Update()
    {
        imageOnMouse.transform.position = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (Input.GetButtonUp("Fire1"))
        {
            OnMouseUpp();
        }
    }



    public void AddItem(Hamburger newItem)
    {
        for (int i = 0; i < itemslotScript.Count; i++)
        {
            if (newItem != null)
            {
                if (itemslotScript[i].item == null)
                {
                    itemslotScript[i].item = newItem;
                    return;
                }
            }
        }
    }

    public void MoveItem(Hamburger moveItem, SingleGrill usedSlot)
    {
        usedItemslot = usedSlot;
        if (moveItem != null)
        {
            imageOnMouse.enabled = true;
            imageOnMouse.sprite = moveItem.hB2d;
            itemToMove = moveItem;
            usedItemslot = usedSlot;
        }
    }



    public void selected(SingleGrill slot)
    {
        itemSelected = slot;
    }

    public void Drop()
    {
        if (itemToMove != null && itemSelected != null)
        {
            if (itemSelected.item == null)
            {
                itemSelected.item = itemToMove;
                imageOnMouse.enabled = false;
                usedItemslot.item = null;
                usedItemslot.selected = false;
            }
            else if (itemSelected.item != null)
            {
                Hamburger temp = itemSelected.item;
                itemSelected.item = itemToMove;
                usedItemslot.item = temp;
                usedItemslot.selected = false;
                imageOnMouse.enabled = false;
            }
        }
    }

    public void OnMouseUpp()
    {
        if (itemSelected == null && usedItemslot != null)
        {
            usedItemslot.selected = false;
            imageOnMouse.enabled = false;
        }

        else if (itemSelected == usedItemslot && usedItemslot != null)
        {
            usedItemslot.selected = false;
            imageOnMouse.enabled = false;
        }
    }
}
