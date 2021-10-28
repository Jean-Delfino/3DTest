using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILockChoice : LockObject{
    // Start is called before the first frame update
    [SerializeField] ProteinChoice prefab = default;
    [SerializeField] Transform spawnCamp = default;


    [System.Serializable]
    private class ProteinOptions{
        public int index;
        public string name;
    }
    [SerializeField] List<ProteinOptions> pO = default;
    public override bool DoInteraction(){ //Instantiate the pOs to user choice
        if(!base.DoInteraction()) return false;
        InstantiateAll();
        return true;
    }

    public void InstantiateAll(){ //Spawn all the option of proteins
        if(pO.Count == 0 || pO == null) return;
        
        spawnCamp.gameObject.SetActive(true);
        int i = 0; //Showing all options to click
        ProteinChoice pC = Instantiate<ProteinChoice>(prefab , spawnCamp);
        
        pC.OneTimeSetup(this);
        pC.Setup(pO[i].name , pO[i].index );

        for(i = 1 ; i < pO.Count ; i++){
            pC = Instantiate<ProteinChoice>(prefab , spawnCamp);
            pC.Setup(pO[i].name , pO[i].index );
        }
    }

    public void ChangeLockAndEndInteraction(int nextScene){
        foreach(Transform chil in spawnCamp){
            Destroy(chil.gameObject);
        }spawnCamp.gameObject.SetActive(false);

        //FindObjectOfType<SceneManager>().CurrentSceneChange(nextScene);
        
        SetToStart();
        ChangeLockCharacter();
    }
}
