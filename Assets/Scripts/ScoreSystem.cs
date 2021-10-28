using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour{
    int actualScore;
    // Start is called before the first frame update
    public void ChangeScore(int addScore){
        actualScore += addScore;
    }
}
