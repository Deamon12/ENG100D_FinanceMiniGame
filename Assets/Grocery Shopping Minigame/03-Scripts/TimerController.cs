using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TimerController : MonoBehaviour {

    public static float timer;
	private Text timerField;

	// Use this for initialization
	void Start () {
		timerField = GetComponent<Text>();
		timer = 10.0f;
		timerField.text = "Time: " + timer;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0){
			timer = 0;
			PointController.gameOver = true;
		}
		else{
			timer -= Time.deltaTime;
			timerField.text = "Time: " + Mathf.Round(timer);
		}
	}
}
