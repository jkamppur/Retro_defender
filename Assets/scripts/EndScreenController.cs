using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndScreenController : MonoBehaviour
{
    public Text endScore;

    // Start is called before the first frame update
    void Start()
    {
        endScore.text = " " + GameControllerUfo.scores;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("main_menu");
    }
}
