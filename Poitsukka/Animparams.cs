using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animparams : MonoBehaviour {

    GameObject poitsukka, cam, hand;
    Parallax parallax;
    Animator anim;
    public GameObject[] pocket;
    

    void Awake ()
    {
        hand = GameObject.Find("hand1");
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

    public void camZoom(int zoom)
    {
        cam.GetComponent<Cam>().Zoom(zoom);
    }

    public void camUnZoom(int zoom)
    {
        cam.GetComponent<Cam>().UnZoom(zoom);
    }

    public void takePool()
    {
        GameObject pool = Instantiate(pocket[0], hand.transform.position, new Quaternion(hand.transform.rotation.x, hand.transform.rotation.y, hand.transform.rotation.z +2, hand.transform.rotation.w));
        pool.transform.localScale = new Vector3(.6f, .7f, .6f);
        pool.transform.parent = hand.transform;

    }


}
