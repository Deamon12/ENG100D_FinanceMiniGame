using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour {

	private PlayerData player;

	private Component[] panels;

	public Text balance;

	public GameObject view1;
	public GameObject view2;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.getPlayerData();
		/*
		 * if(player.getGender() == Girl) {
		 * 	displaySet1()
		 * }
		 * else {
		 *  displaySet2()
		 * }
		 */

		view1.SetActive(true);
		view2.SetActive (false);

		balance.text = "Total: " + player.getBalance();

		panels = view1.GetComponents<upgradePanel>();

	}
	
	// Update is called once per frame
	void Update () {
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
