using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Esine : IInteractive {

    bool used;
    bool picked;
    int available;

    void IInteractive.ReactionNotYet()
    {
        throw new NotImplementedException();
    }

    void IInteractive.ReactionNow()
    {
        throw new NotImplementedException();
    }

    void IInteractive.ReactionTooLate()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
