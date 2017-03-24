using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public GameObject popup;

    public void Action_ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
