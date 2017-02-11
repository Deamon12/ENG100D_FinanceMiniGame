using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    public void startGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
