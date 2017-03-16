using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BillPanel : MonoBehaviour {

    public Text amountText;
    public Text descText;
    public Image iconImage;

	// Use this for initialization
	void Start () {
		
	}

    public void Setup(Bill item, Sprite sprite)
    {
        
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = item.getAmount().ToString("C2", nfi);

        amountText.text = money;
        descText.text = item.getDescription();

        //iconImage.sprite = sprite;
        

    }

}
