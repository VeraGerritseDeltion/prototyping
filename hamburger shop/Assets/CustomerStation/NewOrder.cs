using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewOrder : MonoBehaviour {

    public List<Image> ingredients = new List<Image>();
    public List<int> requestedBurger = new List<int>();
    public List<Sprite> parts = new List<Sprite>();
    public int amount;
    public bool meatInside;
    public float timeBeforeGone = 10;
    public float times;
    public int currentTime;
    public Text text;
	
	void Start () {
        timeBeforeGone = 25;
        int rand = Random.Range(3, 6);

        for(int i = 0;i < rand; i++)
        {
            int ingredient = Random.Range(1, 6);
            requestedBurger.Add(ingredient);
            ingredients[i].sprite = parts[ingredient];
            ingredients[i].enabled = true;
            amount++;
            if (requestedBurger[i] == 5)
            {
                meatInside = true;
            }
        }
        if(meatInside != true)
        {
            int ingredient = Random.Range(1, requestedBurger.Count);
            requestedBurger[ingredient] = 5;
            ingredients[ingredient].sprite = parts[5];
        }
            
        requestedBurger.Add(0);
        ingredients[amount].sprite = parts[0];
        ingredients[amount].enabled = true;
    }

    private void Update()
    {
        timeBeforeGone -= Time.deltaTime;
        currentTime = Mathf.RoundToInt(timeBeforeGone);
        text.text = currentTime.ToString();
        if (currentTime == 0)
        {
            TicketHolder parent = GetComponentInParent<TicketHolder>();
            parent.newOrder = null;
            Destroy(gameObject);
        }
    }
}
