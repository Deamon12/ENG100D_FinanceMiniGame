using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PhoneIconScore : MonoBehaviour {
	private float score = 0.0f;
	public Slider phoneMeter;

	// Use this for initialization
	void Start () {
		Debug.Log("Inside of start in PhoneIconScore");
		GameObject temp = GameObject.Find("phone_limit_slider");
		phoneMeter = temp.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (phoneMeter.value >= phoneMeter.maxValue)
		{
			Application.LoadLevel("game_over_scene");
		}
	}

	public void addScore(float scoreIncrease)
	{
		//Debug.Log("Score was updated to " + score);
		score += scoreIncrease;
		Debug.Log("Storing score: " + score);
		PlayerPrefs.SetFloat("phone_runner_score", score);
		gameObject.GetComponent<Text>().text = "Score: " + score;		
	}

	public void incrementSlider(int amount)
	{
		phoneMeter.value += amount;
	}

	void Awake()
	{
		Debug.Log("Inside of Awake in PhoneIconeScore");
		score = 0.0f;
		PlayerPrefs.SetFloat("phone_runner_score", score);
	}
	public float getScore()
	{
		return score;
	}
}
