using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteManager : MonoBehaviour {

    SpriteRenderer[] parts;
    int[] partsOrder;
    public GameObject mainPart;
    int mainPartOrder;

	// Use this for initialization
	void Start () {
        mainPartOrder = mainPart.GetComponent<SpriteRenderer>().sortingOrder;
        parts = transform.GetComponentsInChildren<SpriteRenderer>();

        for(int i = 0; i < parts.Length; i++)
        {
            partsOrder[i] = parts[i].sortingOrder - mainPartOrder;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (mainPartOrder != mainPart.GetComponent<SpriteRenderer>().sortingOrder)
        {
            Order();
            mainPartOrder = mainPart.GetComponent<SpriteRenderer>().sortingOrder;
            Debug.Log("Ordering!");
        }
		
	}

    public void Order()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].sortingOrder = mainPartOrder + partsOrder[i];
        }
    }
}
