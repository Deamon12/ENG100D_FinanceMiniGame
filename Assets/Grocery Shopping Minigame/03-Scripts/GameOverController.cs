﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public static float point;
    public static Text result;
	// Use this for initialization
	void Start () {
        point = PointController.points;
        result = GetComponent<Text>();
       
	}
	
	// Update is called once per frame
	void Update () {
        result.text = "Congratulations! Your points is " + point + ". Thanks to you with all the money I saved, I can now afford a new dentist. ";
    }

}
