using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_01 : MonoBehaviour
{
    //A variable for storing the start position
    //We use this to offset the platform during play
    Vector3 startPosition;

    private void Awake() {
        //Set start position before any Update frames
        startPosition = transform.position;
    }

    void Update()
    {
        //Use a pingPong operation to make a value "bounce" between 0 and 3
        float positionOffset = Mathf.PingPong(Time.time, 3);
        //Position the platform based on the start position, plus our offset varible
        transform.position = startPosition + new Vector3(positionOffset, 0, 0);
    }
}
