using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
    public float speed;
    Aika a;
    public static GameObject poi;
    Parallax par;
	// Use this for initialization
	void Start () {
        a = gameObject.GetComponent<Aika>();
        poi = GameObject.Find("Poitsukka");
        par = GetComponent<Parallax>();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKey(KeyCode.LeftArrow))
        {
           transform.Translate( -speed * Time.deltaTime, 0, 0);
            a.speed = 10000;
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            a.speed = -10000;
        }*/
	}


    public void Zoom (int zoom)
    {
        poi.transform.parent = null;
        par.active = false;
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.Translate(new Vector3(0, poi.transform.position.y - transform.position.y, zoom));
        //poi.transform.parent = transform;
        //par.active = true;
    }

    public void UnZoom(int unZoom)
    {
        //par.active = false;
        //poi.transform.parent = null;
        transform.position = new Vector3(transform.position.x, -4.7f, -22.3f);
        poi.transform.parent = transform;
        par.previousPos = transform.position;
        par.active = true;
    }
}
