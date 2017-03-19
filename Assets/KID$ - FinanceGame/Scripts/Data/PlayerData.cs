using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    
    private List<Bill> billList;
    private List<Achievement> achieveEarnedList;
    private List<Upgrade> upgradeEarnedList;
    private List<BankEntry> bankEntryList;

    private float playerEnergy;

    private float playerEnergyCost = 25f;
    private float playerEnergyGain = 5f;

    private DateTime creationDate;
    private DateTime lastEnergyGain;
    private DateTime lastEnergyRemove;

    private int coinsCollectedTotal;
    private int coinsCollectedThisGame;

    public PlayerData()
    {
        creationDate = DateTime.Now;
        billList = new List<Bill>();
        achieveEarnedList = new List<Achievement>();
        upgradeEarnedList = new List<Upgrade>();
        bankEntryList = new List<BankEntry>();

        coinsCollectedTotal = 0;
        playerEnergy = 100;
        lastEnergyGain = DateTime.Now;
        billList.Add(new Bill("Phone", 2.0f));
    }

    public float getBalance()
    {
        float total = 0f;

        foreach (BankEntry entry in bankEntryList)
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
        if (entry.getAmount() != 0)  //omit 0 entries?
            bankEntryList.Add(entry);
    }

    public float getPlayerEnergy()
    {
        return playerEnergy;
    }

    public bool playerCanEarn()
    {
        if ((playerEnergy - playerEnergyCost) > 0)
        {
            return true;
        }
        return false;
    }

    public void removePlayerEnergy()
    {
        playerEnergy -= (playerEnergyCost);
        if (playerEnergy < 0) { playerEnergy = 0; }

        //Just came from 100, so refresh last energy gain to start regain
        if (playerEnergy + playerEnergyCost == 100)
        {
            lastEnergyGain = DateTime.Now;
        }
    }

    public void addPlayerEnergy()
    {
        playerEnergy += (playerEnergyGain);
        if (playerEnergy > 100) { playerEnergy = 100; }
        lastEnergyGain = DateTime.Now;
    }
    
    public DateTime getLastEnergyGain()
    {
        return lastEnergyGain;
    }

    public void setLastEnergyGain(DateTime datetime)
    {
        lastEnergyGain = datetime;
    }


    public void addCoinToCount()
    {
        coinsCollectedThisGame += 1;
        coinsCollectedTotal += 1;
    }




    public String toString() //For debug
    {
        return " billList size: " + billList.Count + "\n" +
            "achieveEarnedList: :" + achieveEarnedList.Count + "\n" +
            "upgradeEarnedList: :" + upgradeEarnedList.Count + "\n" +
            "bankEntryList: :" + bankEntryList.Count;
    }
    

}
