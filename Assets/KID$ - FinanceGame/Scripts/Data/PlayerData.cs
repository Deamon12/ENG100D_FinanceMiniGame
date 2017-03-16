using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData {

    
    private List<Bill> billList;
    private List<Achievement> achieveEarnedList;
    private List<Upgrade> upgradeEarnedList;
    private List<BankEntry> bankEntryList;
    
    private DateTime creationDate;

    public PlayerData()
    {
        creationDate = DateTime.Now;
        billList = new List<Bill>();
        achieveEarnedList = new List<Achievement>();
        upgradeEarnedList = new List<Upgrade>();
        bankEntryList = new List<BankEntry>();

        billList.Add(new Bill("Phone", 5.0f));
    }

    public float getBalance()
    {
        float total = 0f;

        foreach(BankEntry entry in bankEntryList)
        {
            total += entry.getAmount();
        }
        
        return total;
    }

    public List<BankEntry> getBankEntryList()
    {
        return bankEntryList;
    }

    public List<Bill> getBillList()
    {
        return billList;
    }

    public void addBankEntry(BankEntry entry)
    {
        if(entry.getAmount() != 0)  //omit 0 entries?
            bankEntryList.Add(entry);
    }

    public String toString() //For debug
    {
        return " billList size: " + billList.Count + "\n" +
            "achieveEarnedList: :" + achieveEarnedList.Count + "\n" +
            "upgradeEarnedList: :" + upgradeEarnedList.Count + "\n" +
            "bankEntryList: :" + bankEntryList.Count;
}
	
}
