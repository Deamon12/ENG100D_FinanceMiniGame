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
    public Text energyCountdown;
    public ParticleSystem energySparkle;

    public GameObject billPayAlertImage;

    public Text myBalanceDisplay;
	public Text transitText;

    public Button scrollviewChangeButton;
	public Image upgImg;
	public Image achImg;
    public Button earnButton;
	public Button achButton;
	public Button upgButton;
	public Image RibbonAlert;

    public Button exitButton;


    private bool showBankEntries = true;

    // Use this for initialization
    void Start () {

        setBalanceInfo();

		if (GameManager.instance.getPlayerData ().hasAvailableReward ()) 
			RibbonAlert.GetComponent<Image> ().enabled = true;

        bankEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

        scrollviewChangeButton.onClick.AddListener(changeView);
        earnButton.onClick.AddListener(earnClick);
        exitButton.onClick.AddListener(exitGame);

    }

    // Update is called once per frame
    // These may not be the most efficient way to refresh UI
    void Update () {
        refreshEnergySlider();
        checkForBillPay();

		if (GameManager.instance.getPlayerData ().isBillDue ()) {
			achButton.GetComponent<Button> ().enabled = false;
			upgImg.GetComponent<Image> ().enabled = true;
			upgButton.GetComponent<Button> ().enabled = false;
			achImg.GetComponent<Image> ().enabled = true;

		}
		else {
			achButton.GetComponent<Button> ().enabled = true;
			upgImg.GetComponent<Image> ().enabled = false;
			upgButton.GetComponent<Button> ().enabled = true;
			achImg.GetComponent<Image> ().enabled = false;
		}

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
            DateTime lastEnergyUpdate = GameManager.instance.getPlayerData().getLastEnergyGain();
            TimeSpan timeBetween = lastEnergyUpdate.AddMinutes(1) - DateTime.Now ;              //countdown


            energySlider.value = energy;
            energyText.text = energy + " / 100";

            if (energy < 100)
            {
                energyCountdown.text = timeBetween.Seconds + " secs";

                if(energySparkle.isStopped)
                    energySparkle.Play();
            }
            else
            {
                //print("energy is full");
                energyCountdown.text = "";

                if (energySparkle.isPlaying)
                    energySparkle.Stop();
            }
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
            GameManager.instance.showErrorDialog("Not enough energy");
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
    
    private void exitGame()
    {
        print("exiting...");
        Application.Quit();
    }
}
