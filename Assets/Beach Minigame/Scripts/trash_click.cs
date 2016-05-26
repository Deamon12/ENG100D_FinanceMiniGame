using UnityEngine;
using System.Collections;

public class trash_click : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnMouseDown() {
        Debug.Log("Trash Mouse Down!");
        beach_spawn.numTrash--;
        if (beach_spawn.numTrash == 0) {
            Debug.Log("Next Level!");
        }
        Destroy(this.gameObject);
    }

	// Update is called once per frame
	//void Update () {
	
	//}
}
