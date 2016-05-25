using UnityEngine;
using System.Collections;

public class animal_click : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    void OnMouseDown() {
        Debug.Log("Animal Mouse Down!");
        Destroy(this.gameObject);
    }

 //   // Update is called once per frame
 //   void Update () {
	
	//}
}
