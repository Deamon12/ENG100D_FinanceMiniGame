using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/* For the CategoryScene */
public class Buttons : MonoBehaviour {

    /* 
     * All of these constant strings are for the buttons in the categories
     * There is probably an easier and cleaner way to do this
     * Currently, everything is manually put into alphabetical order, and
     * the indices reflect the category/button's position in the list on 
     * the screen
     * 
     * Format: 
     * private const string ABBREVIATEDCATNAME_TITLE = "Category Name";
     * private const string ABBREVIATEDCATNAME_STR = "Description of the Category";
     * private const int ABBREVIATEDCATNAME_INDEX = (position of category in the list);
     */
    private const string INT_TITLE = "Interview";
    private const string INT_STR = "This category contains ways you should conduct yourself in an interview";
    private const int INT_INDEX = 0;

    private const string OCC_TITLE = "Occupations";
    private const string OCC_STR = "This category contains various occupations one may search for.";
    private const int OCC_INDEX = 1;

    private const string TNTB_TITLE = "Things Not to Bring";
    private const string TNTB_STR = "This cateogry contains items that you should NOT bring to an interview.";
    private const int TNTB_INDEX = 2;

    private const string TTB_TITLE = "Things to Bring";
    private const string TTB_STR = "This category contains items that you should bring to an interview.";
    private const int TTB_INDEX = 3;

    Text title, description; // Will hold access to the title and description fields in the UI
    GameObject instructions1, instructions2; // Will hold instructions1 & 2 canvases
    Button playButton, instructionsButton; // Will hold the play and instruction buttons

    string catName;

    // Use this for initialization
    void Start () {
        /* Get the text for the title and description GameObjects */
        title = GameObject.Find("CategoryTitle").GetComponentInChildren<Text>();
        description = GameObject.Find("Description").GetComponentInChildren<Text>();

        /* Get the playButton GameObject and initially make it uninteractable */
        playButton = GameObject.Find("Play").GetComponent<Button>();
        playButton.interactable = false;

        /* Get the instructionsButton GameObject */
        instructionsButton = GameObject.Find("InstructionsButton").GetComponent<Button>();

        /* Get the first and second page of instructions and hide them */
        instructions1 = GameObject.Find("Instructions1");
        instructions1.SetActive(false);

        instructions2 = GameObject.Find("Instructions2");
        instructions2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /* Updates the text on the right side to reflect the selected category */
    private void ChangeRightSide(string newTitle, string newDescription)
    {
        title.text = newTitle; // Update title
        description.text = newDescription; // Update description
        playButton.interactable = true; // Allow the game to be playable

        /* Store the name of the category */
        PlayerPrefs.SetString("catName", newTitle);
        catName = newTitle;
    }

    /* Sends values relating to the Occupation category */
    public void Occupation() {
        ChangeRightSide(OCC_TITLE, OCC_STR);
    }

    /* Sends values relating to the Things to Bring category */
    public void ThingsToBring() {
        ChangeRightSide(TTB_TITLE, TTB_STR);
    }

    /* Sends values relating to the Things Not to Bring category */
    public void ThingsNotToBring() {
        ChangeRightSide(TNTB_TITLE, TNTB_STR);
    }

    /* Sends values relating to the Interview category */
    public void Interview() {
        ChangeRightSide(INT_TITLE, INT_STR);
    }

    /* Displays the instructions for the entire game */
    public void Instructions()
    {
        instructions1.SetActive(true);
    }

    /* "Next" button: Displays the next part of the instructions */
    public void Next()
    {
        instructions1.SetActive(false);
        instructions2.SetActive(true);
    }

    /* "Close" button: Removes all the instructions from the screen */
    public void Close()
    {
        instructions2.SetActive(false);
    }

    /* Starts the game by changing the scene and passing the proper deck/deck index */
    public void StartGame()
    {
        if (catName != "") {
            SceneManager.LoadScene("GameScene");
        }
    }
}
