using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour {
    public Canvas cooking;
    public Canvas building;
    public Canvas customer;

    public enum Menus
    {
        cookingStation,
        buildStation,
        customerStation
    }
    public Menus menus;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(menus == Menus.buildStation)
        {
            building.enabled = true;
        }
        else
        {
            building.enabled = false;
        }
        if(menus == Menus.cookingStation)
        {
            cooking.enabled = true;
        }
        else
        {
            cooking.enabled = false;
        }
        if(menus == Menus.customerStation)
        {
            customer.enabled = true;
        }
        else
        {
            customer.enabled = false;
        }
	}

    public void CookingStation()
    {
        menus = Menus.cookingStation;
    }

    public void BuildStation()
    {
        menus = Menus.buildStation;
    }

    public void CustomerStation()
    {
        menus = Menus.customerStation;
    }
}
