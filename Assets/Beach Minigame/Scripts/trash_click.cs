using UnityEngine;
using System.Collections;

public class trash_click : MonoBehaviour {
    public bool trigger;
    public bool first;
    public bool locked;
    // Use this for initialization
    void Start () {
        first = true;
        locked = false;
    }
	
    void OnMouseDown() {
        Debug.Log("Trash Mouse Down!");
        beach_spawn.numTrash--;
        if (beach_spawn.numTrash == 0) {
            Debug.Log("Next Level!");
        }
        Destroy(this.gameObject);
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("OnTrigger");
        trigger = true;
        if (!locked && other.gameObject.GetComponent<trash_click>()) {

            // Height and width of camera - used to determine where to spawn
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            float newLocY = Random.Range(Camera.main.transform.position.y - this.GetComponent<SpriteRenderer>().bounds.size.y, Camera.main.transform.position.y - camHeight);
            float newLocX = Random.Range(Camera.main.transform.position.x - camWidth, Camera.main.transform.position.x + camWidth);

            Vector3 randomLoc = new Vector3(newLocX, newLocY, 0.0f);

            this.transform.position = randomLoc;    
        }
    }

    void LateUpdate() {
        if (!trigger && !first) {
            Debug.Log("Fixed Update");
            if (!this.gameObject.GetComponent<SpriteRenderer>().enabled) {
                locked = true;
            }
        } 
        trigger = false;
        first = false;
    }
}
