using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartGame();

        if (Input.GetKeyDown(KeyCode.Q))
            QuitGame();

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