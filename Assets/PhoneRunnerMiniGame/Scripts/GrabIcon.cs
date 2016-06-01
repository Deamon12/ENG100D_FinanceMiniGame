using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GrabIcon : MonoBehaviour {

	public PhoneIconScore phoneScore;
	public Slider phoneSlider;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("phone_limit_slider");
		phoneSlider = temp.GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		PhoneIcon phoneIcon = other.gameObject.GetComponent<PhoneIcon>();
		Obstacle myObstacle = other.gameObject.GetComponent<Obstacle>();
		CoinIcon coinIcon = other.gameObject.GetComponent<CoinIcon>();

		if (phoneIcon)
		{
			float value = phoneIcon.value;
			GameObject.Destroy(other.gameObject);
			phoneScore.addScore(value);
			phoneSlider.value += phoneIcon.value;
			Debug.Log("slider value: " + phoneSlider.value);
		}
		else if (myObstacle)
		{
			PlayerPrefs.SetFloat("phone_runner_score", phoneScore.getScore());
			Application.LoadLevel("game_over_scene");
		}
		else if (coinIcon)
		{
			float value = coinIcon.value;
			GameObject.Destroy(other.gameObject);
			phoneScore.addScore(value);
		}
	}
}
