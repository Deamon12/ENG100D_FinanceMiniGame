using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {
    
    public GameObject[] spawnObj;
    public float spawnTime = 1;
    private float objWidth;

    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        //Get current ground coords, not player coords.
        objWidth = spawnObj[0].GetComponent<Renderer>().bounds.size.x;

        //print("current pos: " + transform.position.x);
        //print("objWidth: " + objWidth);

        float spacing = (int)transform.position.x + (int)(objWidth);  //For some reason cast is needed to reduce small changes

        //print("position: " + spacing);
        Instantiate( spawnObj[Random.Range(0, spawnObj.Length)], new Vector3(spacing, 0, 0), Quaternion.identity);
    }
    
    //Destroy
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay(Collider other) {}

    //Spawn
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Spawner")
        {
            Spawn();
        }
        
    }

}
