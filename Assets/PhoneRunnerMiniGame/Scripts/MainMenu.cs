﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public void startGame(string scene)
    {
        Application.LoadLevel(scene);
    }
}
