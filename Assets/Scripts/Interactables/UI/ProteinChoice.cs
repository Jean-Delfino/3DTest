using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProteinChoice : MonoBehaviour{
    // Start is called before the first frame update
    private static UILockChoice uilc;
    private int pIndexToJump; //User this variable in scene manager
    [SerializeField] TextMeshProUGUI textField = default;
    public void OnUserClick(){
        uilc.ChangeLockAndEndInteraction(pIndexToJump);
    }   

    public void OneTimeSetup(UILockChoice lockCho){
        ProteinChoice.uilc = lockCho;
    }

    public void Setup(string proteinName , int proteinIndex){
        textField.text = proteinName;
        pIndexToJump = proteinIndex;
    }
}
