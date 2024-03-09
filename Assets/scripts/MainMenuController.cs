using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject menuText;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject credit1;
    public GameObject credit2;
    public GameObject title;
    public Text highScoreText;
    public GameObject h_text;

    public int lastScore = 0;
    public int highScore = 0;

    private bool creditHidden = true;

    void Start()
    {
        Debug.Log("MainMenuController init");
        UpdateHighScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && creditHidden)
            StartGame();

        if (Input.GetKeyDown(KeyCode.Q) && creditHidden)
            QuitGame();

        if (Input.GetKeyDown(KeyCode.C))
            HandleCredit();
    }
 
 
    private void UpdateHighScore(){
        Debug.Log("UpdateHighScore");

        lastScore = MainManager.Instance.GetLastScore();
        highScore = MainManager.Instance.GetHighScore();

        string h_text = "Last Score: " + lastScore + "\nHigh Score: " +  highScore;
        highScoreText.text = h_text;
    }

    public void HandleCredit()
    {
        if (creditHidden){
            menuText.SetActive(false);
            instruction1.SetActive(false);
            instruction2.SetActive(false);
            title.SetActive(false);
            h_text.SetActive(false);
            credit1.SetActive(true);
            credit2.SetActive(true);
        } else {
            menuText.SetActive(true);
            instruction1.SetActive(true);
            instruction2.SetActive(true);
            title.SetActive(true);
            h_text.SetActive(true);
            credit1.SetActive(false);
            credit2.SetActive(false);
        }
        creditHidden = !creditHidden;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("level_1");
    }



    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //  Sulkee editorissa
#else
        Application.Quit(); // Sulkee exessä
#endif

    }

}