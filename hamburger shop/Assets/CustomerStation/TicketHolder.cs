using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketHolder : MonoBehaviour {
    public NewOrder newOrder;
    public NewOrderManager orderManager;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Select()
    {
        orderManager.Select(this);
    }

    public void Deselect()
    {
        orderManager.Deselect();
    }

    public void Drag()
    {
        if (newOrder != null)
        {
            newOrder.enabled = false;
            orderManager.Drag(newOrder, this);
        }

    }
    public void Drop()
    {
        orderManager.Drop();
    }
}
