using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CTF_ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore() 
    {
        return score;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
