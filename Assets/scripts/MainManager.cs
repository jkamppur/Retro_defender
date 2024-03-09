using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;

    private int lastScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        Debug.Log("MainManager Awake");

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateScore(int score)
    {
        lastScore = score;
        if (lastScore > highScore)
            highScore = lastScore;
    }

    public int GetLastScore() {
        return lastScore;
    }

    public int GetHighScore() {
        return highScore;
    }


}