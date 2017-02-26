using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverControllerPhoneRunner : MonoBehaviour {

	public Text newHighScoreText;
	// Use this for initialization
	void Start () {
		float scoreValue = 0.0f;
		newHighScoreText.enabled = false;
		scoreValue = PlayerPrefs.GetFloat("phone_runner_score");
		Debug.Log("Setting score to " + "Score: " + scoreValue);
		gameObject.GetComponent<Text>().text = "Score: " + scoreValue;
		if ((float)PlayerPrefs.GetFloat("phone_runner_high_score") < scoreValue)
		{
			newHighScoreText.enabled = true;
			Debug.Log("New high score being set to: " + scoreValue);
			PlayerPrefs.SetFloat("phone_runner_high_score", scoreValue);
		}
	}
}
