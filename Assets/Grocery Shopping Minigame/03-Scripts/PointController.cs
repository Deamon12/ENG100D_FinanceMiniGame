using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//part of Grocery game
public class PointController : MonoBehaviour
{

    //Global boolean used to symbolize when a game-over state has been reached
    public static bool gameOver;
    public static bool gameOverGrocery;
    public static bool isFinished;
    public static float points;

    public static Text overField;

    // Use this for initialization
    void Start()
    {

        gameOver = false;
        gameOverGrocery = false;
        isFinished = false;
        overField = GetComponent<Text>();
        overField.text = "";
        points = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            
            overField.text = " Points: " + points ;
            if (gameOverGrocery && isFinished == false)
            {
                if (RemainingMoney.totalRemainingMoneyForPoints > 0 && RemainingMoney.totalRemainingMoneyForPoints < 5)
                {
                    points -= 10;
                    overField.text = "\nYou overpaid by $" + RemainingMoney.totalRemainingMoneyForPoints + ".Points: " + points;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 5 && RemainingMoney.totalRemainingMoneyForPoints < 10)
                {
                    points -= 60;
                    overField.text = "\nYou overpaid by $" + RemainingMoney.totalRemainingMoneyForPoints + ".Points: " + points;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 10 && RemainingMoney.totalRemainingMoneyForPoints < 20)
                {
                    points -= 125;
                    overField.text = "\nYou overpaid by $" + RemainingMoney.totalRemainingMoneyForPoints + ".Points: " + points;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 20)
                {
                    points -= 260;
                    overField.text = "\nYou overpaid by $" + RemainingMoney.totalRemainingMoneyForPoints + ".Points: " + points;
                }
                isFinished = true;

            }

        }

    }

}