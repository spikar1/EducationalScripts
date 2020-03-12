using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    void OnTouch() {
        transform.localScale = Vector3.one * 2;
    }
}
