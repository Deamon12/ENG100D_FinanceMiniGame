using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject[] objList;

    private float obstacleY = 2.42f;
    private float obstacleZ = -8;

    public int maxObjs = 2;
    public int minObjs = 0;

    //public Quaternion rotation = Quaternion.Euler(new Vector3(90, 0, 0));

    // Use this for initialization
    void Start () {

        float width = GetComponent<Renderer>().bounds.size.x;

        //Get # of objs to spawn
        int numObstaclesToSpawn = Random.Range(minObjs, maxObjs);

        //print("Collider: "+GetComponent<Collider>().bounds.size.x);
        //print("Renderer: "+GetComponent<Renderer>().bounds.size.x);

        float distanceBetween = GetComponent<Renderer>().bounds.size.x / numObstaclesToSpawn;

       // print("Put objs every " + distanceBetween + " units.");


        for(int a = 0; a < numObstaclesToSpawn; a++)
        {
            float location = transform.position.x + (distanceBetween * a);
            Instantiate(objList[Random.Range(0, objList.Length)], new Vector3(location, obstacleY, obstacleZ), Quaternion.identity);
        }


    }
	
    
	
}
