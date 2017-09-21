using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grills : MonoBehaviour {
    public List<GameObject> grill = new List<GameObject>();
    public List<SingleGrill> singleGrills = new List<SingleGrill>();

    public SingleGrill selectedGrill;
    public Image onMouse;
    public Hamburger toMove;
    public SingleGrill usedGrill;
    public GameObject burger;

    // Use this for initialization
    void Start () {
        onMouse.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        onMouse.transform.position = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    public void NewBurger()
    {
        for (int i = 0; i < singleGrills.Count; i++)
        {
                if (singleGrills[i].burger == null)
                {
                    GameObject now =Instantiate(burger, transform.parent.position, Quaternion.identity);
                    singleGrills[i].burger = now.GetComponent<Hamburger>();
                    now.transform.parent = singleGrills[i].transform;
                    now.transform.position = singleGrills[i].transform.position;
                    return;
                }
        }
    }

    public void SelectBurger(SingleGrill grill)
    {
        selectedGrill = grill;
    }

    public void DeselectBurger()
    {
        selectedGrill = null;
    }

    public void Drag(Hamburger toMoves, SingleGrill used)
    {
        toMove = toMoves;
        onMouse.enabled = true;
        onMouse.sprite = toMove.hamburger.sprite;
        usedGrill = used;
    }

    public void Drop()
    {
        if (selectedGrill != null)
        {
            if (selectedGrill.burger == null && usedGrill != null)
            {
                selectedGrill.burger = toMove;
                usedGrill.burger = null;
                selectedGrill.burger.gameObject.transform.parent = selectedGrill.transform;
                selectedGrill.burger.gameObject.transform.position = selectedGrill.transform.position;
                onMouse.enabled = false;
                selectedGrill.burger.hamburger.enabled = true;
                selectedGrill.burger.pickedUp = false;
            }
            else if (selectedGrill == usedGrill && usedGrill.burger != null)
            {
                onMouse.enabled = false;
                usedGrill.burger.hamburger.enabled = true;
                selectedGrill.burger.pickedUp = false;
            }
        }
        else
        {
             onMouse.enabled = false;
             usedGrill.burger.hamburger.enabled = true;
             usedGrill.burger.pickedUp = false;
        }
    }
}
