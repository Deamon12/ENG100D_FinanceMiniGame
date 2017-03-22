﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public int earnSceneIndex; //in case this changes some day

    public GameObject bankEntriesScrollview;
    public GameObject billPayScrollview;

    public Slider energySlider;
    public Text energyText;

    public GameObject billPayAlertImage;

    public Text myBalanceDisplay;
	public Text transitText;

    public Button scrollviewChangeButton;
    public Button earnButton;
    
    private bool showBankEntries = true;

    // Use this for initialization
    void Start () {

        setBalanceInfo();

        bankEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

        scrollviewChangeButton.onClick.AddListener(changeView);
        earnButton.onClick.AddListener(earnClick);
    }
	
	// Update is called once per frame
    // These may not be the most efficient way to refresh UI
	void Update () {
        refreshEnergySlider();
        checkForBillPay();

        setBalanceInfo();

    }

    private void changeView()
    {
        showBankEntries = !showBankEntries;
        bankEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

		if (showBankEntries == true)
        {
            transitText.text = "Pay Bills";
            bankEntriesScrollview.BroadcastMessage("RefreshDisplay", SendMessageOptions.DontRequireReceiver);
        }

        else
        {
            transitText.text = "Bank";
            //bankEntriesScrollview.BroadcastMessage("RefreshDisplay", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void setBalanceInfo()
    {
        //Set balance header
        myBalanceDisplay.text = formatCurrencyString(GameManager.instance.getPlayerData().getBalance());
    }


    private void refreshEnergySlider()
    {
        if(GameManager.instance != null)
        {
            float energy = GameManager.instance.getPlayerData().getPlayerEnergy();
            energySlider.value = energy;
            energyText.text = energy + " / 100";
        }
        
    }

    private void earnClick()
    {

        if (GameManager.instance.getPlayerData().playerCanEarn())
        {
            GameManager.instance.getPlayerData().removePlayerEnergy();
            refreshEnergySlider();
            SceneManager.LoadScene(earnSceneIndex);
        }
        else
        {
            //TODO, show cannot play dialog
        }

    }
    
    private void checkForBillPay()
    {

        if (GameManager.instance.getPlayerData().isBillDue())
        {
            billPayAlertImage.SetActive(true);
        }
        else
        {
            billPayAlertImage.SetActive(false);
        }
    }

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }
    

}
