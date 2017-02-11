using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* For the GameScene */
public class Game : MonoBehaviour {

    Deck deck; // Custom Deck class that holds all the cards
    string card; // The card that is displayed
    float timeLeft = 60.0f; // The player is given 1 minute to get as many cards as possible
    float minSwipeDist = 2.0f; // Player needs to swipe a certain amount before it is considered a "pass"
    int score = 0; // Keeps track of the player's score

    /* Keeps track of the drawnCards, cards that the player got correct, and cards that the player passed */
    List<string> drawnCards; 
    List<string> correct;
    List<string> pass;

    /* Holds the text objects for the card, timer, and score */
    Text cardText;
    Text timer;
    Text scoreLabel;

    private Vector2 startPos; // Start position of the user's "touch"

    // Use this for initialization
    void Start() {
        /* Get the text objects */
        cardText = GameObject.Find("CardText").GetComponentInChildren<Text>();
        timer = GameObject.Find("Timer").GetComponentInChildren<Text>();
        scoreLabel = GameObject.Find("ScoreLabel").GetComponentInChildren<Text>();

        // Create a new deck
        deck = new Deck(PlayerPrefs.GetString("catName"));

        /* Initialize the lists */
        drawnCards = new List<string>();
        correct = new List<string>();
        pass = new List<string>();

        // Get the first card to display
        DisplayNewCard();
    }

    // Update is called once per frame
    void Update() {
        /* Update the time */
        timeLeft -= Time.deltaTime;
        timer.text = ((int)timeLeft).ToString();

        /* End the game if there is no time left */
        if (timeLeft <= 0.0f)
        {
            pass.Add(card); // Add the last card to be displayed to the pass list
            CompleteGame();
        }

        /* 
         * Determines whether the touch was a swipe or a tap and marks the card as 
         * "passed" or "correct" accordingly
         */
        if (Input.touchCount > 0) {

            Touch touch = Input.touches[0];
            bool changed = false;

            switch(touch.phase)
            {
                /* Take note of the start position */
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                /* Determine if the user swiped or tapped */
                case TouchPhase.Ended:

                    float swipeDist = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDist > minSwipeDist)
                    {
                        float swipeVal = Mathf.Sign(touch.position.y - startPos.y);

                        if(swipeVal > 0) {
                            changed = true;

                            pass.Add(card);
                            if (deck.NumberOfCards() == 0)
                            {
                                CompleteGame();
                            }
                            else
                            {
                                DisplayNewCard();
                            }
                        }
                    }

                    if (!changed)
                    {
                        correct.Add(card);
                        score += 100;
                        scoreLabel.text = "Score: " + score;


                        if (deck.NumberOfCards() == 0)
                        {
                            CompleteGame();
                        }
                        else
                        {
                            DisplayNewCard();
                        }
                    }
                    break;
            } 
            
            
        }

        /* Similar to above but for computers */
        else if (Input.GetMouseButtonUp(0))
        {
            correct.Add(card);
            score += 100;
            scoreLabel.text = "Score: " + score;


            if (deck.NumberOfCards() == 0)
            {
                CompleteGame();
            }
            else
            {
                DisplayNewCard();
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            pass.Add(card);
            if (deck.NumberOfCards() == 0)
            {
                CompleteGame();
            }
            else
            {
                DisplayNewCard();
            }
        }
    }

    /* Displays a new card from the Deck */
    public void DisplayNewCard() {
        card = deck.Draw(); // Draws the next card
        cardText.text = card; // Displays the card's text

        drawnCards.Add(card); // Add the card to the drawnCards list
    }

    /* Stores the lists and score and loads the next screen */
    private void CompleteGame()
    {
        // Store the "correct" list
        PlayerPrefsX.SetStringArray("correct", correct.ToArray());
        // Store the "passed" list
        PlayerPrefsX.SetStringArray("pass", pass.ToArray());
        // Store the score
        PlayerPrefs.SetInt("score", score);

        SceneManager.LoadScene("FinishedGameScreen");
    }
}
