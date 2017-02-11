using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/* For the StartButton, simply loads the CategoryScreen */
public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /* Simply loads the CategoryScreen */
    public void SwitchScene()
    {
        SceneManager.LoadScene("CategoryScreen");
    }
}
