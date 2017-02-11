﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneIcon : MonoBehaviour {

	public Rigidbody2D phoneIcon;
	private Vector2 move = new Vector3(-0.15f,0,0);
	public float value = 25;
	private MainController controller;


	// Use this for initialization
	public void initialize(MainController controller)
	{
		this.controller = controller;
	}
	// Use this for initialization
	void Start () {
		phoneIcon = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update(){
		if (this.transform.position.x < -11.1)
		{
			this.remove();
		}
	}

	void FixedUpdate()
	{
		phoneIcon.MovePosition(phoneIcon.position + move);
	}

	void remove()
	{
		controller.removePhoneIcon(this);
	}
}
