using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : DragAndDropObject{
    // Start is called before the first frame update
    [SerializeField] int cardPhaseReference = 0;

    public override bool DoInteraction(){
        base.DoInteraction();

        return true;
    }

    public int GetCardPhaseReference(){
        return cardPhaseReference;
    }
}
