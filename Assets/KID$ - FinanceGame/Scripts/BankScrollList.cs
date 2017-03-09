using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Globalization;
using System;

/*
[System.Serializable]
public class Transaction
{
    public string description;
    public Sprite icon;
    public float price = 5.00f;


    public Transaction() {}

    public Transaction(float price, string descr, Sprite icon)
    {
        this.price = price;
        this.description = descr;
        this.icon = icon;
        
    }
}
*/
public class BankScrollList : MonoBehaviour
{

    public Sprite depositSprite;
    public Sprite withdrawalSprite;
    
    public Transform contentPanel;
    public Text myBalanceDisplay;
    public SimpleObjectPool buttonObjectPool;


    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        
        //Set balance header
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = GameManager.instance.getPlayerData().getBalance().ToString("C2", nfi);
        myBalanceDisplay.text = "Balance: " + money;

        //Set scrollList dynamically
        AddButtons();
    }
    
    private void AddButtons()
    {
        //green - 1FD32DD3
        //red - 
        /*
        itemList.Add(new BankEntry(12.30f, "trans1", depositSprite));
        itemList.Add(new BankEntry(-2.40f, "trans2", withdrawalSprite));
        itemList.Add(new BankEntry(4f, "trans3", depositSprite));
        itemList.Add(new BankEntry(-7f, "trans4", withdrawalSprite));
        itemList.Add(new BankEntry(37f, "trans4", depositSprite));
        itemList.Add(new BankEntry(107f, "trans4", depositSprite));
        */
        
        List<BankEntry> itemList = GameManager.instance.getPlayerData().getBankEntryList();

        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.localScale = new Vector3(1.0F, 1.0f, 1.0f);
            newButton.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            newButton.transform.SetParent(contentPanel, false);                 //The bool on this line saved my life

            if (itemList[i].getAmount() < 0)
            {
                itemList[i].setSprite(withdrawalSprite);
            }else
            {
                itemList[i].setSprite(depositSprite);
            }

            Bank_panel_script samplePanel = newButton.GetComponent<Bank_panel_script>();
            samplePanel.Setup(itemList[i]);
        }
    }
    
}