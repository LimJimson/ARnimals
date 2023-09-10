using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CTF_GameManager : MonoBehaviour
{
    public static CTF_GameManager Instance { get; private set; }

    [Header("Scripts Needed")]

    [SerializeField] private CTF_ScoreManager scoreManager;
    [SerializeField] private CTF_HealthManager healthManager;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private CTF_TutorialManager tutorialManager;

    [Header("Game Objects Needed")]

    [SerializeField] private GameObject gameResumeTimerManager;
    [SerializeField] private GameObject pauseAndHPCanvas;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject optionsUICanvas;
    [SerializeField] private GameObject confirmationQuitCanvas;
    [SerializeField] private GameObject confirmationRetryCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject confirmationPlayAgainCanvas;

    [Header("UIs Needed")]

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI starsCountText;
    [SerializeField] private int minimumScoreToWin;

    private int finalScore;

    private int starsCount = 0;
    
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void IncreaseScore(int amount)
    {
        if (!isGameOver)
        {
            scoreManager.IncreaseScore(amount);
        }
    }

    public void ReduceHealth(int amount)
    {
        if (!isGameOver)
        {
            healthManager.ReduceHealth(amount);

            if (healthManager.GetHealth() <= 0)
            {
                pauseManager.PauseGame();
                gameOverCanvas.SetActive(true);
            }
        }
    }
    public void TimeUp()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            if (scoreManager.GetScore() >= minimumScoreToWin)
            {
                pauseManager.PauseGame();
                finalScore = scoreManager.GetScore();
                addStar(finalScore);
                starsCountText.text = "x" + starsCount.ToString();
                finalScoreText.text = finalScore.ToString();
                levelCompleteCanvas.SetActive(true);
            }
            else
            {
                pauseManager.PauseGame();
                gameOverCanvas.SetActive(true);
            }
        }
    }

    public void addStar(int score) 
    {
        if (score >= 20 && score < 40) 
        {
            starsCount = 1;
        }
        else if (score >= 40 && score < 60) 
        {
            starsCount = 2;
        }
        else if (score >= 60) 
        {
            starsCount = 3;
        }
    }

    //Button's functions

    public void QuitButtonFunction()
    {
        confirmationQuitCanvas.SetActive(true);
        optionsUICanvas.SetActive(false);
    }

    public void RestartButtonFunction()
    {
        confirmationRetryCanvas.SetActive(true);
        optionsUICanvas.SetActive(false);
    }

    public void CloseOptionsUIButtonFunction()
    {
        optionsUICanvas.SetActive(false);
        gameResumeTimerManager.SetActive(true);
    }

    public void SettingsButtonFunction()
    {
        optionsUICanvas.SetActive(true);
        pauseManager.PauseGame();
    }

    public void confirmQuitYesButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_LevelSelector");
    }

    public void confirmQuitNoButtonFunction()
    {
        confirmationQuitCanvas.SetActive(false);
        optionsUICanvas.SetActive(true);
    }

    public void confirmRetryYesButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_Game");
    }

    public void confirmRetryNoButtonFunction()
    {
        confirmationRetryCanvas.SetActive(false);
        optionsUICanvas.SetActive(true);
    }

    public void GameOverRetryButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_Game");
    }

    public void GameOverQuitButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_LevelSelector");
    }

    public void LevelCompletePlayAgainButtonFunction()
    {
        confirmationPlayAgainCanvas.SetActive(true);
        levelCompleteCanvas.SetActive(false);
    }

    public void LevelCompleteQuitButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_LevelSelector");
    }

    public void ConfirmationPlayAgainYesButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_Game");
    }

    public void ConfirmationPlayAgainNoButtonFunction()
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_LevelSelector");
    }

    public void helpButtonFunction() 
    {
        pauseAndHPCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
        int pageNum = tutorialManager.PageNum = 0;
        tutorialManager.PageNumTxt.text = pageNum.ToString() + "/7";
        tutorialManager.pagesContents();
        tutorialManager.disableAllGameObjects();
        pauseManager.PauseGame();
    }
}
