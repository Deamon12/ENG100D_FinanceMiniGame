using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BankEntry {

    private float amount;
    private string description;

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
}
