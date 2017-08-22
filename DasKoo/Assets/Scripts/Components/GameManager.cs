using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject stage;
    public GameObject[] players;
    public PlayerCamera[] cameras;
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;              
    private int curStageNum = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        for(int i = 0; i < players.Length; ++i)
        {
            if(players[i] != null)
            {
                Instantiate(players[i]);
            }
        }
        if(stage != null)
        {
            Instantiate(stage);
        }
        //need to make it target clone in the hierarchy 
        //PlayerCamera cam = stage.GetComponentInChildren<PlayerCamera>();
        //cam.SetTarget(players[0].transform);
    }

}