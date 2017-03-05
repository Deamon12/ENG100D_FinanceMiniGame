using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollide : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter(Collision collision)
    {
        print("coin collision");
       
        
    }

    void OnTriggerEnter(Collider other)
    {

        print("coin on trigger");
        Destroy(this.gameObject);

        if(other.gameObject.tag == "Player")
        {
            ScoreText.runnerScore += 10;
        }

    }
    void OnTriggerStay(Collider other) { }
    void OnTriggerExit(Collider other) {
        //Destroy(this.gameObject);
    }

}
