using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_02 : MonoBehaviour
{
    Vector3 startPosition;

    //Tooltip for better usage by others
    [Tooltip("Meters the platform will travel")]
    public float travelLength = 5;

    private void Awake() {
        startPosition = transform.position;
    }

    void Update()
    {
        //Much the same, but uses a variable for the platform travel length
        float positionOffset = Mathf.PingPong(Time.time, travelLength);
        transform.position = startPosition + new Vector3(positionOffset, 0, 0);
    }

    private void OnDrawGizmos() {
        //The color of all gizmos, until another color is set
        Gizmos.color = Color.green;

        //We draw two spheres for the start and end position
        Gizmos.DrawWireSphere(transform.position, .5f);
        //Here we use the exact same calculation used to move the platform
        //but using the max travel length, as opposed to a pingPong value
        Gizmos.DrawWireSphere(transform.position + Vector3.right * travelLength, .5f);
        //A simple line between the two points
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * travelLength);
    }
}
