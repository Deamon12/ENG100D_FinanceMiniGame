using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//part of Grocery game
public class PointController : MonoBehaviour
{

    //Global boolean used to symbolize when a game-over state has been reached
    public static bool gameOver;
    public static bool YouWin;
    public static float points;

    public static Text overField;

    // Use this for initialization
    void Start()
    {

        gameOver = false;
        overField = GetComponent<Text>();
        overField.text = "";
        points = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {

            if (YouWin)
            {
                overField.text = "You win! Points: " + points;
            }
            else
            {
                overField.text = "Game Over! Points: " + points;
                if (RemainingMoney.totalRemainingMoneyForPoints > 0 && RemainingMoney.totalRemainingMoneyForPoints < 5)
                {
                    points -= 10;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 5 && RemainingMoney.totalRemainingMoneyForPoints < 10)
                {
                    points -= 60;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 10 && RemainingMoney.totalRemainingMoneyForPoints < 20)
                {
                    points -= 125;
                }
                else if (RemainingMoney.totalRemainingMoneyForPoints >= 20)
                {
                    points -= 260;
                }
                overField.text = "Game Over!\nYou overpaid by $" + RemainingMoney.totalRemainingMoneyForPoints + ". Please try again!";
            }
        }

    }

}