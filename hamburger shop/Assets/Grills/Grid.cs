using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {
    RectTransform parent;
    GridLayoutGroup grid;
	// Use this for initialization
	void Start () {
        parent = gameObject.GetComponent<RectTransform>();
        grid = gameObject.GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(parent.rect.width / 2 - 10, parent.rect.height / 2 - 10);
	}
	
	// Update is called once per frame
	void Update () {
        grid.cellSize = new Vector2(parent.rect.width / 2 - 10, parent.rect.height / 2 - 10);
    }
}
