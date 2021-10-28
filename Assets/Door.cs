using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableMono{
    // Start is called before the first frame update
    //[SerializeField] Vector3 rotationVector;
    bool lockedObj = true;

    void Start(){
        //rotationVar = Quaternion.Euler(rotationVar);
    }  

    public override bool DoInteraction(){
        lockedObj = !lockedObj;

        return true;
    }

    /*
    public override bool DoInteraction(){
        //print("Clicked");
        RotateY();
        return true;
    }


    protected void RotateY(){
        lockedObj = !lockedObj;
        print(lockedObj);
        if(lockedObj){
            this.transform.rotation = new Quaternion(0f , 0f, 0f, 0f);
            return;
        }
        print(this.transform.rotation);
        this.transform.rotation = rotationVector;
        print(this.transform.rotation);
    }*/
}
