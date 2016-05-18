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
        totRemMoney = CashierText.totalPrice - moneyP;
        remainder.text = "Need to Pay: $" + totRemMoney;
        if(totRemMoney < 1 && TimerController.timer > 0)
        {
            PointController.gameOver = true;
        }
	}
}
