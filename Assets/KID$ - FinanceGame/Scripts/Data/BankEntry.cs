using System;

[System.Serializable]
public class BankEntry {

    private float amount;
    private string description;
    private DateTime date;
	private bool fromReward;

    public BankEntry(float amount, string desc)
    {
        this.amount = amount;
        this.description = desc;
		fromReward = false;
    }

	public BankEntry(float amount, string desc, DateTime date)
    {
        this.amount = amount;
        this.description = desc;
        this.date = date;
		fromReward = false;
    }

	public BankEntry(float amount, string desc, bool isBonus)
	{
		this.amount = amount;
		this.description = desc;
		fromReward = isBonus;
	}

    public float getAmount()
    {
        return amount;
    }

    public string getDescription()
    {
        return description;
    }

	public bool isFromReward()
	{
		return fromReward;
	}

}
