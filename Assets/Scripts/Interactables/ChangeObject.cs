using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour{
    [SerializeField] List<GameObject> images = default;
    [SerializeField] Transform spawn = default;
    int value = 0;

    public void ChangeObjectInScene(int add){
        value+=add;
        /*
        value = (value * !(!(value + 1) + !(value - images.Count))) + 
                    (!(value+1)*(images.Count-1));*/

        if(value < 0){
            value = images.Count -1;
        }else if(value > images.Count -1){
            value = 0;
        }

        Destroy(spawn.GetChild(0).gameObject);
        Instantiate(images[value] , spawn);
    }
}
