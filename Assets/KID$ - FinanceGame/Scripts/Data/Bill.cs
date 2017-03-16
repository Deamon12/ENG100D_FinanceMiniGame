using System;

[Serializable]
public class Bill  {

    private string description;
    private float amount;
    private DateTime lastPaid;

    public Bill()
    {
        lastPaid = DateTime.Now;
    }

    public Bill(string desc, float amt)
    {
        this.description = desc;
        this.amount = amt;
        lastPaid = DateTime.Now;
    }

    public string getDescription()
    {
        return description;
    }

    public float getAmount()
    {
        return amount;
    }

    public void setPaid(DateTime date)
    {
        lastPaid = date;
    }

    public DateTime getPaidDateTime()
    {
        return lastPaid;
    }

}
