using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassToBeSaved_Done : MonoBehaviour
{
    public Stats playerStats;
}

// We create our stats in a separate class
// This way we can serialize out stats, and separate it from other variables

[System.Serializable]
public class Stats {

    //These are all just examples

    public int maxHealth;
    public int currentHealth;
    public string characterName;
    public int attackStrength;

    public string[] aqcuantances = new string[0];
}