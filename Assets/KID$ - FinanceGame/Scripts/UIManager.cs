using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public int earnSceneIndex;

    public GameObject bankEntriesScrollview;
    public GameObject billPayScrollview;

    public Slider energySlider;
    public Text energyText;

    public Text myBalanceDisplay;
	public Text transitText;

    public Button scrollviewChangeButton;
    public Button earnButton;

    //private float earnEnergyCost = 25f;
    private bool showBankEntries = true;

    // Use this for initialization
    void Start () {

        setBalanceInfo();
        //refreshEnergySlider();

        bankEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

        scrollviewChangeButton.onClick.AddListener(changeView);
        earnButton.onClick.AddListener(earnClick);
    }
	
	// Update is called once per frame
	void Update () {
        refreshEnergySlider();
    }

    private void changeView()
    {
        showBankEntries = !showBankEntries;
        bankEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

		if (showBankEntries == true)
			transitText.text = "Pay Bills";
		else
			transitText.text = "Bank";

        setBalanceInfo();

    }

    private void setBalanceInfo()
    {
        //Set balance header
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = GameManager.instance.getPlayerData().getBalance().ToString("C2", nfi);
        myBalanceDisplay.text = "" + money;
    }


    private void refreshEnergySlider()
    {
        float energy = GameManager.instance.getPlayerData().getPlayerEnergy();
        print(energy);
        energySlider.value = energy;
        energyText.text = energy + " / 100";
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

}
