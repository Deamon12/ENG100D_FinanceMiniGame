using UnityEngine;
using System.Collections;


public class GlobalVariables : MonoBehaviour {
    public static int hearts = 3;
    public static int score = 0;
    public static int level = 0;
    public static float speedScale = 1;
	// Use this for initialization
	void Start () {
        
        speedScale =  0.5f*level + speedScale;
        if (level > 10) {
            speedScale = 1f * level + speedScale;
        } else {
            speedScale = (2f * level) + speedScale;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
