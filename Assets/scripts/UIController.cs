using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLives(int lives){
        Debug.Log("UI Setlives");
        livesText.text = "Lives: ";
        for (int i=0; i<=lives; i++){
            livesText.text += 'I';
        }
    }
}
