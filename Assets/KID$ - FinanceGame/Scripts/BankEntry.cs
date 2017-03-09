using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BankEntry {

    private float amount;
    private string description;
    private Sprite iconSprite;

    public BankEntry(float amount, string desc)
    {
        this.amount = amount;
        this.description = desc;
    }

    public float getAmount()
    {
        return amount;
    }

    public string getDescription()
    {
        return description;
    }

    public void setSprite(Sprite sprite)
    {
        this.iconSprite = sprite;
    }

    public Sprite getSprite()
    {
        return iconSprite;
    }

}
