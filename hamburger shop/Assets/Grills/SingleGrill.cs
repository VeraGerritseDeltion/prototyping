using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGrill : MonoBehaviour {
    public Hamburger burger;
    public Grills grills;

    public void select()
    {
        grills.SelectBurger(this);
    }

    public void deselect()
    {
        grills.DeselectBurger();
    }

    public void OnClick()
    {
        if(burger != null)
        {
            burger.hamburger.enabled = false;
            grills.Drag(burger, this);
            burger.pickedUp = true;
        }
        
    }

    public void Drop()
    {
        grills.Drop();        
    }


}
