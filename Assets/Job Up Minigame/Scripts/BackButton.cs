using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/* 
 * For all back buttons, simply returns the player to the screen prior to the 
 * current one in the hierarchy 
 */
public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /* Takes the user back to the StartScreen */
    public void GoToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    /* Takes the user back to the CateogryScreen */
    public void GoToCategories()
    {
        SceneManager.LoadScene("CategoryScreen");
    }
}
