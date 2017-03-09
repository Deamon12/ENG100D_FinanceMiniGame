using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            ScoreText.runnerScore += 10;
        }

    }
}
