using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : MonoBehaviour , InteractiveObject{
    // Start is called before the first frame update
    private static PlayerControl pcontrol;
    [SerializeField] Color originalColor = default;
    [SerializeField] Color onInteractionColor = default;

    
    bool notInteracted = true;

    private void Start() {
        StartColor();
    }
    public virtual bool DoInteraction(){
        if(notInteracted == false){
            return false;
        }notInteracted = false;

        this.gameObject.GetComponent<Renderer>().material.color = onInteractionColor;
        LockObject.pcontrol = FindObjectOfType<PlayerControl>();

        ChangeLockCharacter();
        return true;
    }

    protected void SetToStart(){
        StartColor();
        notInteracted = true;
    }

    private void StartColor(){
        this.gameObject.GetComponent<Renderer>().material.color = originalColor;
    }
    protected void ChangeLockCharacter(){
        pcontrol.LockChangeCharacter();
    }
}
