using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class TimeText : MonoBehaviour {
    
    Text text;
    DateTime startTime;
    TimeSpan elapsedTime;


    void Awake() {

        text = GetComponent<Text>();
        startTime = DateTime.Now;
    }

    void LateUpdate()
    {
        elapsedTime = DateTime.Now - startTime;

        string displayTime = String.Format("{0:00}:{1:00}",
        elapsedTime.Minutes,
        elapsedTime.Seconds,
        elapsedTime.Milliseconds);

        text.text = displayTime;
    }


}
