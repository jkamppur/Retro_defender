using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class UIController : MonoBehaviour
{

    public Text livesText;
    public Text ScoresText;
    public Text alertText;

    private static System.Timers.Timer aTimer;

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

    public void AlertUfo(int level){

        Debug.Log("AlertUfo");

        string text = "Ufo Alert\n";

        string line2 = "";
        if (level < 0) {
            line2 += '<';
        }

        for (int i=0; i<Mathf.Abs(level); i++){
              line2 += '-';
          }

        if (level > 0) {
            line2 += ">";
        }

        if (level == 0) {
            line2 += "<>";
        }

        text += line2;

        alertText.text = text;

        StartCoroutine("AlertClear");

    }

    private IEnumerator AlertClear()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f); // wait half a second
            // do things
            Debug.Log("AlertTextClear");


            alertText.text = "";
            StopCoroutine("AlertClear");
        }
    }


}
