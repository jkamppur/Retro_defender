using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject menuText;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject credit1;
    public GameObject credit2;
    public GameObject title;

    private bool creditHidden = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && creditHidden)
            StartGame();

        if (Input.GetKeyDown(KeyCode.Q) && creditHidden)
            QuitGame();

        if (Input.GetKeyDown(KeyCode.C))
            HandleCredit();
    }
 
    public void HandleCredit()
    {
        if (creditHidden){
            menuText.SetActive(false);
            instruction1.SetActive(false);
            instruction2.SetActive(false);
            title.SetActive(false);
            credit1.SetActive(true);
            credit2.SetActive(true);
        } else {
            menuText.SetActive(true);
            instruction1.SetActive(true);
            instruction2.SetActive(true);
            title.SetActive(true);
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