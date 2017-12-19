using UnityEngine;
using System.Collections;

public class Poitsukka : MonoBehaviour {

    Cam cam;
    Animator anim;
    Component[] bodyparts;
    public bool allowedLeft = true, allowedRight = true;
    public bool goesRight = true;

    void Awake ()
    {
        cam = GameObject.Find("Camera").GetComponent<Cam>();
        anim = GameObject.Find("Body").GetComponent<Animator>();
        anim.SetBool("walk", false);
        anim.SetBool("idle", true);
    }


	// Use this for initialization
	void Start () {
        anim.SetFloat("speed", cam.speed);
        bodyparts = transform.GetComponentsInChildren<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && allowedLeft)
        {
            Flip("gauche");
            Walk();

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && allowedRight)
        {
            Flip("droite");
            Walk();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
    }



    public void Walk()
    {
        if (anim.GetBool("walk") == false)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("walk", true);
        }
        //if (anim.Get)



    }

    public void Run()
    {
        if (anim.GetBool("run") == false)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("run", true);
        }
        //if (anim.Get)



    }

    public void Idle()
    {
        if (anim.GetBool("idle") == false)
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
            anim.SetBool("idle", true);
        }
    }

    public void Flip(string dir)
    {

        switch (dir)
        {
            case "gauche":
                //transform.localScale = new Vector3(-1, 1, 1);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                goesRight = false;
                //transform.rotation = new Quaternion(0, 180, 0, 0);
                /*foreach (Component a in bodyparts)
                {
                    if (a.GetComponent<SpriteRenderer>())
                    {
                        a.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    
                }*/
                break;

            case "droite":

                //transform.rotation = new Quaternion(0, 0, 0, 0);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                goesRight = true;
                /*foreach (Component a in bodyparts) {

                    if (a.GetComponent<SpriteRenderer>()) {
                        a.GetComponent<SpriteRenderer>().flipX = false;
                    }
                }*/
                break;
        }

    }

    /*public void orderBody()
    {
        int baseOrder = GameObject.Find()
    }*/

}
