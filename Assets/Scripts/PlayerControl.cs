using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour{   
    CharacterController controller;

    [SerializeField] Transform groundCheck = default;
    [SerializeField] LayerMask maskCollision = default;

    private float feetRadius = 0.1f;

    [SerializeField] float moveSpeedX = default;
    [SerializeField] float moveSpeedZForward = default;
    [SerializeField] float moveSpeedZDecreaceInBackward = default;
    [SerializeField] float moveSpeedY = default;
    [SerializeField] float gravity = -10f;

    private bool lockChar = false;

    Vector3 velocityY;


    void Start(){
        controller = gameObject.GetComponent<CharacterController>(); //Change the position with this
    }


    //Brackeys
    //Makes the movement
    void Update(){
        if(lockChar) return; //Lock in place if true
        
        float zSpeed = moveSpeedZForward;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if(z < 0){
            zSpeed /= moveSpeedZDecreaceInBackward;
        }

        bool groundCheck = IsGrounded();
        int groundCheckMultiplayer = 1;

        if(groundCheck){    
            groundCheckMultiplayer = 0;
            if(Input.GetButtonDown("Jump")){
                velocityY.y = Mathf.Sqrt(moveSpeedY * -2f * gravity);
            }
        }

        velocityY.y += gravity * (float) groundCheckMultiplayer *Time.deltaTime;

        Vector3 move = (transform.right * x * moveSpeedX) + (transform.forward * z * zSpeed) + velocityY;

        controller.Move(move * Time.deltaTime);
    }

    //Omnirift && Brackeys
    private bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position , feetRadius , maskCollision);
    }

    public void LockChangeCharacter(){ //Called by other components
        lockChar = !lockChar;
    }
}
