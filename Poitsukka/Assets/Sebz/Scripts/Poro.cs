using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Time.deltaTime, 0, 0));
	}
}
