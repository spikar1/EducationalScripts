using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Spawner : MonoBehaviour
{
    //We could get these using GetComponent and a smarter scene setup.
    //As of now however, we need to drag and drop them
    public InputField nameField;
    public Slider sizeSlider;
    public Button spawnButton;

    private void Awake() {
        //A simple check to see if there exists a spawnButton reference
        if (spawnButton)
            spawnButton.onClick.AddListener(Spawn);
    }

    public void Spawn() {
        //Using GameObject.CreatePrimitive we don't need prefabs for this example
        GameObject spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //We get the value from the textField using .text
        spawnedObject.name = nameField.text;
        //We multiply a V3(1,1,1) with whatever value the slider holds.
        spawnedObject.transform.localScale = Vector3.one * sizeSlider.value;
    }
}
