using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;
using System;

public class ScoreText : MonoBehaviour {

    public static float runnerScore;
    Text text;

	void Awake() {
        text = GetComponent<Text>();
        runnerScore = 0;
	}

	// Update is called once per frame
	void LateUpdate() {

        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        String money = runnerScore.ToString("C2", nfi);
        text.text = money;
    }
}
