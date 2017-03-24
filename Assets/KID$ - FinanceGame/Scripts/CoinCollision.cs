using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {

	

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoreText.runnerScore += 0.10f; //TODO variety to coins
            GameManager.instance.getPlayerData().addCoinToCount();
            Destroy(this.gameObject);
        }

    }
}
