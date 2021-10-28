using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GroundTile : InteractableMono{
    // Start is called before the first frame update
    private static RBController rc;  
    [SerializeField] TextMeshProUGUI tileText;
    private Color tileColor;
    /*
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            print("Entered");
            //rb.AddLetter(letter);
        }else{
            print("Not what i wanted");
        }
    }

    private void OnTriggerExit(Collider other) {
        //rb.StartNewLetterWave();
    }*/


    public void OnlyOnceSetup(RBController rbc){
        GroundTile.rc = rbc;
    }

    public void Setup(string letter){
        tileText.text = letter;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            print("Entered");
            
            if(rc.CheckRBCorrespondent(tileText.text)){
                print("Right");
            }
        }else{
            print("Not what i wanted");
        }
    }

    private void OnCollisionExit(Collision other) {
        rc.StartNewTiles();
    }
}
