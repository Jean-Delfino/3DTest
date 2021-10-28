using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RBController : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] ScoreSystem scoreSystem; 

    [SerializeField] Transform tilesSpawn = default; //Where the tiles spawn
    GroundTile tilePrefab;

    [SerializeField] Transform rbSpawn = default; //Where the rp spawn
    [SerializeField] int numberRB = 6; //Qtd of rb
    RB prefab; //Words in the screen 
    List<RB> rbQuestions; //Anwser to the questions
    int actualRB = 0;

    [SerializeField] int additionalLetters = 2;
    Dictionary<string , string> correspondence = new Dictionary<string, string>(){
        {"C","G"},
        {"G","C"},
        {"A","T"},
        {"T","A"}
    }; //RB Correspondence

    public string RandomLetterGenerator(){ //For tiles
        char letter = 'A';
        letter += (char) Random.Range(0 , 26);
        return letter.ToString();
    }

    public string RandomRBLetter(){ //For RB
        int index = Random.Range(0 , correspondence.Count);
        return correspondence.ElementAt(index).Key;
    }
    /*
    public string RBAnwser(string anwser){
        if(!correspondence.ContainsKey(anwser)) return "ER";

        return correspondence[anwser];
    }*/
    public void StartPhase(){
        int i;

        rbQuestions.Clear();

        for(i = 0 ; i < numberRB ; i++){
            rbQuestions.Add(Instantiate<RB>(prefab , rbSpawn));
            rbQuestions[i].Setup(RandomRBLetter());
        }
    }

    public void AddLetter(string letter){
        int score = 5;
        scoreSystem.ChangeScore(score);
    }

    private void StartNewLetterWave(){
        int i;
        for(i = 0 ; i < rbQuestions.Count ; i++){
            Destroy(rbQuestions[i].gameObject);
        }rbQuestions.Clear();

        for(i = 0 ; i < numberRB ; i++){
            rbQuestions.Add(Instantiate<RB>(prefab , rbSpawn));
            rbQuestions[i].Setup(RandomRBLetter());
        }
    }

    public void StartNewTiles(){    
        int i;

        List<string> letterTiles = new List<string>(){
            {"C"}, {"G"},
            {"A"}, {"T"}
        };

        for(i = 0 ; i < additionalLetters ; i++){
            letterTiles.Add(RandomLetterGenerator());
        }

        foreach(Transform child in tilesSpawn){ //Taking out the already used tiles
            Destroy(child.gameObject);
        }

        while(letterTiles.Count > 0){
            int randomLetter = Random.Range(0 , letterTiles.Count);
            GroundTile gt = Instantiate<GroundTile>(tilePrefab , rbSpawn);
            gt.Setup(letterTiles[randomLetter]);
            letterTiles.RemoveAt(randomLetter);
        }

    }

    public bool CheckRBCorrespondent(string anwser){ //Used when user presses the tile
        if(!correspondence.ContainsKey(anwser) ||
        correspondence[anwser] != rbQuestions[actualRB].GetRBLetter()) return false;

        rbQuestions[actualRB].SetAnwser(anwser);
        actualRB++; //Set the text and increace position
        return true;
    }




}
