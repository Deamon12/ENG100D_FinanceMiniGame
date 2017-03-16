using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Globalization;
using System;


public class BillPayScrollList : MonoBehaviour
{

    public Sprite depositSprite;
    public Sprite withdrawalSprite;

    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;


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

    private void AddPanels()
    {

        List<Bill> itemList = GameManager.instance.getPlayerData().getBillList();
        
        for (int i = itemList.Count - 1; i >= 0; i--)
        {

            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.localScale = new Vector3(1.0F, 1.0f, 1.0f);
            newButton.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            newButton.transform.SetParent(contentPanel, false);                 //The bool on this line saved my life

            BillPanel samplePanel = newButton.GetComponent<BillPanel>();    //Script attached to prefab object
            samplePanel.Setup(itemList[i], withdrawalSprite);

        }
    }

}