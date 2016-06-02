using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class beachNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startNextLevel() {
        SceneManager.LoadScene("beach_game");
    }
}
