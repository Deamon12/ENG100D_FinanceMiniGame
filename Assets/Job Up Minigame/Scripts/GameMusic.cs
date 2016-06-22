using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/* Controls the Game's Music */
public class GameMusic : MonoBehaviour {

    static bool AudioBegin = false;
    AudioSource audio;

    /* Runs before the StartScene even starts */
    void Awake()
    {
        /* Play the audio if it has not been started and the "Mute" variable is false */
        if (!AudioBegin && !PlayerPrefsX.GetBool("Mute"))
        {
            audio = GetComponent<AudioSource>();
            audio.Play();

            // We want the audio to play throughout the game so do not destroy it
            DontDestroyOnLoad(gameObject); 
            AudioBegin = true;
        }
    }

    void Update()
    {
        /* If we enter the GameScene or the "Mute" variable has been set to true stop the audio*/
        if ((SceneManager.GetActiveScene().name == "GameScene" || PlayerPrefsX.GetBool("Mute")) && AudioBegin)
        {
            audio.Stop();
            AudioBegin = false;
        }

        /* 
         * Play the audio if we are not in the GameScene, the "Mute" variable is set to false, 
         * and the audio has not yet begun 
         */
        if (SceneManager.GetActiveScene().name != "GameScene" && !PlayerPrefsX.GetBool("Mute") && !AudioBegin)
        {
            audio.Play();
            AudioBegin = true;
        }
    }
}
