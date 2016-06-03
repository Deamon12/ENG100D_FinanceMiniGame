using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class beach_score : MonoBehaviour {
    private GameObject currScore;
	// Use this for initialization
	void Start () {
        currScore = GameObject.Find("Canvas/Score");
	}
	
	// Update is called once per frame
	void Update () {
        currScore.GetComponent<Text>().text = GlobalVariables.score.ToString();
	}
}
