using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundScript : MonoBehaviour {

    public GameObject[] spawnObj;
    public float spawnTime = 1;

	// Use this for initialization
	void Start () {
		// Spawn(-5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn(float spacing)
    {
        Instantiate( spawnObj[Random.Range(0, spawnObj.Length)], new Vector3(transform.position.x + spacing, 0, 0), Quaternion.identity);// Random.Range (0, spawnObj.Length)]
    }
    
    void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
    }
    void OnTriggerStay(Collider other) {}
    void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        Spawn(24.5f);
    }

}
