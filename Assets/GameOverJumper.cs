using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameOverJumper : MonoBehaviour {

    public Text currentAmountText;
    public Text coinCountText;
    public Text highestAmountText;

    public Text timePlayedText;


	// Use this for initialization
	void Awake () {
        print("game over started");
        int coinsThisGame = GameManager.instance.getPlayerData().getCoinsCollectedThisGame();
        float highestAmount = GameManager.instance.getPlayerData().getHighestAmountCollected();
        float currentAmount = ScoreText.runnerScore;

        if (currentAmount > highestAmount)
            highestAmount = currentAmount;

        coinCountText.text = coinsThisGame+"";
        currentAmountText.text = formatCurrencyString(currentAmount);
        highestAmountText.text = formatCurrencyString(highestAmount);

        timePlayedText.text = (int)(SideRunnerCharacterControl.timeStartedWith - SideRunnerCharacterControl.timeLeft)+"";

    }

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }


}
