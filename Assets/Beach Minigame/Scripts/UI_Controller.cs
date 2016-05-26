using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {
    public GameObject GoButton;
    public GameObject NextLevelPanel;
    public GameObject WaveText;

    public bool nextLevel;

    // Use this for initialization
    void Start () {
        nextLevel = false;
	}

    public void updateButton() {
        if(beach_spawn.numTrash == 0){
            NextLevelPanel.SetActive(false);
            GoButton.SetActive(false);
            WaveText.SetActive(false);
            nextLevel = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if(beach_spawn.numTrash == 0){
            GoButton.SetActive(true);
            NextLevelPanel.SetActive(true);
        }
        */
        /*
        else{
            GoButton.SetActive(false);
        }
        */
	}
}
