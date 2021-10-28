using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : InteractableMono{
    [SerializeField] Transform lightOrigin;
    private Quaternion rotationVar;
    bool lightState = true;

    void Start(){
        rotationVar = transform.rotation;
    }

    public override bool DoInteraction(){
        SwitchAllLights();
        RotateZ();
        return true;
    }

    protected void SwitchAllLights(){
        foreach(Transform child in lightOrigin){
            child.gameObject.GetComponent<Light>().enabled = !lightState;
        }
        lightState = !lightState;
    }

    protected void RotateZ(){
        rotationVar.z *= -1;  
        this.transform.rotation = rotationVar;
    }

}
