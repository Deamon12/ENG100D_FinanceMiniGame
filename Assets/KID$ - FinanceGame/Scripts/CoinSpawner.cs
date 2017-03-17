using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coinObj;

    public int maxCoins = 5;
    public int minCoins = 2;

    private float[] coinHeights = {15f, 5f};
    //public float maxCoinHeight;
    //public float minCoinHeight;

    private Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));

    // Use this for initialization
    void Start () {

        //float width = GetComponent<Renderer>().bounds.size.x;

        //Get # of coins to spawn
        int numCoinsToSpawn = Random.Range(minCoins, maxCoins);

        //print("Collider: "+GetComponent<Collider>().bounds.size.x);
        //print("Renderer: "+GetComponent<Renderer>().bounds.size.x);

        float distanceBetween = GetComponent<Renderer>().bounds.size.x / numCoinsToSpawn;

        print("distanceBetween: " + distanceBetween);

        print("transform.position.x: "+transform.position.x);

        float transPos = (transform.position.x);

        for (int a = 0; a < numCoinsToSpawn; a++)
        {
            float location = transPos + (distanceBetween * a); //transform.position.x +
            Instantiate(coinObj, new Vector3(location, coinHeights[Random.Range(0, coinHeights.Length)], -8), rotation);
        }


    }
	
    
	
}
