using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{

    //Global boolean used to symbolize when a game-over state has been reached
    public static bool gameOver;
    public static float points;

    public Text overField;

    // Use this for initialization
    void Start()
    {

        gameOver = false;
        overField = GetComponent<Text>();
        overField.text = "";
        points = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            overField.text = "Game Over! Points: " + points;
        }
    }

}