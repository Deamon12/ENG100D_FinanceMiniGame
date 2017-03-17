using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BillPanel : MonoBehaviour {

    public Text amountText;
    public Text descText;
	public Text dueDateText;

	//public float amount;
	public Bill theBill;
	public Button payButton;

	public String dueDate;

    public Image iconImage;

	// Use this for initialization
	void Start () {
		payButton.onClick.AddListener (paid);
	}

    public void Setup(Bill item, Sprite sprite)
    {
        
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = item.getAmount().ToString("C2", nfi);
		//this.amount = item.getAmount();
		this.theBill = item;
		this.dueDate = String.Format("{0:yyyy-MM-dd}", item.getPaidDateTime().AddDays(1));

        amountText.text = money;
        descText.text = "FOR " + item.getDescription();
		dueDateText.text = "DUE " + String.Format("{0:yyyy/MM/dd}", item.getPaidDateTime().AddDays(1));

        //iconImage.sprite = sprite;
        

    }

	private void paid() {
		this.theBill.setPaid (DateTime.Parse(this.dueDate));
		dueDateText.text = "DUE " + String.Format("{0:yyyy/MM/dd}", this.theBill.getPaidDateTime().AddDays(1));
		this.dueDate = String.Format("{0:yyyy-MM-dd}", this.theBill.getPaidDateTime().AddDays(1));

		float playerBalance = GameManager.instance.getPlayerData ().getBalance ();
		if (playerBalance < this.theBill.getAmount ()) {
			print ("Not enough balance...");
		} else {
			BankEntry newEntry = new BankEntry (0 - (this.theBill.getAmount ()), this.theBill.getDescription ());
			GameManager.instance.addBankEntry (newEntry);
			//BankScrollList.instance.updatePanels ();
		}
	}

}
