using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Next_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextSceneButton()
    {
        SceneManager.LoadScene(7);
    }
}
