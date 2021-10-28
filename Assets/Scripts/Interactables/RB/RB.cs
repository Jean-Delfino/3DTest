using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RB : MonoBehaviour{
    private string rbLetter; //Easier to get
    [SerializeField] TextMeshProUGUI thisRb;
    [SerializeField] TextMeshProUGUI thisAnwserRb;

    public void Setup(string textRb){
        this.thisRb.text = rbLetter = textRb;
    }

    public string GetRBLetter(){
        return rbLetter;
    }

    public void SetAnwser(string anwser){
        thisAnwserRb.text = anwser;
    }
}
