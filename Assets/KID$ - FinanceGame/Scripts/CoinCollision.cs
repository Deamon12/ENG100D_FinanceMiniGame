﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {

	

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            ScoreText.runnerScore += 0.10f; //TODO variety to coins
            SideRunnerCharacterControl.coinsCollectedThisGame += 1;
            GameManager.instance.getPlayerData().addCoinToCount();
        }

    }
}
