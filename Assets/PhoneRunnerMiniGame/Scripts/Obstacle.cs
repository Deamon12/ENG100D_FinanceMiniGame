using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

	public Rigidbody2D obstacle;
	private float box_width;
	private float box_height;
	private Vector2 move = new Vector2(-0.15f, 0);
	public static float DESPAWN_POSX = -11.5f;
   // public static float CAMERA_LEFT_EDGE;
	private MainController controller;

	// Use this for initialization
	public void initialize(MainController controller)
	{
		this.controller = controller;
	}

	void Start () {
	   // CAMERA_LEFT_EDGE = Camera.main.transform.position.y - Camera.main.orthographicSize;
		obstacle = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update(){
		if (this.transform.position.x < -14)
		{
			this.remove();
		}
	}

	void FixedUpdate()
	{
		obstacle.MovePosition(obstacle.position + move);
	}

	void remove()
	{
		controller.removeObstacle(this);        
	}
}
