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
    public Image hamburger;
    public bool finished;

    private void Start()
    {
        currentLoc = startBurger;
    }

    private void Update()
    {
        List<Hamburger> burger = CookingStationManager.finishedHamburgers;
        if (burger.Count != 0)
        {
            if (burger[0].cooked == true && burger[0].burned != true)
            {
                hamburger.sprite = burgerParts[5];
                hamburger.enabled = true;
            }
            else if (burger[0].burned == true)
            {
                hamburger.sprite = burgerParts[6];
                hamburger.enabled = true;
            }
            else
            {
                hamburger.sprite = burgerParts[7];
                hamburger.enabled = true;
            }
        }
        else
        {
            hamburger.enabled = false;
        }
    }

    public void TopBun()
    {
        if (!finished)
        {
            part = 0;
            finalBurger.Add(part);
            BigSpace();
            TopOfBurger();
            finished = true;
        }
        
    }

    public void Lettuce()
    {
        if (finalBurger.Count < 5 && !finished)
        {
            part = 1;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Tomato()
    {
        if (finalBurger.Count < 5 && !finished)
        {
            part = 2;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Cheese()
    {
        if (finalBurger.Count < 5 && !finished)
        {
            part = 3;
            finalBurger.Add(part);
            SmallSpace();
        }
    }

    public void Bun()
    {
        if (finalBurger.Count < 5 && !finished)
        {
            part = 4;
            finalBurger.Add(part);
            BigSpace();
        }
    }

    public void Burger()
    {
        if (finalBurger.Count < 5 && !finished)
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
            int o = getTicket();
            if(getTicket()!= -1)
            {
                Destroy(orderManager.allTicketPlaces[o].newOrder.gameObject);
                orderManager.allTicketPlaces[o].newOrder = null;
            }            
            parts.Clear();
            currentLoc = startBurger;
            finalBurger.Clear();
            finished = false;
        }

        public void TopOfBurger()
        {
            if(getTicket() != -1)
            {
            List<int> order = orderManager.allTicketPlaces[getTicket()].newOrder.requestedBurger;
            int amount = orderManager.allTicketPlaces[getTicket()].newOrder.amount + 1;
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
            

            }
            StartCoroutine(DestroyBurger());
        }
        public int getTicket()
    {
        int i = 0;
        for(i=0;i < orderManager.allTicketPlaces.Count;i++)
        {
            if(orderManager.allTicketPlaces[i].newOrder != null)
            {
                return i;
            }
        }
        return -1;
    }
}
