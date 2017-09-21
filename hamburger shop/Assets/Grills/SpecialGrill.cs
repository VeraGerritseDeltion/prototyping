using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SpecialGrill : SingleGrill {
    public bool bin;
    public bool finished;
    public Image MeatOnPlate;
    

	void Update () {
		if (finished == true && burger != null)
        {
            CookingStationManager.finishedHamburgers.Add(burger);
            burger.hamburger.enabled = false;
            MeatOnPlate.sprite = burger.hB2d;
            burger.pickedUp = true;           
            burger = null;
        }
        if (CookingStationManager.finishedHamburgers.Count != 0 && finished == true)
        {
            MeatOnPlate.enabled = true;
        }
        else if(finished == true)
        {
            MeatOnPlate.enabled = false;
        }
        
        if(bin == true && burger != null)
        {
            Destroy(burger.gameObject);
            burger = null;
        }
	}
}
