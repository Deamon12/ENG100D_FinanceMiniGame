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
	
}
