using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractive : InteractableMono{
    [SerializeField] float down = default;
    [SerializeField] int change = default;

    private static ChangeObject cg;
    Vector3 press;

    void Start(){
        press = new Vector3(0 , down , 0);
        cg = FindObjectOfType<ChangeObject>();
    }

    public override bool DoInteraction(){
        StartCoroutine(PressButton());

        return true;
    }
    IEnumerator PressButton(){
        this.transform.position -= press;
        cg.ChangeObjectInScene(change);
        
        while(Input.GetButton("Fire1")){
            yield return null;
        }

        this.transform.position += press;
        yield return null;
    }

    /*
    private void OnMouseDown() {
        cg.ChangeObjectInScene(change);

        if(clicked){
            this.transform.position -= press;
        }
        print("clicker = " + clicked);
    }

    private void OnMouseUp() {
        if(clicked){
            this.transform.position += press;
            clicked = false;
        }
    }*/
    
}