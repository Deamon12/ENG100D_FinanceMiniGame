using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    
  //Loads the scene at the specified index
  public void loadScene(int sceneIndex) {
    SceneManager.LoadScene(sceneIndex);

  }
}
