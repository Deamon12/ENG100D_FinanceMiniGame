using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class beachMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void startBeachGame() {
        SceneManager.LoadScene("beach_start");
    }
    
    public void learnMoreButton() {
        // Opens up learnMoreCanvas
    }

    public void exitBeachGame() {
        SceneManager.LoadScene("OverviewMap");
    }
}
