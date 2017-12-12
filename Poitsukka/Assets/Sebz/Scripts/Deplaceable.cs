using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplaceable : MonoBehaviour {
    Transform poitsu;
    float dist;
    public float allowed_dist;
    public float move_dist;
	// Use this for initialization
	void Start () {
        poitsu = GameObject.Find("Poitsukka").transform;
        /*if (allowed_dist == 0)
        {*/
            allowed_dist = 260;
        /*}
        if (move_dist == 0)
        {*/
            move_dist = 490;//Random.Range(50,80);
        //}
	}
	
	// Update is called once per frame
	void Update () {
        dist = transform.position.x - poitsu.position.x;
        if (dist < -allowed_dist)
        {
            transform.Translate(move_dist, 0, 0);
        }
        if (dist > allowed_dist)
        {
            transform.Translate(-move_dist, 0, 0);
        }
	}
}
