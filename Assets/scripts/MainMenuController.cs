using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{


    void Update()
        {
            // Notice trigger
            if (Input.GetButtonDown("Jump"))
            {
                StartGame();
            }

            if (Input.GetButtonDown("Cancel"))
            {
                QuitGame();
            }
        }
 



    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
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