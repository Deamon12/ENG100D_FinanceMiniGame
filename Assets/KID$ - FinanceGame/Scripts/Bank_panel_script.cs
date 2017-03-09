﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Bank_panel_script : MonoBehaviour {

    public Text price;
    public Image iconImage;

	// Use this for initialization
	void Start () {
		
	}

    public void Setup(BankEntry item)
    {
        
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = item.getAmount().ToString("C2", nfi);
        price.text = money;
        iconImage.sprite = item.getSprite();
        //TODO: description

    }

}
