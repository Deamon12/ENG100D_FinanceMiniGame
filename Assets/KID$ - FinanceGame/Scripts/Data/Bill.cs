using System;

[Serializable]
public class Bill  {

    private string description;
    private float amount;
	private DateTime dueDate;
    private double payInterval = 24;        //in hours

    public Bill()
    {
        dueDate = (DateTime.Now).AddHours(payInterval);
    }

    public Bill(string desc, float amt)
    {
        this.description = desc;
        this.amount = amt;
        dueDate = (DateTime.Now).AddHours(payInterval);
    }

    public Bill(string desc, float amt, int interval)
    {
        this.description = desc;
        this.amount = amt;
        this.payInterval = interval;
        dueDate = (DateTime.Now).AddHours(payInterval);
    }

    public string getDescription()
    {
        return description;
    }

    public float getAmount()
    {
        return amount;
    }

    public void payBill()
    {
        dueDate = dueDate.AddHours(payInterval);
    }

    public DateTime getDueDate()
    {
        return dueDate;
    }

}
