using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsExample_Done : MonoBehaviour
{
    //Some example value to use
    public int someInt = 0;
    //The key we use to save the data
    //The PlayerPrefs needs a key and a value
    string someIntKey = "myIntKey";

    [Multiline]
    public string someText = "";
    string someTextKey = "myStringKey";

    [ContextMenu("Save")]
    public void Save() {
        //We save the value of someInt localy on the users computer.
        //The key is used as a "label" would in a library, so that the
        //program can get the value at a later date
        PlayerPrefs.SetInt(someIntKey, someInt);
        PlayerPrefs.SetString(someTextKey, someText);
    }

    [ContextMenu("Load")]
    public void Load() {
        someInt = PlayerPrefs.GetInt(someIntKey);
        someText = PlayerPrefs.GetString(someTextKey);
    }
}
