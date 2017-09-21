using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hamburger : MonoBehaviour {
    public Sprite hB2d;
    public float rawTime = 2;
    public float cookedTime = 2;
    public bool cooked;
    public bool burned;
    public Image hamburger;
    public Sprite raw2d;
    public Sprite cooked2d;
    public Sprite burned2d;
    public float timer;
    public bool pickedUp;

    // Use this for initialization
    void Start () {
        hamburger = gameObject.GetComponent<Image>();
        hB2d = raw2d;
        hamburger.sprite = raw2d;
	}

    private void Update()
    {
        if (pickedUp == false)
        {
            Times();
        }
        if (timer > rawTime && timer < cookedTime)
        {
            hamburger.sprite = cooked2d;
            hB2d = cooked2d;
            cooked = true;
        }
        if(timer > cookedTime)
        {
            hB2d = burned2d;
            burned = true;
            hamburger.sprite = burned2d;
        }
    }

    public void Times()
    {
        timer += Time.deltaTime;
    }
}
