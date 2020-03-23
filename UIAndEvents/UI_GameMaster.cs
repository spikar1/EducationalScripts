using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameMaster : MonoBehaviour
{
    //Defines access to this member
    //get is public, set is private
    public static UI_GameMaster Instance { get; private set; }

    //some random values
    public int score;
    public List<GameObject> killedEnemies;

    private void Awake() {
        //Make sure there exists only one
        //If we have located an instance already (not null) Destroy Instance
        if (Instance == null)
            Instance = this;
        else {
            Destroy(this);
        }

        //Make sure that this object persists throughout the game
        DontDestroyOnLoad(this);
    }
}
