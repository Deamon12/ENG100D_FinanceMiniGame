using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RemainingMoney : MonoBehaviour {
    public Text remainder;
    public static int moneyP;
    public static int totRemMoney;
	// Use this for initialization
	void Start () {
	    remainder = GetComponent<Text>();
        totRemMoney = CashierText.totalPrice;
        moneyP = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (PointController.gameOver == false)
            updateMoney();
 
	}
    private void updateMoney()
    {
        totRemMoney = CashierText.totalPrice - moneyP;
        if (totRemMoney < 0 )
        {
            totRemMoney = 0;
        }
        remainder.text = "Need to Pay: $" + totRemMoney;
        if (totRemMoney < 1 && TimerController.timer > 0)
        {
            PointController.gameOver = true;
        }
    }
}
