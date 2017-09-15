using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerManager : MonoBehaviour {
    public List<Sprite> grills = new List<Sprite>();
    public List<Image> onGrill = new List<Image>();
    public Sprite rawHamburger;
    public GameObject hamburger;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonDown()
    {
        for(int i = 0; i < onGrill.Count; i++)
        {
            if(onGrill[i].sprite == null)
            {
                onGrill[i].sprite = rawHamburger;

            }
        }
    }
}
