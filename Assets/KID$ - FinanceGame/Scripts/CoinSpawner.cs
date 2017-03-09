using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coinObj;

    public int maxCoins = 5;
    public int minCoins = 2;

    public float maxCoinHeight;
    public float minCoinHeight;

    public Quaternion rotation = Quaternion.Euler(new Vector3(90, 0, 0));

    // Use this for initialization
    void Start () {

        float width = GetComponent<Renderer>().bounds.size.x;

        //Get # of coins to spawn
        int numCoinsToSpawn = Random.Range(minCoins, maxCoins);

        //print("Collider: "+GetComponent<Collider>().bounds.size.x);
        //print("Renderer: "+GetComponent<Renderer>().bounds.size.x);

        float distanceBetween = GetComponent<Renderer>().bounds.size.x / numCoinsToSpawn;

        print("Put coin every " + distanceBetween + " units.");


        for(int a = 0; a < numCoinsToSpawn; a++)
        {
            float location = transform.position.x + (distanceBetween * a);
            Instantiate(coinObj, new Vector3(location, 15, -8), rotation); //transform.position.z
        }


    }
	
    
	
}
