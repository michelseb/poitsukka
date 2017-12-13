using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animparams : MonoBehaviour {

    GameObject poitsukka, cam;
    Parallax parallax;
    Animator anim;

    void Awake ()
    {
        poitsukka = GameObject.Find("Poitsukka");
        anim = GetComponent<Animator>();
        cam = GameObject.Find("Camera");
        parallax = cam.GetComponent<Parallax>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnAnimatorMove()
    {
        if (!Mathf.Approximately(0f, anim.deltaPosition.y)) {
            Vector3 newPosition = transform.parent.position;
            float camXPosition = cam.transform.position.x;
            newPosition.y += anim.deltaPosition.y;
            newPosition.x += anim.deltaPosition.x;
            camXPosition += anim.deltaPosition.x;
            cam.transform.position = new Vector3(camXPosition, cam.transform.position.y, cam.transform.position.z);
            transform.parent.position = newPosition;
        }
    }

    public void startJump()
    {
        TouchInput.allowedToMove = false;
        poitsukka.transform.parent = null;
        parallax.active = false;

    }
    public void endJump()
    {
        TouchInput.allowedToMove = true;
        poitsukka.transform.parent = cam.transform;
        parallax.active = true;

    }


}
