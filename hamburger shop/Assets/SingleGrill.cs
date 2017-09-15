using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleGrill : MonoBehaviour {

    public Hamburger item;
    public Grills allGrills;
    public Image image;
    public bool selected;
    public bool bin;
    public bool selec;

    void Start()
    {
        allGrills = GetComponentInParent<Grills>();
        GameObject test = transform.Find("ItemImage").gameObject;
        image = test.GetComponent<Image>();
    }

    private void Update()
    {
        if (item != null && selected == false)
        {
            image.sprite = item.hB2d;
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }



    public void OnClick()
    {
        selected = true;
        image.enabled = false;
        allGrills.MoveItem(item, this);
    }



    public void Selected()
    {
        allGrills.selected(this);
        if (item != null)
        {
            selec = true;
        }
}

    public void Deselect()
    {
        allGrills.selected(null);
        selec = false;
    }

    public void Dropping()
    {
        allGrills.usedItemslot.selected = false;
        if (allGrills.itemSelected == this && allGrills.itemToMove != null)
        {
            allGrills.Drop();
            allGrills.imageOnMouse.enabled = false;
        }
    }
}
