using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pöllöTrigger : MonoBehaviour {

    AllConditions a;
    private Interactable interactable;

    // Use this for initialization
    void Start () {

        a = AllConditions.Instance;
        interactable = (Interactable)GetComponentInParent(typeof(Interactable));
        a.conditions[3].satisfied = false;

    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        a.conditions[3].satisfied = true;
        interactable.Interact();
        a.conditions[3].satisfied = false;
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        a.conditions[3].satisfied = false;
    }*/

}
