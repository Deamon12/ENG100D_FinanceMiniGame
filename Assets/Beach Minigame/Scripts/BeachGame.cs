using UnityEngine;
using System.Collections;
using System;

public class BeachGame : MonoBehaviour {


    BeachTimer t;
    //private GameObject t;
    private float level, score, lives;

    private float special_bar;

	// Use this for initialization
	void Start () {
        t = GameObject.FindGameObjectWithTag("beach_timer").GetComponent<BeachTimer>();
        //t = new BeachTimer(20); 
        level = 1;
        score = 0;
        lives = 3;

        special_bar = 0;

        spawnLeveL();
        t.resume();
        //runLevel(level);
	}
	
	// Update is called once per frame
	void Update () {
        t.Update();
        if (t.getEndLevel()) {
            endOfLevel();
        }   
	}

    void spawnLeveL() {
        //spawn all trash
        //spawn all animals
    }

    void endOfLevel()
    {
        //animateWaves
        animateWaves();

        //calculate remaining trash
        float remTrash = 0;
        //take lives - remaining trash

        if(remTrash > lives)
        {
            lives = 0;
            endGame();
        }
        else {
            lives -= remTrash;
            level++;
            t.resetTimer(20f); //array of level timers?
            spawnLeveL();
            t.resume();
        }
    }

    void animateWaves()
    {
        throw new NotImplementedException();
    }

    void endGame() {
        //popup
    }

}
