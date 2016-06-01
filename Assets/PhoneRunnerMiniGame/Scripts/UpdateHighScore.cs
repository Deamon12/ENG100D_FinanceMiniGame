using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    void Start()
    {
        Debug.Log("Inside of Start in UpdateHighScore");
        float highScore = (float) PlayerPrefs.GetFloat("phone_runner_high_score");
        gameObject.GetComponent<Text>().text = "High Score: " + highScore;
        //PlayerPrefs.SetFloat("phone_runner_high_score", 0);
        //gameObject.GetComponent<Text>().text = "High Score: " + 0;
    }
}
