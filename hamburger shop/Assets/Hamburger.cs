using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour {
    public Sprite hB2d;
    public float rawTime = 2;
    public float cookedTime=2;
    public bool cooked;
    public bool burned;
    // Use this for initialization
    void Start () {
        StartCoroutine(Raw());
	}

    public IEnumerator Raw()
    {

        yield return new WaitForSeconds(rawTime);
        cooked = true;
        Cooked();
    }

    public IEnumerator Cooked()
    {
        burned = true;
        yield return new WaitForSeconds(cookedTime);
    }


}
