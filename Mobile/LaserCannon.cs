using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    Camera mainCamera;
    Vector3 debugPos;

    private void Start() {
        mainCamera = Camera.main;
    }


    private void Update() {
        Vector3 aimPosition = Vector3.zero;

        if(Input.touchCount > 0) {
        }
        else {
            debugPos = aimPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector2 aim = aimPosition - transform.position;
        aim = aim.normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, aim);

        if (hit) {
            Debug.DrawLine(transform.position, hit.point);

        }
        else {
            Debug.DrawRay(transform.position, aim * 7);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(debugPos, .5f);
    }
}
