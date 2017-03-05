using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {
    

    public float spawnTime = 3f;
    public GameObject coinObj;
    public float spaceFromCharacter = 20f;
    public Quaternion rotation = Quaternion.Euler(new Vector3(90, 0, 0));

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Spawn()
    {
        Instantiate(coinObj, new Vector3(transform.position.x + spaceFromCharacter, 15, transform.position.z), rotation);
    }


}
