using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtReference : MonoBehaviour
{
    //Pull Object Reference
    public GameObject myReference;

    //Push Objects List
    public List<GameObject> myListOfReferences = new List<GameObject>();

    [ContextMenu("Scale Reference Object")]
    void ScaleReferenceObject() {
        myReference.transform.localScale += Vector3.one;
    }

    private void Update() {
        //Check if Space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            //If there is a reference, pull
            if(myReference != null)
                myReference.transform.position = Vector3.MoveTowards(myReference.transform.position, transform.position, 1);

            //As long as there are objects in the list, push
            foreach (var reference in myListOfReferences) {
                reference.transform.position += (reference.transform.position - transform.position).normalized;
            }
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color2");

        //Draw Reference object, if any
        if (myReference != null) {
            //Draw line towards other object
            Gizmos.DrawLine(transform.position + Vector3.down * .2f, myReference.transform.position + Vector3.up * .2f);
        }
        //Check if list exist, and if it is not empty
        if (myListOfReferences != null && myListOfReferences.Count > 0) {
            //Iterate throught list, and draw line
            foreach (var reference in myListOfReferences) {

                Gizmos.DrawLine(transform.position + transform.right * .2f, reference.transform.position + transform.right * .2f);
            }
        }
    }
}
