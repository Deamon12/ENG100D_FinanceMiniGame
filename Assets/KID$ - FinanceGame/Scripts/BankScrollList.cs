using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Globalization;
using System;



/*
function Start()
{
   GetComponent(SpriteRenderer).sprite = spriteImage;
}*/

[System.Serializable]
public class Transaction
{
    public string description;
    public Sprite icon;
    public float price = 5.00f;


    public Transaction()
    {

    }

    public Transaction(float price, string descr, Sprite icon)
    {
        this.price = price;
        this.description = descr;
        this.icon = icon;
        
    }
}

public class BankScrollList : MonoBehaviour
{

    public Sprite depositSprite;
    public Sprite withdrawalSprite;

    public List<Transaction> itemList;
    public Transform contentPanel;
    public Text myBalanceDisplay;
    public SimpleObjectPool buttonObjectPool;
    public float balanceAmount = 20f;


    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    void RefreshDisplay()
    {

        //TODO: move this?
        
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = balanceAmount.ToString("C2", nfi);
        myBalanceDisplay.text = "Balance: " + money;


        AddButtons();
    }
    
    private void AddButtons()
    {
        //green - 1FD32DD3
        //red - 
        itemList.Add(new Transaction(12.30f, "trans1", depositSprite));
        itemList.Add(new Transaction(-2.40f, "trans2", withdrawalSprite));
        itemList.Add(new Transaction(4f, "trans3", depositSprite));
        itemList.Add(new Transaction(-7f, "trans4", withdrawalSprite));
        itemList.Add(new Transaction(37f, "trans4", depositSprite));
        itemList.Add(new Transaction(107f, "trans4", depositSprite));

        /*
        if (price < 0)
        {
            icon = BankScrollList.withdrawSprite;
        }*/

        for (int i = 0; i < itemList.Count; i++)
        {
            //Transaction item = new Transaction(12.30f, "trans");
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.localScale = new Vector3(1.0F, 1.0f, 1.0f);
            newButton.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            newButton.transform.SetParent(contentPanel, false);                 //The bool on this line saved my life


            Bank_panel_script samplePanel = newButton.GetComponent<Bank_panel_script>();
            samplePanel.Setup(itemList[i]);
        }
    }
    
}