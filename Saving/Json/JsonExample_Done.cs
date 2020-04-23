using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonExample_Done : MonoBehaviour
{
    // => Is shorthand for creating a "read only" variable
    // This will be the path to our savefile
    string path => Application.dataPath + "/Økt 10/savefile.json";
    
    // Our monobehaviour class that has a stat object to save
    public ClassToBeSaved_Done someObject;
    
    // We can use ContextMenu for debugging
    // This will have to be changed for in-game saving/loading

    [ContextMenu("Save")]
    public void Save() {
        // We create a string containing the converted playerstats
        // Using JsonUtility we convert a serializable class to text
        string json = JsonUtility.ToJson(someObject.playerStats);
    
        // Using System.IO we can read and write files
        // In this case, File.WriteAllText writes a file using string data as input
        // The path is defined on line 10
        File.WriteAllText(path, json);
    }
    
    [ContextMenu("Load")]
    public void Load() {
        // We read the file saved previously
        // We get the raw version of the file, as a string
        string json = File.ReadAllText(path);

        // By using the json string as input FromJson creates an object of type Stats
        // This object will be identical as the one used when writing the file (Save)
        Stats loadedStats = JsonUtility.FromJson<Stats>(json);

        // We update the referenced playerStats (someObject) using the newly loaded Stats object
        someObject.playerStats = loadedStats;

        // Just an example:
        // We get the characterName variable from the loaded stats, and name the GameObject
        someObject.name = loadedStats.characterName;
    }
}   
