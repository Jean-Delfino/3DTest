using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLoader : MonoBehaviour{
    //private GameObject cardLoaded
    //[SerializeField] PhaseManager phaseChange

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<Card>() != null){
            Destroy(other.gameObject);
            print("Work");
        }
    }
}
