using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;

/* For the FinishedGameScreen */
public class FinishedGame : MonoBehaviour {

    public GameObject content; // Will hold all the buttons (aka cards that were displayed)
    public Text termTitle; // GameObject for the title on the right side
    public Text description; // GameObject for the description on the right side
    public Button correctButtonPrefab; // Prefab for the "correct" buttons
    public Button passButtonPrefab; // Prefab for the "passed" buttons

    private List<string> descList; // List of descriptions loaded from a file
    private Dictionary<string, string> descHash; // Dictionary of descriptions loaded from a file

    Text score; // Player's score

    // Use this for initialization
    void Start () {

        /* Sets up the dictionary */
        SetupDescriptions();

        /* Grab all necessary values from the PlayerPrefsX */
        string[] correct = PlayerPrefsX.GetStringArray("correct");
        string[] pass = PlayerPrefsX.GetStringArray("pass");
        int intScore = PlayerPrefs.GetInt("score");

        /* Gets the view port and content components of the ScrollView*/
        var viewPort = GameObject.Find("Viewport");
        var content = GameObject.Find("Content");

        /* Makes the "cells" in the ScrollView span the entire view */
        RectTransform parent = viewPort.GetComponent<RectTransform>();
        GridLayoutGroup list = content.GetComponent<GridLayoutGroup>();
        list.cellSize = new Vector2(parent.rect.width, 100);

        /* Get the text components on the right side */
        termTitle = GameObject.Find("TermTitle").GetComponentInChildren<Text>();
        description = GameObject.Find("Description").GetComponentInChildren<Text>();
        
        /* Creates the button for each term that was guessed correctly */
        foreach (string c in correct)
        {
            var cBtn = Instantiate(correctButtonPrefab) as Button;
            var text = cBtn.GetComponentInChildren<Text>();
            text.text = c;
            text.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            text.fontSize = 100;
            cBtn.transform.parent = list.transform;
            cBtn.transform.localScale = new Vector3(1, 1, 1);
            cBtn.onClick.AddListener(() => displayDescription());
        }

        /* Creates the button for each term that was passed */
        foreach (string p in pass)
        {
            var pBtn = Instantiate(passButtonPrefab) as Button;
            var text = pBtn.GetComponentInChildren<Text>();
            text.text = p;
            text.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            text.fontSize = 100;
            pBtn.transform.parent = content.transform;
            pBtn.transform.localScale = new Vector3(1, 1, 1);
            pBtn.onClick.AddListener(() => displayDescription());
        }

        /* Updates the score component to reflect the player's score */
        score = GameObject.Find("Score").GetComponentInChildren<Text>();
        score.text = "Score: " + intScore;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /* 
     * Sets up a dictionary with all the words and their descriptions so that the used words can 
     * get their description from the description file
     */
    private void SetupDescriptions() {
        descList = new List<string>(); // Initializes the description list

        // Loads the description file pertaining to the played category
        TextAsset file = Resources.Load(PlayerPrefs.GetString("catName") + "_Desc") as TextAsset;

        // Splits the file by tabs and carriage returns
        descList = new List<string>(file.text.Split(new char[2] { '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries));

        // Initializes the Dictionary (aka hashtable)
        descHash = new Dictionary<string, string>();

        // Inserts each word as a key with the description as the value into the dictionary
        for( int i = 0; i < descList.Count; i+=2)
        {
            descHash.Add(descList[i].Replace("\0", ""), descList[i + 1].Replace("\0", ""));
        }
    }

    /* 
     * Uses the text in the clicked button to find the description in the dictionary and
     * displays both on the right side (in their designated areas)
     */
    private void displayDescription() {
        // Gets the button that was pressed to access this method
        var btn = EventSystem.current.currentSelectedGameObject;

        // Gets the text within the button
        var term = btn.GetComponentInChildren<Text>().text;

        /* Sets the objects on the right side to the respective values */
        termTitle.text = term;
        description.text = descHash[term.Replace("\r", "")];
    }
}
