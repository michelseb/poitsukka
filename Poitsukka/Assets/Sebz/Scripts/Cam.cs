using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
    public float speed;
    Aika a;
	// Use this for initialization
	void Start () {
        a = gameObject.GetComponent<Aika>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
           transform.Translate( -speed * Time.deltaTime, 0, 0);
            a.speed = 10000;
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            a.speed = -10000;
        }
	}
}
