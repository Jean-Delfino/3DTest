using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDialog : InteractableMono{
    // Start is called before the first frame update
    [SerializeField] List<string> myText = default;
    [SerializeField] TextMeshProUGUI textField = default;
    int actualText = 0;
    Coroutine coroutine = null;

    public override bool DoInteraction(){
        if(myText.Count < 0 || myText == null) return false;
        ChangeText();
        return true;
    }

    private void ChangeText(){
        if(actualText > myText.Count -1){
            actualText = 0;
        }
        textField.text = myText[actualText];
        actualText++;
        //StopAllCoroutines();
        if(coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(DeleteText());

    }   

    IEnumerator DeleteText(){
        yield return new WaitForSeconds(3);

        textField.text = "";
        yield return null;
    }
}
