using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BurgerAssembly : MonoBehaviour {
    public List<int> finalBurger = new List<int>();
    public List<Sprite> burgerParts = new List<Sprite>();
    public List<Sprite> parts = new List<Sprite>();
    public Image bigImage;
    public Image startBurger;
    public Image currentLoc;
    public int part;

    private void Start()
    {
        currentLoc = startBurger;
    }

    public void TopBun()
    {
        part = 0;
        finalBurger.Add(part);
        BigSpace();
    }

    public void Lettuce()
    {
        part = 1;
        finalBurger.Add(part);
        SmallSpace();
    }

    public void Tomato()
    {
        part = 2;
        finalBurger.Add(part);
        SmallSpace();
    }

    public void Cheese()
    {
        part = 3;
        finalBurger.Add(part);
        SmallSpace();
    }

    public void Bun()
    {
        part = 4;
        finalBurger.Add(part);
        SmallSpace();
    }

    public void Burger()
    {
        List<Hamburger> burger = CookingStationManager.finishedHamburgers;
        print(burger.Count);

        if(burger.Count != 0)
        {
            if(burger[0].cooked == true && burger[0].burned != true)
            {
                part = 5;
            }
            else if (burger[0].burned == true)
            {
                part = 6;
            }
            else
            {
                part = 7;
            }
            finalBurger.Add(part);
            CookingStationManager.finishedHamburgers.RemoveAt(0);
            BigSpace();
        }
        
    }

    public void BigSpace()
    {
        Image newItem = Instantiate(bigImage, currentLoc.transform.position, Quaternion.identity);
        newItem.transform.SetParent(currentLoc.transform);
        Vector2 forNow = newItem.transform.position;
        forNow.y += 10;
        newItem.transform.position = forNow;
        newItem.sprite = burgerParts[part];
        currentLoc = newItem;
    }

    public void SmallSpace()
    {
        Image newItem = Instantiate(bigImage, currentLoc.transform.position, Quaternion.identity);
        newItem.transform.SetParent(currentLoc.transform);
        Vector2 forNow = newItem.transform.position;
        forNow.y += 2.5f;
        newItem.transform.position = forNow;
        newItem.sprite = burgerParts[part];
        currentLoc = newItem;
    }

}
