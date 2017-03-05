﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        Destroy(other.gameObject);

    }
    void OnTriggerStay(Collider other) { }
    void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        //Destroy(other.gameObject);
    }
}
