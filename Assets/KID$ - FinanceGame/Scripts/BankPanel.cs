using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BankPanel : MonoBehaviour {

    public Text price;
    public Image iconImage;
    public Text descText;

	// Use this for initialization
	void Start () {
		
	}

    public void Setup(BankEntry item, Sprite sprite)
    {
        price.text = formatCurrencyString(item.getAmount());
        iconImage.sprite = sprite;
        descText.text = item.getDescription();

    }

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }


}
