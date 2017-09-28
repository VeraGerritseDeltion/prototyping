using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSlot : MonoBehaviour {
    public Customer customer;
    public NewOrderManager orderManager;
    public NewCustomer newCustomer;
    public int index;

    public void RightClick()
    {
        if(customer != null)
        {
            newCustomer.customerSlots[index].enabled = false;
            StartCoroutine(orderManager.NewOrder());
            Destroy(customer.gameObject);
        }
    }
}
