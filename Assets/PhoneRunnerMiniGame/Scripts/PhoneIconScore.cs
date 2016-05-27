using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PhoneIconScore : MonoBehaviour {
	private float score = 0.0f;
	public Slider phoneMeter;

	// Use this for initialization
	void Start () {
		phoneMeter = GetComponent<Slider>();
	}
	
	// Update is called once per frame

	public void addScore(float scoreIncrease)
	{
		//Debug.Log("Score was updated to " + score);
		score += scoreIncrease;
		gameObject.GetComponent<Text>().text = "Score: " + score;

		Debug.Log("Storing score: " + score);
		PlayerPrefs.SetFloat("phone_runner_score", score);
	}

	public void incrementSlider(int amount)
	{
		phoneMeter.value += amount;
	}

	void Awake()
	{
		Debug.Log("Inside of Awake in PhoneIconeScore");
		score = 0.0f;
	}
}
