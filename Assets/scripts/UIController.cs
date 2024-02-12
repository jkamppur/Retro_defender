using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public Text livesText;
    public Text ScoresText;
    public Text alertText;
    public Text endReason;
    public Text endScore;

    public GameObject pauseMenu;
    public GameObject GameOverScreen;

    private static System.Timers.Timer aTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !(GameOverScreen.activeInHierarchy))
            TogglePause();

        if (Input.GetKeyDown(KeyCode.E) && (GameOverScreen.activeInHierarchy))
            ExitToMainMenu();

        if (Input.GetKeyDown(KeyCode.E) && (pauseMenu.activeInHierarchy))
            ExitToMainMenu();


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

    public void TogglePause()
    {
        if(pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void ShowGameOverScreen(string message, int score)
    {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            endReason.text = message;
            endScore.text = " " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
