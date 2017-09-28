using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BurgerAssembly : MonoBehaviour {
    public List<int> finalBurger = new List<int>();
    public List<Sprite> burgerParts = new List<Sprite>();
    public List<Image> parts = new List<Image>();
    public Image bigImage;
    public Image startBurger;
    public Image currentLoc;
    public NewOrderManager orderManager;
    public int part;
    public Image checkMark;
    public int price = 3;
    public float score;

    private void Start()
    {
        currentLoc = startBurger;
    }

    public void TopBun()
    {
        part = 0;
        finalBurger.Add(part);
        BigSpace();
        TopOfBurger();
    }

    public void Lettuce()
    {
        if (finalBurger.Count < 5)
        {
            part = 1;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Tomato()
    {
        if (finalBurger.Count < 5)
        {
            part = 2;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Cheese()
    {
        if (finalBurger.Count < 5)
        {
            part = 3;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Bun()
    {
        if (finalBurger.Count < 5)
        {
            part = 4;
            finalBurger.Add(part);
            BigSpace();
        }
    }

    public void Burger()
    {
        if (finalBurger.Count < 5)
        {
            List<Hamburger> burger = CookingStationManager.finishedHamburgers;
            print(burger.Count);

            if (burger.Count != 0)
            {
                if (burger[0].cooked == true && burger[0].burned != true)
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
            parts.Add(currentLoc);
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
            parts.Add(currentLoc);
        }

        public IEnumerator DestroyBurger()
        {
            yield return new WaitForSeconds(1);
            for (int i = 0; i < parts.Count; i++)
            {
                Destroy(parts[i]);
            }
            Destroy(orderManager.allTicketPlaces[0].newOrder.gameObject);
            orderManager.allTicketPlaces[0].newOrder = null;
            parts.Clear();
            currentLoc = startBurger;
            finalBurger.Clear();

        }

        public void TopOfBurger()
        {
            List<int> order = orderManager.allTicketPlaces[0].newOrder.requestedBurger;
            int amount = orderManager.allTicketPlaces[0].newOrder.amount + 1;
            int total = 0;
            int tooMuch = 0;
            int howTooMuch = 0;
            if (finalBurger.Count > order.Count)
            {
                tooMuch = order.Count;
                howTooMuch = finalBurger.Count - order.Count;
            }
            else if(finalBurger.Count == order.Count)
            {
                tooMuch = finalBurger.Count;
            }
            else
            {
                tooMuch = finalBurger.Count;
                howTooMuch = order.Count - finalBurger.Count;
            }
            for(int i = 0; i < tooMuch; i++)
            {
                if(order[i] == finalBurger[i])
                {
                    total++;
                }
            }
            if(total - howTooMuch > 0)
            {
                total -= howTooMuch;
            }
            else
            {
                total = 0;
            }
            total *= price;
            score += total;
            print("score: " + score);
            
            StartCoroutine(DestroyBurger());
        }
}
