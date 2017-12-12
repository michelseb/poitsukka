using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    Poitsukka poitsukka;

	// Use this for initialization
	void Start () {
        poitsukka = GameObject.Find("Poitsukka").GetComponent<Poitsukka>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
