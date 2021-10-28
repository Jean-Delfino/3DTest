using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropObject : InteractableMono{
    private Vector3 mouseOff;
    private float zCord;
    
    public override bool DoInteraction(){
        OnMouseDownInter();
        StartCoroutine(DragSystem());
        return true;
    }
    

    //Jayanam
    private void OnMouseDownInter() {
        zCord = Camera.main.WorldToScreenPoint(this.gameObject.transform.position).z;
        mouseOff = this.gameObject.transform.position - GetMouseWorlPosition();
    }

    private Vector3 GetMouseWorlPosition(){
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = zCord;
        
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    IEnumerator DragSystem(){
        while(Input.GetButton("Fire1")){
            this.transform.position = GetMouseWorlPosition() + mouseOff;
            yield return null;
        }

        yield return null;
    }

    /*
    private void OnCollisionEnter(Collision other) {
        StopAllCoroutines();
    }*/

}