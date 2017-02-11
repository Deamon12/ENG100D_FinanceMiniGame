using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/* For the SettingsButton, simply loads the SettingsScreen */
public class SettingsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /* Simply loads the SettingsScreen */
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
}
