using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* For the SettingsScene */
public class Settings : MonoBehaviour {

    // Constant strings to be displayed in the button
    private const string MUSIC_ON = "Music: ON";
    private const string MUSIC_OFF = "Music: OFF";

    Text musicBtnText; // Text for the button

    // Use this for initialization
    void Start () {
        // Get the button's text
        musicBtnText = GameObject.Find("Music Button").GetComponentInChildren<Text>();

        // Update the text accordingly
        if (PlayerPrefsX.GetBool("Mute"))
        {
            musicBtnText.text = MUSIC_OFF;
        }
        else
        {
            musicBtnText.text = MUSIC_ON;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    /* 
     * Changes the "Mute" value and updates the text
     */
    public void toggleMute()
    {
        // Set the "Mute" variable to true, thus music should turn off
        PlayerPrefsX.SetBool("Mute", !PlayerPrefsX.GetBool("Mute"));

        /* 
         * If the "Mute" variable is true the text should indicate that the music is off,
         * otherwise the text should indicate that teh music is on
         */
        if(PlayerPrefsX.GetBool("Mute"))
        {
            musicBtnText.text = MUSIC_OFF;
        }
        else
        {
            musicBtnText.text = MUSIC_ON;
        }
    }
}
