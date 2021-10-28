using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : InteractableMono{
    [SerializeField] float onDragSpeed;

    //Tylers Coding
    /*
    private void OnMouseDrag() {
        transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * onDragSpeed);
        transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y")  * onDragSpeed);
    }*/

    public override bool DoInteraction(){
        StartCoroutine(RotateButton());

        return true;
    }
    
    IEnumerator RotateButton(){
        while(Input.GetButton("Fire1")){
            transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * onDragSpeed);
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y")  * onDragSpeed);
            yield return null;
        }

        yield return null;
    }
}
