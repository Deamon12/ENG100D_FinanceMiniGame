using System;

[System.Serializable]
public class BankEntry {

    private float amount;
    private string description;
    private DateTime date;

    public BankEntry(float amount, string desc)
    {
        this.amount = amount;
        this.description = desc;
    }

    public BankEntry(float amount, string desc, DateTime date)
    {
        this.amount = amount;
        this.description = desc;
        this.date = date;
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
