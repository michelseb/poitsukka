using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    Poitsukka poitsukka;
    public Animator anim;
    public bool allowed;
    public string message;
    public Color textColor = Color.black;
    public float delay;
    private TextManager textManager;
    Condition[] allCond;

    // Use this for initialization
    void Start () {
        poitsukka = GameObject.Find("Poitsukka").GetComponent<Poitsukka>();
        textManager = FindObjectOfType<TextManager>();
        allCond = AllConditions.GetConditions();
    }


    // Update is called once per frame
    void Update() {
        if (allCond[10].satisfied == true)
        {
            allowed = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (allowed)
        {
            anim.SetTrigger("jump");
            Debug.Log("Saute !");
        }
        else
        {
            if (poitsukka.goesRight == false)
            {
                poitsukka.allowedLeft = false;
                TouchInput.allowedLeft = false;
            }
            else
            {
                poitsukka.allowedRight = false;
                TouchInput.allowedRight = false;
            }
            poitsukka.Idle();
            textManager.DisplayMessage(message, textColor, delay);

        }
        Debug.Log(TouchInput.allowedLeft);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        poitsukka.allowedLeft = true;
        poitsukka.allowedRight = true;
        TouchInput.allowedRight = true;
        TouchInput.allowedLeft = true;
        TouchInput.allowedToMove = true;
    }



}
