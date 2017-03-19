using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour {

	private PlayerData player;

	public Button view1Button;
	public Button view2Button;

	public GameObject view1;
	public GameObject view2;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.getPlayerData();
		//player.getGender

		view1.SetActive(true);
		view2.SetActive (false);

		//view1Button.onClick.AddListener(displaySet1);
		//view2Button.onClick.AddListener(displaySet2);
	}
	
	// Update is called once per frame
	void Update () {
		view1Button.onClick.AddListener(displaySet1);
		view2Button.onClick.AddListener(displaySet2);
	}

	private void displaySet1() {
		view1.SetActive(true);
		view2.SetActive(false);
	}

	private void displaySet2() {
		view1.SetActive(false);
		view2.SetActive(true);
	}

}
