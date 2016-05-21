using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PhoneIconScore : MonoBehaviour {
    private float score = 0.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addScore(float scoreIncrease)
    {
        Debug.Log("entered phoneiconscore class");
        score += scoreIncrease;
        Debug.Log("score increased");
        updateScore();
    }

    private void updateScore()
    {
        Debug.Log("updateScore entered");
        gameObject.GetComponent<Text>().text = "Score: " + score;
    }

}
