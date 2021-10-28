using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{
    [SerializeField] float mouseRotation;
    [SerializeField] Transform playerBody;
    //bool cameraFree = false; //To use in the camera free treatment
    [SerializeField] Texture2D mouseTexture; 
    [SerializeField] float maximumLenght;
    [SerializeField] LayerMask interactableLayer;//Interactabel only
    float xRot = 0;

    //Brackeys
    //OXMOND Tutorials
    private void Start() {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(mouseTexture, Vector2.zero , CursorMode.ForceSoftware);
    }   

    void Update() {
        CameraMovement();
        /*
        if(Input.GetButtonDown("Cancel")){
            CameraFreeTreatment();
        }*/
        
        /*if(!cameraFree)*/ RaycastShoot();       
    }

    //Jason Weimann
    /*
    //Vector3 forw = transform.TransformDirection(Vector3.forward);
    //Physics.Raycast(rayPos , forw , out hit , maximumLenght , interactableLayer.value)
    */

    private void RaycastShoot(){ //Controls the raycast
        if((Input.GetButtonDown("Interact") || Input.GetButtonDown("Fire1"))){
            RaycastHit hit; //Shoot a raycast and use this to object detection
            Ray rayPos = Camera.main.ScreenPointToRay((Vector2) Input.mousePosition); //Get mouse pos in world
            
            if(Physics.Raycast(rayPos , out hit , maximumLenght, interactableLayer)){

                InteractiveObject IO = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if(IO != null) IO.DoInteraction(); //"Bug" control
            }
        }
    }

    private void CameraMovement(){
        float xInput = Input.GetAxis("Mouse X") * mouseRotation * Time.deltaTime;
        float yInput = Input.GetAxis("Mouse Y") * mouseRotation * Time.deltaTime;

        xRot -= yInput;
        xRot = Mathf.Clamp(xRot, -90f , 90f); //Not a owl

        playerBody.Rotate(Vector3.up * xInput);
        this.transform.localRotation = Quaternion.Euler(xRot , 0f , 0f);
    }
    /*
    private bool CameraFreeTreatment(){
        cameraFree = !cameraFree;
        if(cameraFree){
            Cursor.lockState = CursorLockMode.None;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
        }
        return cameraFree;
    }*/
}
