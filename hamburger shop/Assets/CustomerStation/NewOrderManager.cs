using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewOrderManager : MonoBehaviour {
    public Image ticket;
    public Image newTicket;
    public List<Sprite> parts = new List<Sprite>();
    public TicketHolder selectedTicket;
    public TicketHolder usedHolder;
    public List<TicketHolder> allTicketPlaces = new List<TicketHolder>();
    public bool full;

    void Start () {
		
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(NewOrder());
        }
	}

    public IEnumerator NewOrder()
    {
        yield return new WaitForSeconds(0.5f);
        full = Full();
        if (full == true)
        {
            if (newTicket.GetComponent<TicketHolder>().newOrder != null)
            {
                Next();
            }
            Image something = Instantiate(ticket, newTicket.transform.position, Quaternion.identity);
            something.transform.SetParent(newTicket.transform);
            TicketHolder holder = newTicket.GetComponent<TicketHolder>();
            NewOrder script = something.GetComponent<NewOrder>();
            holder.newOrder = script;
            script.parts = parts;
        }
    }

    public void Select(TicketHolder selected)
    {
        selectedTicket = selected;
    }

    public void Deselect()
    {
        selectedTicket = null;
    }

    public void Drag(NewOrder toDrag,TicketHolder usedHolderTime)
    {
        if(toDrag != null) { usedHolder = usedHolderTime;
        usedHolder.newOrder.transform.position = Input.mousePosition;
        usedHolder.newOrder.transform.SetParent(gameObject.transform);}
        

    }
    public void Drop()
    {
        if(selectedTicket != null)
        {
            if (selectedTicket.newOrder == null)
            {
                usedHolder.newOrder.transform.SetParent(selectedTicket.transform);
                usedHolder.newOrder.transform.position = selectedTicket.transform.position;
                selectedTicket.newOrder = usedHolder.newOrder;
                selectedTicket.newOrder.transform.localScale = new Vector3(1, 1, 1);
                usedHolder.newOrder = null;
                
            }
            else
            {
                NewOrder tempie = selectedTicket.newOrder;
                selectedTicket.newOrder = usedHolder.newOrder;
                selectedTicket.newOrder.transform.SetParent(selectedTicket.gameObject.transform);
                selectedTicket.newOrder.transform.position = selectedTicket.transform.position;
                selectedTicket.newOrder.transform.localScale = new Vector3(1, 1, 1);

                usedHolder.newOrder = tempie;
                usedHolder.newOrder.transform.position = usedHolder.transform.position;
                usedHolder.newOrder.transform.SetParent(usedHolder.transform);
                usedHolder.newOrder.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            usedHolder.newOrder.transform.position = usedHolder.transform.position;
        }

       
    }
    public void Next()
    {
        TicketHolder holderForNewTicket = newTicket.GetComponent<TicketHolder>();
        for (int i = 0; i < allTicketPlaces.Count; i++)
        {
            if (allTicketPlaces[i].newOrder == null)
            {
                allTicketPlaces[i].newOrder = holderForNewTicket.newOrder;
                allTicketPlaces[i].newOrder.gameObject.transform.SetParent(allTicketPlaces[i].transform);
                allTicketPlaces[i].newOrder.gameObject.transform.position = allTicketPlaces[i].transform.position;
                allTicketPlaces[i].newOrder.transform.localScale = new Vector3(1, 1, 1);
                return;
            }
        }
    }
    public bool Full()
    {
        bool isItFull = false;
        for(int i = 0; i < allTicketPlaces.Count; i++)
        {
            if(allTicketPlaces[i].newOrder == null)
            {
                isItFull = true;
                
            }
        }
        return isItFull;
    }
}
