using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject bankeEntriesScrollview;
    public GameObject billPayScrollview;

    public Text myBalanceDisplay;

    public Button scrollviewChangeButton;

    private bool showBankEntries = true;

    // Use this for initialization
    void Start () {

        setBalanceInfo();

        bankeEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);

        scrollviewChangeButton.onClick.AddListener(changeView);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void changeView()
    {
        showBankEntries = !showBankEntries;
        bankeEntriesScrollview.SetActive(showBankEntries);
        billPayScrollview.SetActive(!showBankEntries);
        
    }

    private void setBalanceInfo()
    {
        //Set balance header
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = GameManager.instance.getPlayerData().getBalance().ToString("C2", nfi);
        myBalanceDisplay.text = "" + money;
    }

}
