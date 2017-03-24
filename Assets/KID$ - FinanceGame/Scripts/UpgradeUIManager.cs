﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour {

	private PlayerData player;
	private int gender = 1;

	private upgradePanel[] panels;
	/*private Material[] low;
	private Material[] mid;
	private Material[] high;*/
	//changing material is gameObject.renderer.material = 

	public Text balance;

	public GameObject view1;
	public GameObject view2;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.getPlayerData();
		if(gender == 1) {
			displaySet1();
		}
		else {
			displaySet2();
		}
		 

		displaySet2();

		balance.text = "Total: $" + player.getBalance();

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

	private void setUpgrades() {
		for (int i = 0; i < panels.Length; i++) {
			int result = 0;
			int.Parse(panels[i].price, out result);
			if (result < player.getBalance ()) {
				panels[i].buy.enabled = false;
			} else {
				panels[i].buy.onClick.AddListener(buyItem);
			}
		}
	}

	private void buyItem() {
		
	}

}
