using UnityEngine;
using System.Collections;
using System;

public class Obstacle : MonoBehaviour {
    private float box_width;
    private float box_height;
    public static float DESPAWN_POSX = -11.5f;
    public static float CAMERA_LEFT_EDGE;
    private SpawnObstacle controller;
    // Use this for initialization
    public void initialize(SpawnObstacle controller)
    {
        this.controller = controller;
    }

	void Start () {
        CAMERA_LEFT_EDGE = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update () {
        if (this.transform.position.x < -11.1)
        {
            this.remove();
        }
    }

    void remove()
    {
        controller.removeObstacle(this);        
    }
}
