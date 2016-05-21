using UnityEngine;
using System.Collections;

public class beach_spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] trash = (GameObject[])Resources.LoadAll<GameObject>("beach_prefab");

        //spawn random small object
        int ranInt = Random.Range(0, trash.Length);
        GameObject sO = Instantiate(trash[ranInt]) as GameObject;
        sO.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
    }
	
	// Update is called once per frame
	void Update () {

	
	}
}
