using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text livesText;
    public Text ScoresText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLives(int lives){
        string lives_s = "Lives: ";
        //  livesText.text = "Lives: ";
        for (int i=0; i<=lives; i++){
              lives_s += 'I';
        // livesText.text += 'I';
          }
        livesText.text = lives_s;
    }

    public void SetScores(int scores){
        Debug.Log("UI Setscores");
        ScoresText.text = "Score: " + scores;
    }

}
