using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelfCalledButton : MonoBehaviour
{
    //Declare a reference to some Button Component
    Button button;
    private void Start() {
        //Assign the attached Button Component to our reference
        button = GetComponent<Button>();

        //Add OnClick as a new event on the button
        //Will not show in inspector
        button.onClick.AddListener(OnClick);
    }
    public void OnClick() {
        print("Button has been pressed");
    }

}
