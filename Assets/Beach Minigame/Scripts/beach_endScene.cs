using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class beach_endScene : MonoBehaviour {
    private GameObject score;
    private GameObject highestLevel;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("Canvas/sText/SCOREText");
        highestLevel = GameObject.Find("Canvas/lvlText/LEVELText");

        score.GetComponent<Text>().text = GlobalVariables.score.ToString();
        highestLevel.GetComponent<Text>().text = GlobalVariables.level.ToString();
    }
	
	// Update is called once per frame
	//void Update () {
	   
	//}

    public void menuButton() {
        SceneManager.LoadScene("beach_menu");
    }
}
