using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGrill : SingleGrill {
    public bool bin;
    public bool finished;

	void Update () {
		if (finished == true && burger != null)
        {
            CookingStationManager.finishedHamburgers.Add(burger);
            burger.hamburger.enabled = false;
            burger.pickedUp = true;           
            burger = null;
        }
        if(bin == true && burger != null)
        {
            Destroy(burger.gameObject);
            burger = null;
        }
	}
}
