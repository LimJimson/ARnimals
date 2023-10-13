using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CTF_HighScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject highScoreText;
	private string selectedLevel;

    [SerializeField] private int highScore;

    public int HighScore
    {
        get { return highScore; }
    }

    private void Start()
    {
		selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");
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
            PlayerPrefs.SetInt("CTF_HighScoreLvl" + selectedLevel, highScore);

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
        highScore = PlayerPrefs.GetInt("CTF_HighScoreLvl" + selectedLevel, 0);
    }
}
