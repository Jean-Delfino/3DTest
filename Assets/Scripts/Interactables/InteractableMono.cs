using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableMono : MonoBehaviour, InteractiveObject{
    public virtual bool DoInteraction(){
        return true;
    }
}