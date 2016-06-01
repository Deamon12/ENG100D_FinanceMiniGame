using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float scoreValue = 0.0f;
		scoreValue = PlayerPrefs.GetFloat("phone_runner_score");
		Debug.Log("Setting score to " + "Score: " + scoreValue);
		gameObject.GetComponent<Text>().text = "Score: " + scoreValue;
		if ((float)PlayerPrefs.GetFloat("phone_runner_high_score") < scoreValue)
		{
			Debug.Log("New high score being set to: " + scoreValue);
			PlayerPrefs.SetFloat("phone_runner_high_score", scoreValue);
		}
	}
}
