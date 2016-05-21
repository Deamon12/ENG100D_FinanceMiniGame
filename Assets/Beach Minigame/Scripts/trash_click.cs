using UnityEngine;
using System.Collections;

public class trash_click : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnMouseDown() {
        Debug.Log("Mouse Down!");
        Destroy(this.gameObject);
    }

	// Update is called once per frame
	//void Update () {
	
	//}
}
