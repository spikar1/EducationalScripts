using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchExamples : MonoBehaviour
{
    public GameObject firstFingerIndicator;
    public GameObject secondFingerIndicator;

    public GameObject GyroObject;

    private void Awake() {
        Input.gyro.enabled = true;
    }

    private void Update() {
        HandleTouch();

        HandleGyro();
    }

    private void HandleGyro() {
        GyroObject.transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    void HandleTouch() {
        //Remove Second Finger indicator if there is only one touch
        if(Input.touchCount < 2) {
            secondFingerIndicator.transform.position = Vector3.one * 100;

        }

        //iterate through all touches (We only use two)
        for (int i = 0; i < Input.touchCount; i++) {

            //Declare and define a variable
            //To hold the touch data this iteration
            Touch touch = Input.touches[i];
            
            //Declare a variable to store which 
            //indicator to use
            GameObject indicator = null;

            //Declare and define a variable for the 
            //screen to world position per touch
            Vector3 touchScenePosition = Camera.main.ScreenToWorldPoint(touch.position) + Vector3.forward * 10;

            if (CheckIfInteraction(touchScenePosition)) {
                return;
            }

            //Check finger index, and set the indicator 
            //variable accordingly
            if (i == 0) {
                indicator = firstFingerIndicator;
            }
            else if(i == 1) {
                indicator = secondFingerIndicator;
            }
            else {
                //If there is a third finger, jump ship
                return;
            }

            //Scale indicator to show pressure 
            //(This don't work on my phone)
            indicator.transform.localScale = Vector3.one * touch.pressure;

            //Do different stuff based on phase
            switch (touch.phase) {
                case TouchPhase.Began:
                    indicator.transform.position = touchScenePosition;
                    break;
                case TouchPhase.Moved:
                    indicator.transform.position = touchScenePosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    //If the touch has been ended, reset 
                    //the indicator position to be placed
                    //outside the screen
                    indicator.transform.position = Vector3.one * 100;
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }

    private bool CheckIfInteraction(Vector3 touchScenePosition) {
        Collider2D collider = Physics2D.OverlapCircle(touchScenePosition, .3f);
        if(collider != null) {
            if (collider.gameObject == firstFingerIndicator || collider.gameObject == secondFingerIndicator)
                return false;
            collider.SendMessage("OnTouch");
            return true;
        }
        return false;
    }

    //Fordi vi må...
    private static Quaternion GyroToUnity(Quaternion q) {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
