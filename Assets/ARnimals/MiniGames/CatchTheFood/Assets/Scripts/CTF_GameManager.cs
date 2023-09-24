using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class CTF_GameManager : MonoBehaviour
{
    public static CTF_GameManager Instance { get; private set; }

    [Header("Scripts Needed")]

    [SerializeField] private CTF_ScoreManager scoreManager;
    [SerializeField] private CTF_HealthManager healthManager;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private CTF_TutorialManager tutorialManager;
    [SerializeField] private CTF_HighScoreManager highScoreManager;

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
    [SerializeField] private int minimumScoreToWin;

    [Header("PowerUps")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject points2X;
    [SerializeField] private GameObject shieldImg;
    [SerializeField] private GameObject points2XImg;
    [SerializeField] private GameObject shieldContainer;
    [SerializeField] private GameObject points2XContainer;
    [SerializeField] private GameObject shieldDurationGameObject;
    [SerializeField] private GameObject points2XDurationGameObject;
    [SerializeField] private TextMeshProUGUI shieldDurationTxt;
    [SerializeField] private TextMeshProUGUI points2XDurationTxt;
    [SerializeField] private GameObject [] animalShieldState;
    [SerializeField] private GameObject [] animalX2State;
    [SerializeField] private Animator [] powerUpFadeAnimator;
    [SerializeField] private Image starHolder;
    [SerializeField] private Sprite[] stars;
    [SerializeField] private TextMeshProUGUI levelCompletedTxt;
    [SerializeField] private RectTransform[] x2Orders;
    [SerializeField] private RectTransform[] shieldsOrders;

    private int finalScore;
    
    private bool isGameOver = false;

    [SerializeField] private string selectedLevel;

    [SerializeField] private bool inX2PointsState = false;
    [SerializeField] private bool inShieldState = false;

    private float shieldDuration = 10f;
    private float points2XDuration = 10f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");
    }

    private void Update() 
    {
        ShieldDurationTimer();
        X2PointsDurationTimer();
        UpdatePowerUpsUI();
    }

    public float ShieldDuration 
    {
        get { return shieldDuration; }
        set { shieldDuration = value; }
    }

    public float Points2XDuration 
    {
        get { return points2XDuration; }
        set { points2XDuration = value; }
    }

    public bool InShieldState
    {
        get { return inShieldState; } 
        set { inShieldState = value; }
    }

    public bool InX2PointsState 
    {
        get { return inX2PointsState; }
        set { inX2PointsState = value; } 
    }

    public IEnumerator DisableShieldAfterdelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        InShieldState = false;
        shield.SetActive(true);
    }

    public IEnumerator DisableX2PointsAfterdelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        InX2PointsState = false;
        points2X.SetActive(true);
    }

    private void ShieldDurationTimer() 
    {
        if (InShieldState) 
        {
            shieldContainer.SetActive(true);
            shieldDuration -= Time.deltaTime;

            for(int i = 0; i < animalShieldState.Length ; i++) 
            {
                animalShieldState[i].SetActive(true);
            }

            if (shieldDuration <= 0) 
            {
                shieldContainer.SetActive(false);

                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(false);
                }
            }
            else 
            {
                shieldDurationTxt.text = shieldDuration.ToString("F0");
            }
        }
        else 
        {
            shieldContainer.SetActive(false);

            for(int i = 0; i < animalShieldState.Length ; i++) 
            {
                animalShieldState[i].SetActive(false);
            }
        }
    }

    private void X2PointsDurationTimer() 
    {
        if (InX2PointsState) 
        {
            points2XContainer.SetActive(true);
            points2XDuration -= Time.deltaTime;

            for(int i = 0; i < animalX2State.Length ; i++) 
            {
                animalX2State[i].SetActive(true);
            }

            if (points2XDuration <= 0) 
            {
                points2XContainer.SetActive(false);

                for(int i = 0; i < animalX2State.Length ; i++) 
                {
                    animalX2State[i].SetActive(false);
                }
            }
            else 
            {
                points2XDurationTxt.text = points2XDuration.ToString("F0");
            }
        }
        else 
        {
            points2XContainer.SetActive(false);

            for(int i = 0; i < animalX2State.Length ; i++) 
            {
                animalX2State[i].SetActive(false);
            }
        }
    }

    private void PowerUpsUIPosition(GameObject firstPowerUp, GameObject firstText, GameObject secondPowerUp, GameObject secondText) 
    {
        Vector3 firstPositionForIcon = new Vector3(-416f, 457f, 0f);
        Vector3 secondPositionForIcon = new Vector3(-246.5f, 458.5f, 0f);

        Vector3 firstPositionForText = new Vector3(-332.3f, 459.1f, 0f);
        Vector3 secondPositionForText = new Vector3(-162.6f, 460.9f, 0f);

        firstPowerUp.transform.localPosition = firstPositionForIcon;
        firstText.transform.localPosition = firstPositionForText;

        secondPowerUp.transform.localPosition = secondPositionForIcon;
        secondText.transform.localPosition = secondPositionForText;
    }

    private void UpdatePowerUpsUI() 
    {

        if (points2XContainer.activeSelf == true && shieldContainer.activeSelf == false) 
        {
            PowerUpsUIPosition(points2XImg, points2XDurationGameObject, shieldImg, shieldDurationGameObject);

        }
        else if (shieldContainer.activeSelf == true && points2XContainer.activeSelf == false) 
        {
            PowerUpsUIPosition(shieldImg, shieldDurationGameObject, points2XImg, points2XDurationGameObject);

        }
        else if (shieldContainer.activeSelf == true && points2XContainer.activeSelf == true) 
        {
            if (shieldDuration < points2XDuration) 
            {
                PowerUpsUIPosition(shieldImg, shieldDurationGameObject, points2XImg, points2XDurationGameObject);

                for (int i = 0; i < powerUpFadeAnimator.Length ; i++) 
                {
                    shieldsOrders[i].SetAsFirstSibling();
                    x2Orders[i].SetAsLastSibling();

                    if (powerUpFadeAnimator[i].isActiveAndEnabled) 
                    {
                        powerUpFadeAnimator[i].SetTrigger("X2FadeFirst");
                    }
                }
            }
            else 
            {
                PowerUpsUIPosition(points2XImg, points2XDurationGameObject, shieldImg, shieldDurationGameObject);

                for (int i = 0; i < powerUpFadeAnimator.Length ; i++) 
                {
                    x2Orders[i].SetAsFirstSibling();
                    shieldsOrders[i].SetAsLastSibling();

                    if (powerUpFadeAnimator[i].isActiveAndEnabled) 
                    {
                        powerUpFadeAnimator[i].SetTrigger("ShieldFadeFirst");
                    }
                }
            }
        }
    }

    private void UnlockedNextLevel() 
    {
        PlayerPrefs.SetInt("CTF_Lvl" + selectedLevel, 1);
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
                UnlockedNextLevel();
                finalScoreText.text = finalScore.ToString();
                highScoreManager.SaveHighScore(scoreManager.GetScore());
                levelCompletedTxt.text = "LEVEL <color=yellow><b>"+ selectedLevel +"</b></color> COMPLETED!";
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
            starHolder.sprite = stars[0];
        }
        else if (score >= 40 && score < 60) 
        {
            starHolder.sprite = stars[1];
        }
        else if (score >= 60) 
        {
            starHolder.sprite = stars[2];
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

    public void confirmRetryNoButtonFunction()
    {
        confirmationRetryCanvas.SetActive(false);
        optionsUICanvas.SetActive(true);
    }

    public void LevelCompletePlayAgainButtonFunction()
    {
        confirmationPlayAgainCanvas.SetActive(true);
        levelCompleteCanvas.SetActive(false);
    }

    public void LevelCompleteResumeButtonFunction()
    {
        pauseManager.ResumeGame();

        switch(selectedLevel)
        {
            case "1":
                PlayerPrefs.SetString("CTF_SelectedLevel", "2");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Pigeon");
                SceneManager.LoadScene("CTF_Game");
                break;
            case "2":
                PlayerPrefs.SetString("CTF_SelectedLevel", "3");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Koi");
                SceneManager.LoadScene("CTF_Game");
                break;
            case "3":
                PlayerPrefs.SetString("CTF_SelectedLevel", "4");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Camel");
                SceneManager.LoadScene("CTF_Game");
                break;
            case "4":
                PlayerPrefs.SetString("CTF_SelectedLevel", "5");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Crab");
                SceneManager.LoadScene("CTF_Game");
                break;
            case "5":
                ConfirmQuit();
                break;
        }
    }

    public void ConfirmPlayAgain() 
    {
        pauseManager.ResumeGame();
        SceneManager.LoadScene("CTF_Game");
    }

    public void ConfirmQuit() 
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
