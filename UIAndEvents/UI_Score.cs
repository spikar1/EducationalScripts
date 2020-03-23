using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    //Some variable to hold the score
    int score;
    //Reference to the TextCompoent
    Text scoreText;

    private void Awake() {
        //Assign reference to Text Component
        scoreText = GetComponent<Text>();
    }


    public void AddScore(int value) {
        //Apply score change to score variable
        score += value;

        //Update score Text
        scoreText.text = "Score: " + score;
    }
}
