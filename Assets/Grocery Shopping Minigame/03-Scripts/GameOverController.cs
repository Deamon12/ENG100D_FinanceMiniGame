using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public static float point;
    public static Text result;
	// Use this for initialization
	void Start () {
        point = PointController.points;
        result = GetComponent<Text>();
       
	}
	
	// Update is called once per frame
	void Update () {
        result.text = "Points " + point;
    }

}
