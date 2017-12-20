using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    BoxCollider2D shoes;
    Transform goBack;
    Poitsukka poitsukka;
	// Use this for initialization
	void Start () {
        shoes = GameObject.Find("kengätInteractable").GetComponent<BoxCollider2D>();
        goBack = transform.Find("goBack");
        poitsukka = GameObject.Find("Poitsukka").GetComponent<Poitsukka>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Poitsukka")
        {
            shoes.enabled = true;
            goBack.gameObject.SetActive(true);
            poitsukka.allowedLeft = false;
            TouchInput.allowedLeft = false;
            poitsukka.allowedRight = false;
            TouchInput.allowedRight = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Poitsukka")
        {
            shoes.enabled = false;
            goBack.gameObject.SetActive(false);
            poitsukka.allowedLeft = true;
            TouchInput.allowedLeft = true;
            poitsukka.allowedRight = true;
            TouchInput.allowedRight = true;
        }
    }
}
