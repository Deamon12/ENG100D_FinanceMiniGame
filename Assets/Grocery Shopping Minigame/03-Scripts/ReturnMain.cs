using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void moveToMain()
    {
        Destroy(GameObject.Find("SoundObject"));
        SceneManager.LoadScene(0);
    }
}
