using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {
    public GameObject GoButton;
    public GameObject NextLevelPanel;
    public GameObject WaveText;
    public GameObject BeginButton;
    public GameObject IntroBackground;
    public GameObject WaveTutorial;
    public GameObject TrashTutorial;
    public GameObject AnimalTutorial;
    public GameObject WaveArrow;
    public GameObject TrashArrow;
    public GameObject AnimalArrow;
    public GameObject exTurtle, exFish, exTrash;

    public bool nextLevel;

    // Use this for initialization
    void Start () {
        nextLevel = false;
	}

    public void updateEndLevelButton() {
        if(beach_spawn.numTrash == 0){
            NextLevelPanel.SetActive(false);
            GoButton.SetActive(false);
            WaveText.SetActive(false);
            nextLevel = true;
        }
    }
    public void updateStartGameButton()
    {
        BeginButton.SetActive(false);
        IntroBackground.SetActive(false);
        WaveTutorial.SetActive(false);
        TrashTutorial.SetActive(false);
        AnimalTutorial.SetActive(false);
        WaveArrow.SetActive(false);
        TrashArrow.SetActive(false);
        AnimalArrow.SetActive(false);
        exTurtle.SetActive(false);
        exFish.SetActive(false);
        exTrash.SetActive(false);
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
