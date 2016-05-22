using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PhoneIconScore : MonoBehaviour {
    private float score = 0.0f;
    //public Slider phoneMeter;

	// Use this for initialization
	void Start () {
       // phoneMeter = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addScore(float scoreIncrease)
    {
        score += scoreIncrease;
        updateScore();
    }

    private void updateScore()
    {

        gameObject.GetComponent<Text>().text = "Score: " + score;
        Debug.Log("Score was added");
       // phoneMeter.value += score;
    }

}
