using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour {
    
	//? private Component[] panels;
	public Text balance;

	public GameObject girlView;
	public GameObject boyView;

	// Use this for initialization
	void Start () {

        balance.text = formatCurrencyString(GameManager.instance.getPlayerData().getBalance());
        //? panels = girlView.GetComponents<upgradePanel>();

        if (GameManager.instance.getPlayerData().getGender() == 1) //female = 1
        {
            showGirlView();
        }
        else
        {
            showBoyView();
        }
		

	}
	
	// Update is called once per frame
	void Update () {
        

	}

	private void showGirlView() {
        girlView.SetActive(true);
        boyView.SetActive(false);
	}

	private void showBoyView() {
        girlView.SetActive(false);
        boyView.SetActive(true);
	}

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }

}
