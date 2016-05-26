using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//part of Cashier game
public class RemainingMoney : MonoBehaviour 
{
    public Text remainder;    //this is the text for the remaining money
    public static int moneyP;    //this is the total money that is used
    public static int totRemMoney; //this is the total remaining money
	public static int totalRemainingMoneyForPoints;

	// Use this for initialization
	void Start () 
	{
	    remainder = GetComponent<Text>();
        totRemMoney = CashierText.totalPrice;
        moneyP = 0;

		totalRemainingMoneyForPoints = totRemMoney;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (PointController.gameOver == false) 
		{
			CalculateNumberOfPoints();

			updateMoney();

			//CalculateNumberOfPoints()
			//PointController.points = twenty.NumberOfTwentiesUsed * 260 + ten.NumberTensUsed * 125 + five.NumberOfFivesUsed * 60 + one.NumberOfOnesUsed * 10;
		}
	}
    private void updateMoney()
    {
        totRemMoney = CashierText.totalPrice - moneyP;  //moneyP is the total value of all of the dollar bills clicked
		totalRemainingMoneyForPoints = CashierText.totalPrice - moneyP;

        if (totRemMoney < 0 )
        {
            totRemMoney = 0;
        }

        remainder.text = "Need to Pay: $" + totRemMoney;
		if (totalRemainingMoneyForPoints < 1 && TimerController.timer > 0)
        {
            PointController.YouWin = true;
			//PointController.gameOver = true;

			//CalculateNumberOfPoints ();
        }
    }

	void CalculateNumberOfPoints()
	{
		PointController.points = twenty.NumberOfTwentiesUsed * 260 + ten.NumberTensUsed * 125 + five.NumberOfFivesUsed * 60 + one.NumberOfOnesUsed * 10;
	}
}
