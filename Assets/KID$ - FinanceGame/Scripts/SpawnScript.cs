using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] spawnObj;
    public float spawnTime = 1;

	// Use this for initialization
	void Start () {
		 Spawn(13.7f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn(float spacing)
    {
        Instantiate( spawnObj[0], new Vector3(transform.position.x + spacing, 0, 0), Quaternion.identity);// Random.Range (0, spawnObj.Length)]
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
