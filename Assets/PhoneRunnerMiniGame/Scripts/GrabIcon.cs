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
		Icon myIcon = other.gameObject.GetComponent<Icon>();
		Obstacle myObstacle = other.gameObject.GetComponent<Obstacle>();

		if (myIcon)
		{
			float value = myIcon.value;
			GameObject.Destroy(other.gameObject);
			phoneScore.addScore(value);
			phoneSlider.value += 10;
			Debug.Log("slider value: " + phoneSlider.value);
		}
		else if (myObstacle)
		{
			Application.LoadLevel("game_over_scene");
		}
	}
}
