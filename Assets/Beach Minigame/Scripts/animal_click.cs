﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class animal_click : MonoBehaviour {
    public bool trigger;
    public bool first;
    public bool locked;
    // Use this for initialization
    void Start() {

    }

    void OnMouseDown() {
        Debug.Log("Animal Mouse Down!");
        beach_spawn.heartsLeft--;
        GameObject holder = GameObject.Find("Canvas/HeartHolder");
        GameObject heart = holder.transform.GetChild(0).gameObject;
        Destroy(heart);
        if (beach_spawn.heartsLeft <= 0) {
            SceneManager.LoadScene("beach_end");
        }
        Destroy(this.gameObject);

    }
    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("OnTrigger");
        trigger = true;
        if (!locked && other.gameObject.GetComponent<animal_click>()) {

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
            //Debug.Log("Fixed Update");
            if (!this.gameObject.GetComponent<SpriteRenderer>().enabled) {
                locked = true;
            }
        }
        trigger = false;
        first = false;
    }
}
