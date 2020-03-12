using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlaceOnGround_Fin : MonoBehaviour
{
    [MenuItem("SteffenTools/Shortcuts/PlaceSelectedOnGround #s")]
    public static void DoPlace() {
        //Get the selected object in scene
        var selectedObject = Selection.activeGameObject;

        //If no gameobject is selected, don't do anything
        if (!selectedObject)
            return;
        //To not raycast the selected object, or its children
        //we disable all colliders attached
        ToggleSelectedCollider(selectedObject, false);

        //Regular raycast2D. Notice I use a limited range (100)
        //This because we don't want the object to disapear into oblivion
        var hit = Physics2D.Raycast(selectedObject.transform.position, Vector2.down, 100);
        if (hit) {
            //This will register the action in the Undo stack (AKA, make it possible to Undo our placement)
            Undo.RecordObject(selectedObject.transform, "Placed " + selectedObject.name + " on the ground");

            //This code is not good enough, we should also compensate for
            //the height of our gameobject
            selectedObject.transform.position = hit.point;
        }
        
        //After moving the object down, we reenable all colliders
        ToggleSelectedCollider(selectedObject, true);

        //This flags the object as changed (Needed for Undo)
        EditorUtility.SetDirty(selectedObject.transform);
    }

    [MenuItem("SteffenTools/Shortcuts/Reset Transform #Q")]
    public static void ResetTransform() {
        var selectedObject = Selection.activeGameObject;
        if (!selectedObject)
            return;

        Undo.RecordObject(selectedObject.transform, "Reset " + selectedObject.name);

        selectedObject.transform.position = Vector3.zero;
        selectedObject.transform.localScale = Vector3.one;
        selectedObject.transform.rotation = Quaternion.identity;

        EditorUtility.SetDirty(selectedObject.transform);
    }

    static void ToggleSelectedCollider(GameObject selectedObject, bool enabled) {
        //The Method "GetComponentsInChildren" will search for a particular component Type
        //Throughout all children of the selected GameObject, and itself
        foreach (var collider in selectedObject.GetComponentsInChildren<Collider2D>()) {
            //A simple toggle for each collider
            collider.enabled = enabled;
        }
    }
    
}
