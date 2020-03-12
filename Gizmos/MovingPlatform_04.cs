using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_04 : MonoBehaviour
{
    Vector3 startPosition;

    [Tooltip("Meters the platform will travel")]
    public float travelLength = 5;
    [Tooltip("Meters per second")]
    public float speed = 2;

    public Vector3 direction = Vector3.right;

    private void Awake() {
        startPosition = transform.position;
    }

    void Update()
    {
        float sinePosition = Mathf.PingPong(Time.time * speed, travelLength);
        transform.position = startPosition + direction.normalized * sinePosition;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Vector3 endPosition;
        //The name StartPosition was taken, I am not pleased with this name...
        Vector3 GizmostartPosition;

        //By checking f the application is running, we can draw the platform correctly during play
        //This because before we press play, the startPosition makes little sense
        if (Application.isPlaying) {
            GizmostartPosition = startPosition;
            endPosition = startPosition + direction.normalized * travelLength;
        }
        else {
            GizmostartPosition = transform.position;
            endPosition = transform.position + direction.normalized * travelLength;
        }
        
        //Since we calculate start and end position based on Application.isPlaying
        //we can use the same draw function for both cases
        Gizmos.DrawWireSphere(GizmostartPosition, .5f);
        Gizmos.DrawWireSphere(endPosition, .5f);
        Gizmos.DrawLine(GizmostartPosition, endPosition);
    }
}
