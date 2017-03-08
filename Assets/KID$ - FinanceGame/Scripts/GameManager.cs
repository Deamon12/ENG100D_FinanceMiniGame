using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private PlayerData character;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);          //Sets this to not be destroyed when reloading scene
            instance = this;                        //if not, set instance to this
            InitGame();
        }
        
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);                    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

    }

    private void InitGame()
    {

        //saveGame();


        //TODO: Check I/O for saved game
        loadGame();

        //TODO: Setup up game environment

       



    }

    private void loadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/KID$_playerinfo.dat"))
        {
            print(Application.persistentDataPath + "/KID$_playerinfo.dat: LOADED");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/KID$_playerinfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
        }
        else
        {
            print(Application.persistentDataPath + "/KID$_playerinfo.dat: FILE NOT FOUND");
        }


    }

    private void saveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/KID$_playerinfo.dat");

        PlayerData data = new PlayerData();
        data.bankBalance = 55.00f;

        bf.Serialize(file, data);
        file.Close();

    }

}

