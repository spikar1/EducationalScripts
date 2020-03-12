using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_03 : MonoBehaviour
{
    Vector3 startPosition;

    [Tooltip("Meters the platform will travel")]
    public float travelLength = 5;
    //We introduce a speed for the platform to travel
    //Since we use Time.time, we know that it is based on seconds
    [Tooltip("Meters per second")]
    public float speed = 2;

    //Instead of the static direction of previous iterations
    //We introduce a direction variable
    public Vector3 direction = Vector3.right;

    private void Awake() {
        startPosition = transform.position;
    }

    void Update()
    {
        //By multiplying time with a number, we effectively set the meters per second
        float sinePosition = Mathf.PingPong(Time.time * speed, travelLength);
        //Here we multiply by the direction variable. 
        //Notice we normalize the direction, this is to make sure ut represents a Unit direction
        //Unit direction == A direction excactly one meter long
        transform.position = startPosition + direction.normalized * sinePosition;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        //Here we introduce a variable for endPosition, making reading a bit easier
        Vector3 endPosition = transform.position + direction.normalized * travelLength;

        Gizmos.DrawWireSphere(transform.position, .5f);
        Gizmos.DrawWireSphere(endPosition, .5f);
        Gizmos.DrawLine(transform.position, endPosition);
    }
}
