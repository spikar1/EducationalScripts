using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SomeClass))]
public class Attributes : MonoBehaviour
{
    [Header("Some vars")]
    [Range(0, 5)] public int myIntRange = 2;

    [Min(1), Tooltip("This is a tooltip")]
public float myMinFloat = 3.4f;

    //[Header("Another set of vars")]
    [ContextMenuItem("Write message, but from field", "PrintSomeMessage")]
    public int i;

    [Space(40f)]
    [Multiline]
    public string aMultiLineString = "Hello";


    [ContextMenu("Write message")]
    public void PrintSomeMessage() {
        print("Some message");
        transform.position += Vector3.up;
    }
}
