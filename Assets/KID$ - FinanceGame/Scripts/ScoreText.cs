using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour {

    public static int runnerScore;
    Text text;

	void Awake() {
        text = GetComponent<Text>();
        runnerScore = 0;
	}

	// Update is called once per frame
	void LateUpdate() {
        text.text = "" + runnerScore;
    }
}
