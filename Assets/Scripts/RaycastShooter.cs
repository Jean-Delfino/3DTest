using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Not used anymore, see Camera Control
public class RaycastShooter : MonoBehaviour{
    [SerializeField] float maximumLenght;
    [SerializeField] LayerMask interactableLayer;
    void Start(){
        
    }

    //SpeedTutor
    void Update(){
        if((Input.GetButtonDown("Interact") || Input.GetButtonDown("Fire1"))){
            RaycastHit hit;
            Vector3 forw = transform.TransformDirection(Vector3.forward);

            if(Physics.Raycast(this.transform.position , forw , out hit , maximumLenght , interactableLayer.value)){
                hit.collider.gameObject.GetComponent<InteractiveObject>().DoInteraction();
            }
        }
    }
}
