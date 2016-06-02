using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour {
    public GameObject GoButton;
    public GameObject NextLevelPanel;
    public GameObject WaveText;
    public GameObject Warning;

    public GameObject BeginButton;
    public GameObject IntroBackground;
    public GameObject WaveTutorial;
    public GameObject TrashTutorial;
    public GameObject AnimalTutorial;
    public GameObject WaveArrow;
    public GameObject TrashArrow;
    public GameObject AnimalArrow;
    public GameObject exTurtle, exFish, exTrash;
    public Text fact;

    public bool nextLevel;

    // Use this for initialization
    void Start () {
        nextLevel = false;
	}

    public void FactText()
    {
        SetFactText();
    }
    void SetFactText()
    {
        fact.text = "SOME FACT";
    }

    public void updateEndLevelButton() {
        if(beach_spawn.numTrash == 0){
            NextLevelPanel.SetActive(false);
            GoButton.SetActive(false);
            WaveText.SetActive(false);
            Warning.SetActive(false);
            nextLevel = true;
        }
    }
    public void updateStartGameButton()
    {
        SceneManager.LoadScene("beach_game");
    }
	
	// Update is called once per frame
	void Update () {
        FactText();
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
