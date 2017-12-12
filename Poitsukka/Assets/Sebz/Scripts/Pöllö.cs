using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pöllö : MonoBehaviour {

    float height;
    public Animator anim;
    public Collider2D col;
    AllConditions a;

    private void Awake()
    {
        col = transform.GetComponentInChildren<Collider2D>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        height = (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 2f - 1f)*2;
        transform.Translate(0, height * Time.deltaTime, 0);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(a.conditions[1]);
    }
}
