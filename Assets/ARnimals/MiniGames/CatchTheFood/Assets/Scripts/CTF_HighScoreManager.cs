using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CTF_HighScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject highScoreText;
    private const string HighScoreKey = "CTF_HighScore";

    [SerializeField] private int highScore;

    public int HighScore
    {
        get { return highScore; }
    }

    private void Start()
    {
        // Load the high score from PlayerPrefs when the game starts.
        LoadHighScore();
    }

    private void Update() 
    {
        
    }

    public void SaveHighScore(int score)
    {
        // Save the new high score if it's higher than the previous one.
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);

            highScoreText.SetActive(true);
        }
        else 
        {
            highScoreText.SetActive(false);
        }
    }

    private void LoadHighScore()
    {
        // Load the high score from PlayerPrefs.
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}
