using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private PlayerData player;

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
        //TODO
        createPlayer();
        //loadGame();
    }

    private void loadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/KID$_playerinfo.dat"))
        {
            // TODO: try/catch?
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/KID$_playerinfo.dat", FileMode.Open);
            player = (PlayerData)bf.Deserialize(file);
            print(Application.persistentDataPath + "/KID$_playerinfo.dat: LOADED");
        }
        else
        {
            print(Application.persistentDataPath + "/KID$_playerinfo.dat: FILE NOT FOUND");
            createPlayer();
        }

    }

    public void saveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/KID$_playerinfo.dat");

        bf.Serialize(file, player);
        file.Close();

    }

    private void createPlayer()
    {
        player = new PlayerData();

        //TODO: Show tutorial?
    }

    public PlayerData getPlayerData()
    {
        return player;
    }

}

