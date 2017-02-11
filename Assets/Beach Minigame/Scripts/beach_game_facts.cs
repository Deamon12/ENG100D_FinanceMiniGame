using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class beach_game_facts : MonoBehaviour {
    public string[] facts;
    private Text input;
	// Use this for initialization
	void Start () {
        input = this.gameObject.GetComponent<Text>();
        System.Random rnd = new System.Random();
        int choice = rnd.Next(0, (facts.Length-1));
        input.text = facts[choice];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
