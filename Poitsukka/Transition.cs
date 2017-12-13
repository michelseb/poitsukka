using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    Poitsukka poitsukka;
    public Animator anim;

	// Use this for initialization
	void Start () {
        poitsukka = GameObject.Find("Poitsukka").GetComponent<Poitsukka>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("jump");
        Debug.Log("Saute !");
    }
}
