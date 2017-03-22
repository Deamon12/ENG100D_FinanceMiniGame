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
    public Button payButton;

    private Bill theBill;

    private Color inactiveText = new Color(0, 0, 0, .25f);
    private Color activeText = new Color(255, 255, 255, 1f);
    private Color overDueText = new Color(255, 255, 255, 1f);

    private int billIndex;

    // Use this for initialization
    void Start () {
		payButton.onClick.AddListener (payBillButton);
	}

    void Update()
    {


        if(theBill != null)
        {
            dueDateText.text = getTimeBetween(theBill.getDueDate());

            if (theBill.getDueDate().Subtract(DateTime.Now).Hours < 0)          //overdue?
            {
                payButton.GetComponentInChildren<Text>().color = overDueText;
                payButton.interactable = true;
            }
            else if (theBill.getDueDate().Subtract(DateTime.Now).Hours < 3)       //Able to pay bill within 3 hours of dueDate
            {
                //Enable pay button
                payButton.GetComponentInChildren<Text>().color = activeText;
                payButton.interactable = true;
            }
            else
            {
                //payButton.GetComponentInChildren<Text>().enabled = false;
                payButton.GetComponentInChildren<Text>().color = inactiveText;
                payButton.interactable = false;
                
            }

        }


    }

    
    public void Setup(Bill item, Sprite sprite, int index)
    {
        theBill = item;
        billIndex = index;
        String money = formatCurrencyString(item.getAmount());
        amountText.text = money;
        descText.text = item.getDescription();
    }

	private void payBillButton() {
      
		float playerBalance = GameManager.instance.getPlayerData().getBalance();

		if (playerBalance < theBill.getAmount()) {
            GameManager.instance.showErrorDialog("Not Enough Money");
		} else {
            
			//BankEntry newEntry = new BankEntry (-theBill.getAmount(), theBill.getDescription(), DateTime.Now);
            //GameManager.instance.addBankEntry(newEntry);
            GameManager.instance.payBill(billIndex);

        }
	}

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }


    private String getTimeBetween(DateTime dueDate)
    {

        TimeSpan elapsed = (dueDate - DateTime.Now);

        string result = "";
        if (elapsed.Days > 0)
            result += elapsed.Days + ":";
        if(elapsed.Hours > 0)
            result += elapsed.Hours + ":";
        if(elapsed.Minutes > 0)
            result += elapsed.Minutes + ":";
        if (elapsed.Seconds > 0)
            result += elapsed.Seconds;

        return result;
    }
}
