using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class beachMenuScript : MonoBehaviour {
    private GameObject learnMore;
	// Use this for initialization
	void Start () {
        learnMore = GameObject.Find("Canvas/LearnMore");
        learnMore.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void startBeachGame() {
        SceneManager.LoadScene("beach_start");
    }

    public void exitBeachGame() {
        SceneManager.LoadScene("OverviewMap");
    }

    public void learnMoreButton() {
        // Opens up learnMoreCanvas
        learnMore.GetComponent<Canvas>().enabled = true;
    }

    public void closeLearnMore() {
        // Opens up learnMoreCanvas
        learnMore.GetComponent<Canvas>().enabled = false;
    }
}
