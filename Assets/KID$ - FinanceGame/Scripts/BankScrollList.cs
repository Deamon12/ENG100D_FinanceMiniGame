using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Globalization;
using System;


public class BankScrollList : MonoBehaviour
{

    public Sprite depositSprite;
    public Sprite withdrawalSprite;
    
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

	public static BankScrollList instance = null;


    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        //Set scrollList dynamically
        AddPanels();
    }

	public void updatePanels()
	{
		AddPanels();
	}
    
    private void AddPanels()
    {
       
        List<BankEntry> itemList = GameManager.instance.getPlayerData().getBankEntryList();

        for (int i = itemList.Count-1; i >= 0; i--)
        {
            
            if (itemList[i].getAmount() < 0)
            {
                GameObject newButton = buttonObjectPool.GetObject();
                newButton.transform.localScale = new Vector3(1.0F, 1.0f, 1.0f);
                newButton.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                newButton.transform.SetParent(contentPanel, false);                 //The bool on this line saved my life

                BankPanel samplePanel = newButton.GetComponent<BankPanel>();
                samplePanel.Setup(itemList[i], withdrawalSprite);
            }
            if (itemList[i].getAmount() > 0)
            {
                GameObject newButton = buttonObjectPool.GetObject();
                newButton.transform.localScale = new Vector3(1.0F, 1.0f, 1.0f);
                newButton.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                newButton.transform.SetParent(contentPanel, false);                 //The bool on this line saved my life

                BankPanel samplePanel = newButton.GetComponent<BankPanel>();
                samplePanel.Setup(itemList[i], depositSprite);
            }
            else //ignore 0's
            {
                
            }
            
        }
    }
    
}