using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using System;
using Unity.VisualScripting;

public class FTA_GameManager : MonoBehaviour
{
    public FTA_MoveAnimal MoveAnimalScript;
    [Header("Hints")]
    public Image[] shadowImgs;  // Array to hold the Image components
    public Sprite[] shadowSpritesLvl1;  // Array to hold all the sprites
    public Sprite[] shadowSpritesLvl2;
    public Sprite[] shadowSpritesLvl3;
    public Sprite[] shadowSpritesLvl4;
    public Sprite[] shadowSpritesLvl5;

    public Image[] CoverBackground;
    public Sprite[] CoverBackgroundSpritesLvl1;
    public Sprite[] CoverBackgroundSpritesLvl2;
    public Sprite[] CoverBackgroundSpritesLvl3;
    public Sprite[] CoverBackgroundSpritesLvl4;
    public Sprite[] CoverBackgroundSpritesLvl5;

    public Image[] GuideshadowImgs;
    public Image[] GuideCoverBackground;

    [Header("Items and Positions")]
    public GameObject[] items;
    int countItemFind;

    [Header("Health")]
    public int countHealth;
    public GameObject health;

    [Header("Start Game Panel")]
    public GameObject InstructionGamePanel;
    public GameObject ClickAnytoStart;
    public bool startGame;

    [Header("PopUp Position")]
    [SerializeField] private GuidePopUpAnimation guidePopUpAnimation;
    [SerializeField] private RectTransform confirmQuitPos;
    [SerializeField] private RectTransform confirmRetryPos;
    [SerializeField] private RectTransform confirmExplorePos;
    [SerializeField] private RectTransform confirmPlayAgainPos;
    [SerializeField] private RectTransform confirmARPos;

    

    SaveObject SaveFTAGame;

    AudioManager audioManager;

    private Vector3[] positions;

    public bool CheckIfFisrtItemGuide;

    int currentStar;
    private void Start()
    {
        SaveFTAGame = SaveManager.Load();
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            if (audioManager.musicSource.isPlaying)
            {

            }
            else
            {
                audioManager.playBGMMusic(audioManager.FTA_BGM_Main);
            }
        }
        catch
        {
            Debug.Log("No AudioManager");
        }
        
        guide_chosen = SaveFTAGame.guideChosen;
        HintsLeft = 1;
        SelectedLevel = PlayerPrefs.GetString("FTA_SelectedLevel");
        currentStar = PlayerPrefs.GetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 0);
        SelectedArraySprites();
        CheckLevel();
        initializePositionsofItems();
        RandomlyAssignSprites();
        RandomlyAssignPositionToItems();
        countHealth = health.transform.childCount;
        settingsMenuObject.SetActive(false);
        InstructionGamePanel.SetActive(true);
        Invoke("StartCountdownStarts", 0.8f);
        if (!SaveFTAGame.FTA_GAME_GUIDE)
        {
            SaveFTAGame = SaveManager.Load();
            SaveFTAGame.FTA_GAME_GUIDE = true;
            SaveManager.Save(SaveFTAGame);
            CheckIfFisrtItemGuide = true;
            InstructionGamePanel.SetActive(false);
            FTAHelpButton();
        }
        
    }
    private void Update()
    {
        countdownStarts();
        if (SelectedLevel == "5")
        {
            NextLevelBtn.interactable = false;
        }
        if (startGame == true && !isGameOver && !isPaused && countItemFind < 3)
        {
            timer += Time.deltaTime;
            DisplayTimer();

            // Check if the time has run out and trigger your game over logic here if needed.
            if (timer >= timeLimit)
            {
                GameOver();
                try
                {
                    audioManager.PlaySFX(audioManager.loseLevel);
                    audioManager.musicSource.Stop();
                }
                catch
                {
                     
                }
            }
        }
        countdownHints();
        if (InstructionGamePanel.activeSelf == true)
        {
            Invoke("ClickToStart", 3f);
        }

        enableGameOverGOs();
        enableLvlCompleteGOs();
    }

    [SerializeField] private GameObject[] levelCompleteGOs;
    private float enablerTimerLvlComplete = 0.7f;

    private void enableLvlCompleteGOs() 
    {
        if(panelFinish.activeSelf) 
        {
            levelCompleteGOs[0].SetActive(true);

            if (enablerTimerLvlComplete > 0f)
            {
                enablerTimerLvlComplete -= Time.unscaledDeltaTime;
            }
            else 
            {
                if (levelCompleteGOs[1].activeSelf) 
                {
                    levelCompleteGOs[2].SetActive(true);
                }
                else 
                {
                    levelCompleteGOs[1].SetActive(true);
                    enablerTimerLvlComplete = 0.7f;
                }
            }
        }
    }

    [SerializeField] private GameObject[] gameOverGOs;
    private float enablerTimerGameOver = 0.7f;

    private void enableGameOverGOs() 
    {
        if(panelGameOver.activeSelf) 
        {
            gameOverGOs[0].SetActive(true);

            if (enablerTimerGameOver > 0f)
            {
                enablerTimerGameOver -= Time.unscaledDeltaTime;
            }
            else 
            {
                gameOverGOs[1].SetActive(true);
            }
        }
    }

    private void initializePositionsofItems()
    {
        positions = new Vector3[]{
        items[0].transform.localPosition, items[1].transform.localPosition, items[2].transform.localPosition, items[3].transform.localPosition, items[4].transform.localPosition};
    }

    private void RandomlyAssignPositionToItems()
    {
        ShufflePositions(positions); // Shuffle the positions randomly.

        // Assign each shuffled position to a game object.
        for (int i = 0; i < items.Length; i++)
        {
            if (i < positions.Length)
            {
                items[i].transform.localPosition = positions[i];
            }
            else
            {
                // Handle the case where there are more game objects than positions.
                Debug.LogWarning("Not enough positions for all game objects.");
            }
        }
    }

    // Shuffle an array using the Fisher-Yates algorithm.
    private void ShufflePositions(Vector3[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int j = UnityEngine.Random.Range(i, n);
            Vector3 temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
    private void RandomlyAssignSprites()
    {
        ShuffleSprites(SelectedArraySprites());

        // Make sure we have enough images for the sprites
        int numberOfshadowImgs = Mathf.Min(shadowImgs.Length, SelectedArraySprites().Length);

        for (int i = 0; i < numberOfshadowImgs; i++)
        {
            shadowImgs[i].sprite = SelectedArraySprites()[i];
            shadowImgContainerTrivia[i].sprite = SelectedArraySprites()[i];
            GuideshadowImgs[i].sprite = SelectedArraySprites()[i];
        }
    }
    // Shuffle the array using Fisher-Yates algorithm
    private void ShuffleSprites(Sprite[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Sprite temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    Sprite[] SelectedSprites;
    private Sprite[] SelectedArraySprites()
    {
        SelectedSprites = shadowSpritesLvl1;
        switch (SelectedLevel)
        {
            case "1":
                SelectedSprites = shadowSpritesLvl1;
                break;
            case "2":
                SelectedSprites = shadowSpritesLvl2;
                break;
            case "3":
                SelectedSprites = shadowSpritesLvl3;
                break;
            case "4":
                SelectedSprites = shadowSpritesLvl4;
                break;
            case "5":
                SelectedSprites = shadowSpritesLvl5;
                break;
        }
        return SelectedSprites;
    }

    public void settingsBtnFunction()
    {
        SceneManager.LoadScene("FTA_Game");
    }

    public void checkIfCorrect(GameObject clickedAnimal)
    {

        Image clickedAnimalImg = clickedAnimal.GetComponent<Image>();

        Color enableCorrectAnswer = new Color(1.0f, 1.0f, 1.0f);
        
        if (clickedAnimalImg.sprite == shadowImgs[0].sprite)
        {
            MoveAnimalScript.MovingAnimal(clickedAnimal, new Vector2(-17, 250), shadowImgs[0]);
            Debug.Log("Correct");
            //clickedAnimal.SetActive(false);
            try
            {
                audioManager.PlaySFX(audioManager.correctAnswer);
            }
            catch
            {

            }
        }
        else if (clickedAnimalImg.sprite == shadowImgs[1].sprite)
        {
            Debug.Log("Correct");
            MoveAnimalScript.MovingAnimal(clickedAnimal, new Vector2(267, 250), shadowImgs[1]);
            //clickedAnimal.SetActive(false);
            try
            {
                audioManager.PlaySFX(audioManager.correctAnswer);
            }
            catch
            {

            }
        }
        else if (clickedAnimalImg.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("Correct");
            MoveAnimalScript.MovingAnimal(clickedAnimal, new Vector2(526, 250), shadowImgs[2]);
            //clickedAnimal.SetActive(false);
            try
            {
                audioManager.PlaySFX(audioManager.correctAnswer);
            }
            catch
            {

            }
        }
        else
        {
            if (countHealth > 1)
            {
                health.transform.GetChild(countHealth - 1).GetComponent<Image>().color = Color.black;
                countHealth--;
                DisplayWrongAnswerEffect();
                try
                {
                    audioManager.PlaySFX(audioManager.wrongAnswer);
                }
                catch
                {

                }
            }
            else
            {
                health.transform.GetChild(countHealth - 1).GetComponent<Image>().color = Color.black;
                countHealth--;
                GameOver();
                try
                {
                    audioManager.PlaySFX(audioManager.loseLevel);
                    audioManager.musicSource.Stop();
                }
                catch
                {

                }
            }
        }
        checkIfAllFound();
    }
    public void checkIfAllFound()
    {
        Color enableCorrectAnswer = new Color(1.0f, 1.0f, 1.0f);
        if (shadowImgs[0].color == enableCorrectAnswer && shadowImgs[1].color == enableCorrectAnswer && shadowImgs[2].color == enableCorrectAnswer)
        {
            randomNum = UnityEngine.Random.Range(0, 2);
            checkStar();
            openTriviaCanvas();
            checkCurrentStar();
        }
    }

    [Header("Panel/Settings")]
    public GameObject panelGameOver;
    public GameObject panelFinish;
    private bool isGameOver = false;
    private bool isPaused = false;
    public GameObject settingsMenuObject;
    public GameObject wrongAnswerPanel;
    public GameObject GameOverBoyGuide;
    public GameObject GameOverGirlGuide;
    public void GameOver()
    {
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);
        if (guide_chosen == "boy_guide")
        {
            GameOverBoyGuide.SetActive(true);
            GameOverGirlGuide.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            GameOverBoyGuide.SetActive(false);
            GameOverGirlGuide.SetActive(true);
        }
        panelGameOver.SetActive(true);
    }
    private void GameWin()
    {
        AnimaltoUnlock();
        try
        {
            audioManager.PlaySFX(audioManager.winLevel);
            audioManager.musicSource.Stop();
        }
        catch
        {

        }
        panelFinish.SetActive(true);
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        settingsMenuObject.SetActive(true);
        audioManager.sfxSource.Pause();
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingsMenuObject.SetActive(false);
        audioManager.sfxSource.UnPause();
    }
    public void RestartGame()
    {
        if (guide_chosen == "boy_guide")
        {
            guide_boy_restart.SetActive(true);
            guide_girl_restart.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            guide_boy_restart.SetActive(false);
            guide_girl_restart.SetActive(true);
        }

        guidePopUpAnimation.showGuidePopUp(confirmRetryPos, RestartGuideConfirm, settingsMenuObject);
    }
    public void QuitGame()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_lvlSelect");
        audioManager.musicSource.Stop();
    }

    [Header("Guides")]
    public GameObject QuitGuideConfirm;
    public GameObject guide_boy_quit;
    public GameObject guide_girl_quit;
    public void ConfirmationQuit()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_lvlSelect");
        try 
        {
            audioManager.musicSource.Stop();
            audioManager.sfxSource.Stop();
        }
        catch
        {

        }
    }

    public GameObject RestartGuideConfirm;
    public GameObject guide_boy_restart;
    public GameObject guide_girl_restart;
    public void ConfirmRestart()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_Game");
        audioManager.sfxSource.Stop();
    }
    public void CloseConfirmRestart()
    {
        guidePopUpAnimation.hideGuidePopUp(confirmRetryPos, RestartGuideConfirm, settingsMenuObject);
    }

    private string confirmQuitCode;

    public void QuitButtonFunction()
    {
        if (guide_chosen == "boy_guide")
        {
            guide_boy_quit.SetActive(true);
            guide_girl_quit.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            guide_boy_quit.SetActive(false);
            guide_girl_quit.SetActive(true);
        }

        if (settingsMenuObject.activeSelf)
        {
            settingsMenuObject.SetActive(false);
            confirmQuitCode = "OptionsUI";
        }

        if (panelGameOver.activeSelf)
        {
            panelGameOver.SetActive(false);
            confirmQuitCode = "GameOverUI";
        }

        if (panelFinish.activeSelf)
        {
            panelFinish.SetActive(false);
            confirmQuitCode = "LevelCompleteUI";
        }

        guidePopUpAnimation.showGuidePopUp(confirmQuitPos, QuitGuideConfirm);
    }

    public void confirmQuitNoButtonFunction()
    {

        GameObject[] canvasToEnable = {settingsMenuObject, panelGameOver, panelFinish};
        guidePopUpAnimation.hideGuidePopUp(confirmQuitCode, confirmQuitPos, QuitGuideConfirm, canvasToEnable);
    }

    
    public void GameOverPlayAgain()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_Game");
    }
    public void GameOverQuit()
    {
        QuitGuideConfirm.SetActive(true);
        panelGameOver.SetActive(false);
    }
    public void CloseGameOverQuit()
    {
        QuitGuideConfirm.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public GameObject ExploreGuidePanel;
    public GameObject guide_boy_explore;
    public GameObject guide_girl_explore;
    public void ExploreBtnGuide()
    {
        ResumeGame();
        guidePopUpAnimation.showGuidePopUp(confirmExplorePos, ExploreGuidePanel, panelGameOver);
        if (guide_chosen == "boy_guide")
        {
            guide_boy_explore.SetActive(true);
            guide_girl_explore.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            guide_boy_explore.SetActive(false);
            guide_girl_explore.SetActive(true);
        }
    }
    public void ExploreBtn()
    {
        ResumeGame();
        SceneManager.LoadScene("Animal_Information");
        audioManager.musicSource.Stop();
    }
    public void CloseExploreBtn()
    {
        guidePopUpAnimation.hideGuidePopUp(confirmExplorePos, ExploreGuidePanel, panelGameOver);
    }

    //Panel Effects
    private void DisplayWrongAnswerEffect()
    {
        StartCoroutine(ShowWrongAnswerPanel());
    }

    private IEnumerator ShowWrongAnswerPanel()
    {
        wrongAnswerPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrongAnswerPanel.SetActive(false);
    }


    [Header("TimerTick")]
    private float timer = 0f;
    public float timeLimit = 60f;
    public Text timerText;
    bool tenSecondsLeft;

    private void DisplayTimer()
    {
        float remainingTime = Mathf.Max(0f, timeLimit - timer);
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (!tenSecondsLeft && remainingTime <= 11.0f)
        {
            tenSecondsLeft = true;
            try
            {
                audioManager.PlaySFX(audioManager.FTA_Countdown);
                audioManager.musicSource.Stop();
            }
            catch
            {

            }
        }
        if (remainingTime == 0)
        {
            audioManager.sfxSource.Stop();
        }

        if (timerText != null)
        {
            timerText.text = timeText;
        }
    }

    [Header("Levels")]
    public Image Background;
    public Sprite[] BackgroundImgs;
    private string SelectedLevel;
    public Vector3[] CoverBgPositionForLevel1;
    public Vector3[] CoverBgPositionForLevel2;
    public Vector3[] CoverBgPositionForLevel3;
    public Vector3[] CoverBgPositionForLevel4;
    public Vector3[] CoverBgPositionForLevel5;

    public Vector3[] AnimalPositionLvl1;
    public Vector3[] AnimalPositionLvl2;
    public Vector3[] AnimalPositionLvl3;
    public Vector3[] AnimalPositionLvl4;
    public Vector3[] AnimalPositionLvl5;

    public TMP_Text LevelCompletedText;
    public Button NextLevelBtn;

    Image animal1;
    Image animal2;
    Image animal3;
    Image animal4;
    Image animal5;
    private void CheckLevel()
    {
        SelectedLevel = PlayerPrefs.GetString("FTA_SelectedLevel");
        animal1 = items[0].GetComponent<Image>();
        animal2 = items[1].GetComponent<Image>();
        animal3 = items[2].GetComponent<Image>();
        animal4 = items[3].GetComponent<Image>();
        animal5 = items[4].GetComponent<Image>();

        LevelCompletedText.text = "LEVEL <color=yellow><b>" + SelectedLevel + "</b></color> COMPLETED!";

        switch (SelectedLevel)
        {
            case "1":
                Background.sprite = BackgroundImgs[0];
                animal1.sprite = shadowSpritesLvl1[0];
                animal1.transform.localPosition = AnimalPositionLvl1[0];
                animal2.sprite = shadowSpritesLvl1[1];
                animal2.transform.localPosition = AnimalPositionLvl1[1];
                animal3.sprite = shadowSpritesLvl1[2];
                animal3.transform.localPosition = AnimalPositionLvl1[2];
                animal4.sprite = shadowSpritesLvl1[3];
                animal4.transform.localPosition = AnimalPositionLvl1[3];
                animal5.sprite = shadowSpritesLvl1[4];
                animal5.transform.localPosition = AnimalPositionLvl1[4];

                CoverBackground[0].sprite = CoverBackgroundSpritesLvl1[0];
                CoverBackground[0].transform.localPosition = CoverBgPositionForLevel1[0];
                CoverBackground[1].sprite = CoverBackgroundSpritesLvl1[1];
                CoverBackground[1].transform.localPosition = CoverBgPositionForLevel1[1];
                CoverBackground[2].sprite = CoverBackgroundSpritesLvl1[2];
                CoverBackground[2].transform.localPosition = CoverBgPositionForLevel1[2];
                CoverBackground[3].sprite = CoverBackgroundSpritesLvl1[3];
                CoverBackground[3].transform.localPosition = CoverBgPositionForLevel1[3];
                CoverBackground[4].sprite = CoverBackgroundSpritesLvl1[4];
                CoverBackground[4].transform.localPosition = CoverBgPositionForLevel1[4];

                GuideCoverBackground[0].sprite = CoverBackgroundSpritesLvl1[0];
                GuideCoverBackground[0].transform.localPosition = CoverBgPositionForLevel1[0];
                GuideCoverBackground[1].sprite = CoverBackgroundSpritesLvl1[1];
                GuideCoverBackground[1].transform.localPosition = CoverBgPositionForLevel1[1];
                GuideCoverBackground[2].sprite = CoverBackgroundSpritesLvl1[2];
                GuideCoverBackground[2].transform.localPosition = CoverBgPositionForLevel1[2];
                GuideCoverBackground[3].sprite = CoverBackgroundSpritesLvl1[3];
                GuideCoverBackground[3].transform.localPosition = CoverBgPositionForLevel1[3];
                GuideCoverBackground[4].sprite = CoverBackgroundSpritesLvl1[4];
                GuideCoverBackground[4].transform.localPosition = CoverBgPositionForLevel1[4];

                break;
            case "2":
                Background.sprite = BackgroundImgs[1];
                animal1.sprite = shadowSpritesLvl2[0];
                animal1.transform.localPosition = AnimalPositionLvl2[0];
                animal2.sprite = shadowSpritesLvl2[1];
                animal2.transform.localPosition = AnimalPositionLvl2[1];
                animal3.sprite = shadowSpritesLvl2[2];
                animal3.transform.localPosition = AnimalPositionLvl2[2];
                animal4.sprite = shadowSpritesLvl2[3];
                animal4.transform.localPosition = AnimalPositionLvl2[3];
                animal5.sprite = shadowSpritesLvl2[4];
                animal5.transform.localPosition = AnimalPositionLvl2[4];

                CoverBackground[0].sprite = CoverBackgroundSpritesLvl2[0];
                CoverBackground[0].transform.localPosition = CoverBgPositionForLevel2[0];
                CoverBackground[1].sprite = CoverBackgroundSpritesLvl2[1];
                CoverBackground[1].transform.localPosition = CoverBgPositionForLevel2[1];
                CoverBackground[2].sprite = CoverBackgroundSpritesLvl2[2];
                CoverBackground[2].transform.localPosition = CoverBgPositionForLevel2[2];
                CoverBackground[3].sprite = CoverBackgroundSpritesLvl2[3];
                CoverBackground[3].transform.localPosition = CoverBgPositionForLevel2[3];
                CoverBackground[4].sprite = CoverBackgroundSpritesLvl2[4];
                CoverBackground[4].transform.localPosition = CoverBgPositionForLevel2[4];

                GuideCoverBackground[0].sprite = CoverBackgroundSpritesLvl2[0];
                GuideCoverBackground[0].transform.localPosition = CoverBgPositionForLevel2[0];
                GuideCoverBackground[1].sprite = CoverBackgroundSpritesLvl2[1];
                GuideCoverBackground[1].transform.localPosition = CoverBgPositionForLevel2[1];
                GuideCoverBackground[2].sprite = CoverBackgroundSpritesLvl2[2];
                GuideCoverBackground[2].transform.localPosition = CoverBgPositionForLevel2[2];
                GuideCoverBackground[3].sprite = CoverBackgroundSpritesLvl2[3];
                GuideCoverBackground[3].transform.localPosition = CoverBgPositionForLevel2[3];
                GuideCoverBackground[4].sprite = CoverBackgroundSpritesLvl2[4];
                GuideCoverBackground[4].transform.localPosition = CoverBgPositionForLevel2[4];

                break;
            case "3":
                Background.sprite = BackgroundImgs[2];
                animal1.sprite = shadowSpritesLvl3[0];
                animal1.transform.localPosition = AnimalPositionLvl3[0];
                animal2.sprite = shadowSpritesLvl3[1];
                animal2.transform.localPosition = AnimalPositionLvl3[1];
                animal3.sprite = shadowSpritesLvl3[2];
                animal3.transform.localPosition = AnimalPositionLvl3[2];
                animal4.sprite = shadowSpritesLvl3[3];
                animal4.transform.localPosition = AnimalPositionLvl3[3];
                animal5.sprite = shadowSpritesLvl3[4];
                animal5.transform.localPosition = AnimalPositionLvl3[4];

                CoverBackground[0].sprite = CoverBackgroundSpritesLvl3[0];
                CoverBackground[0].transform.localPosition = CoverBgPositionForLevel3[0];
                CoverBackground[1].sprite = CoverBackgroundSpritesLvl3[1];
                CoverBackground[1].transform.localPosition = CoverBgPositionForLevel3[1];
                CoverBackground[2].sprite = CoverBackgroundSpritesLvl3[2];
                CoverBackground[2].transform.localPosition = CoverBgPositionForLevel3[2];
                CoverBackground[3].sprite = CoverBackgroundSpritesLvl3[3];
                CoverBackground[3].transform.localPosition = CoverBgPositionForLevel3[3];
                CoverBackground[4].sprite = CoverBackgroundSpritesLvl3[4];
                CoverBackground[4].transform.localPosition = CoverBgPositionForLevel3[4];

                GuideCoverBackground[0].sprite = CoverBackgroundSpritesLvl3[0];
                GuideCoverBackground[0].transform.localPosition = CoverBgPositionForLevel3[0];
                GuideCoverBackground[1].sprite = CoverBackgroundSpritesLvl3[1];
                GuideCoverBackground[1].transform.localPosition = CoverBgPositionForLevel3[1];
                GuideCoverBackground[2].sprite = CoverBackgroundSpritesLvl3[2];
                GuideCoverBackground[2].transform.localPosition = CoverBgPositionForLevel3[2];
                GuideCoverBackground[3].sprite = CoverBackgroundSpritesLvl3[3];
                GuideCoverBackground[3].transform.localPosition = CoverBgPositionForLevel3[3];
                GuideCoverBackground[4].sprite = CoverBackgroundSpritesLvl3[4];
                GuideCoverBackground[4].transform.localPosition = CoverBgPositionForLevel3[4];

                break;
            case "4":
                Background.sprite = BackgroundImgs[3];
                animal1.sprite = shadowSpritesLvl4[0];
                animal1.transform.localPosition = AnimalPositionLvl4[0];
                animal2.sprite = shadowSpritesLvl4[1];
                animal2.transform.localPosition = AnimalPositionLvl4[1];
                animal3.sprite = shadowSpritesLvl4[2];
                animal3.transform.localPosition = AnimalPositionLvl4[2];
                animal4.sprite = shadowSpritesLvl4[3];
                animal4.transform.localPosition = AnimalPositionLvl4[3];
                animal5.sprite = shadowSpritesLvl4[4];
                animal5.transform.localPosition = AnimalPositionLvl4[4];

                CoverBackground[0].sprite = CoverBackgroundSpritesLvl4[0];
                CoverBackground[0].transform.localPosition = CoverBgPositionForLevel4[0];
                CoverBackground[1].sprite = CoverBackgroundSpritesLvl4[1];
                CoverBackground[1].transform.localPosition = CoverBgPositionForLevel4[1];
                CoverBackground[2].sprite = CoverBackgroundSpritesLvl4[2];
                CoverBackground[2].transform.localPosition = CoverBgPositionForLevel4[2];
                CoverBackground[3].sprite = CoverBackgroundSpritesLvl4[3];
                CoverBackground[3].transform.localPosition = CoverBgPositionForLevel4[3];
                CoverBackground[4].sprite = CoverBackgroundSpritesLvl4[4];
                CoverBackground[4].transform.localPosition = CoverBgPositionForLevel4[4];

                GuideCoverBackground[0].sprite = CoverBackgroundSpritesLvl4[0];
                GuideCoverBackground[0].transform.localPosition = CoverBgPositionForLevel4[0];
                GuideCoverBackground[1].sprite = CoverBackgroundSpritesLvl4[1];
                GuideCoverBackground[1].transform.localPosition = CoverBgPositionForLevel4[1];
                GuideCoverBackground[2].sprite = CoverBackgroundSpritesLvl4[2];
                GuideCoverBackground[2].transform.localPosition = CoverBgPositionForLevel4[2];
                GuideCoverBackground[3].sprite = CoverBackgroundSpritesLvl4[3];
                GuideCoverBackground[3].transform.localPosition = CoverBgPositionForLevel4[3];
                GuideCoverBackground[4].sprite = CoverBackgroundSpritesLvl4[4];
                GuideCoverBackground[4].transform.localPosition = CoverBgPositionForLevel4[4];

                break;
            case "5":
                Background.sprite = BackgroundImgs[4];
                animal1.sprite = shadowSpritesLvl5[0];
                animal1.transform.localPosition = AnimalPositionLvl5[0];
                animal2.sprite = shadowSpritesLvl5[1];
                animal2.transform.localPosition = AnimalPositionLvl5[1];
                animal3.sprite = shadowSpritesLvl5[2];
                animal3.transform.localPosition = AnimalPositionLvl5[2];
                animal4.sprite = shadowSpritesLvl5[3];
                animal4.transform.localPosition = AnimalPositionLvl5[3];
                animal5.sprite = shadowSpritesLvl5[4];
                animal5.transform.localPosition = AnimalPositionLvl5[4];

                CoverBackground[0].sprite = CoverBackgroundSpritesLvl5[0];
                CoverBackground[0].transform.localPosition = CoverBgPositionForLevel5[0];
                CoverBackground[1].sprite = CoverBackgroundSpritesLvl5[1];
                CoverBackground[1].transform.localPosition = CoverBgPositionForLevel5[1];
                CoverBackground[2].sprite = CoverBackgroundSpritesLvl5[2];
                CoverBackground[2].transform.localPosition = CoverBgPositionForLevel5[2];
                CoverBackground[3].sprite = CoverBackgroundSpritesLvl5[3];
                CoverBackground[3].transform.localPosition = CoverBgPositionForLevel5[3];
                CoverBackground[4].sprite = CoverBackgroundSpritesLvl5[4];
                CoverBackground[4].transform.localPosition = CoverBgPositionForLevel5[4];

                GuideCoverBackground[0].sprite = CoverBackgroundSpritesLvl5[0];
                GuideCoverBackground[0].transform.localPosition = CoverBgPositionForLevel5[0];
                GuideCoverBackground[1].sprite = CoverBackgroundSpritesLvl5[1];
                GuideCoverBackground[1].transform.localPosition = CoverBgPositionForLevel5[1];
                GuideCoverBackground[2].sprite = CoverBackgroundSpritesLvl5[2];
                GuideCoverBackground[2].transform.localPosition = CoverBgPositionForLevel5[2];
                GuideCoverBackground[3].sprite = CoverBackgroundSpritesLvl5[3];
                GuideCoverBackground[3].transform.localPosition = CoverBgPositionForLevel5[3];
                GuideCoverBackground[4].sprite = CoverBackgroundSpritesLvl5[4];
                GuideCoverBackground[4].transform.localPosition = CoverBgPositionForLevel5[4];

                break;
        }
    }
    public void NextLevel()
    {
        switch (SelectedLevel)
        {
            case "1":
                PlayerPrefs.SetString("FTA_SelectedLevel", "2");
                SceneManager.LoadScene("FTA_Game");
                break;
            case "2":
                PlayerPrefs.SetString("FTA_SelectedLevel", "3");
                SceneManager.LoadScene("FTA_Game");
                break;
            case "3":
                PlayerPrefs.SetString("FTA_SelectedLevel", "4");
                SceneManager.LoadScene("FTA_Game");
                break;
            case "4":
                PlayerPrefs.SetString("FTA_SelectedLevel", "5");
                SceneManager.LoadScene("FTA_Game");
                break;
            case "5":

                break;
        }
    }

    //========HINT=========//

    public Button ButtonHint;
    public void HintBtn()
    {
        Color CorrectAnswerNotFound = new Color(0f, 0f, 0f);
        if (animal1.gameObject.activeSelf && animal1.sprite == shadowImgs[0].sprite || animal1.gameObject.activeSelf && animal1.sprite == shadowImgs[1].sprite || animal1.gameObject.activeSelf && animal1.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("showhint");
            if (shadowImgs[0].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal1));
            }
            else if (shadowImgs[1].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal1));
            }
            else if (shadowImgs[2].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal1));
            }
        }
        else if (animal2.gameObject.activeSelf && animal2.sprite == shadowImgs[0].sprite || animal2.gameObject.activeSelf && animal2.sprite == shadowImgs[1].sprite || animal2.gameObject.activeSelf && animal2.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("showhint2");
            if (shadowImgs[0].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal2));
            }
            else if (shadowImgs[1].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal2));
            }
            else if (shadowImgs[2].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal2));
            }
        }
        else if (animal3.gameObject.activeSelf && animal3.sprite == shadowImgs[0].sprite || animal3.gameObject.activeSelf && animal3.sprite == shadowImgs[1].sprite || animal3.gameObject.activeSelf && animal3.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("showhint3");
            if (shadowImgs[0].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal3));
            }
            else if (shadowImgs[1].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal3));
            }
            else if (shadowImgs[2].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal3));
            }
        }
        else if (animal4.gameObject.activeSelf && animal4.sprite == shadowImgs[0].sprite || animal4.gameObject.activeSelf && animal4.sprite == shadowImgs[1].sprite || animal4.gameObject.activeSelf && animal4.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("showhint4");
            if (shadowImgs[0].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal4));
            }
            else if (shadowImgs[1].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal4));
            }
            else if (shadowImgs[2].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal4));
            }
        }
        else if (animal5.gameObject.activeSelf && animal5.sprite == shadowImgs[0].sprite || animal5.gameObject.activeSelf && animal5.sprite == shadowImgs[1].sprite || animal5.gameObject.activeSelf && animal5.sprite == shadowImgs[2].sprite)
        {
            Debug.Log("showhint5");
            if (shadowImgs[0].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal5));
            }
            else if (shadowImgs[1].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal5));
            }
            else if (shadowImgs[2].color == CorrectAnswerNotFound)
            {
                StartCoroutine(ShowHint(animal5));
            }
        }
    }
    public IEnumerator ShowHint(Image shawdowImage)
    {
        Vector3 originalSize = shawdowImage.transform.localScale;
        Vector3 doubleSize = shawdowImage.transform.localScale = shawdowImage.transform.localScale * 1.5f;

        shawdowImage.transform.localScale = doubleSize;
        yield return new WaitForSeconds(3.0f);
        shawdowImage.transform.localScale = originalSize;
    }

    public TMP_Text hintsTxt;
    public GameObject hintsGO;
    public Animator hintsAnim;

    public GameObject hintGuideBoy;
    public GameObject hintGuideGirl;

    public string guide_chosen;
    int HintsLeft;
    public void hintBtn()
    {
        if (guide_chosen == "boy_guide")
        {
            hintGuideBoy.SetActive(true);
            hintGuideGirl.SetActive(false);
            hintTxt();
        }
        else if (guide_chosen == "girl_guide")
        {
            hintGuideBoy.SetActive(false);
            hintGuideGirl.SetActive(true);
            hintTxt();
        }
        else if (string.IsNullOrEmpty(guide_chosen))
        {
            hintGuideBoy.SetActive(true);
            hintGuideGirl.SetActive(false);
            hintTxt();
        }
    }
    public TextMeshProUGUI HintNumbertxt;

    void hintTxt()
    {
        if (HintsLeft != 0)
        {
            Debug.Log("noooh");
            HintsLeft -= 1;
            HintBtn();
            //hintsTxt.text = "<color=#FFFF00>" + HintsLeft + " </color>hint left";
            hintsTxt.text = "No more hints left";
            StartCoroutine(_showHintLeft());
        }
        else if (HintsLeft == 0)
        {
            try
            {
                audioManager.PlaySFX(audioManager.wrongAnswer);
            }
            catch
            {

            }
            hintsTxt.text = "No more hints left";
            StartCoroutine(_showHintLeft());
        }
        HintNumbertxt.text = HintsLeft + "/1";
    }
    IEnumerator _showHintLeft()
    {
        hintsGO.SetActive(true);
        yield return new WaitForSeconds(1f);
        hintsAnim.SetTrigger("HintsOut");
        yield return new WaitForSeconds(1f);
        hintsGO.SetActive(false);
    }

    public TMP_Text timerHints;
    bool isHintsTimerCounting = false;
    float countdownTimeHints = 10.0f;
    public Button HintsButton;

    void countdownHints()
    {
        if (isHintsTimerCounting)
        {
            countdownTimeHints -= Time.deltaTime;

            if (countdownTimeHints <= 0)
            {
                countdownTimeHints = 10.0f;
                isHintsTimerCounting = false;
                timerHints.gameObject.SetActive(false);
                HintsButton.interactable = true;

            }

            UpdateTimerText();
        }
    }

    public void StartCountdownHints()
    {
        if (HintsLeft != 0)
        {
            isHintsTimerCounting = true;
            countdownHints();
            timerHints.gameObject.SetActive(true);
            HintsButton.interactable = false;
        }

    }
    private void UpdateTimerText()
    {
        timerHints.text = Convert.ToInt16(countdownTimeHints).ToString();
    }


    [Header("Stars")]
    [SerializeField] private Image starHolder;
    [SerializeField] private Sprite[] stars;
    [SerializeField] private GameObject checkGameObjectlvl;
    [SerializeField] private Image levelbordercompletedholder;
    [SerializeField] private Sprite[] levelborderimages;
    [SerializeField] private TextMeshProUGUI twostarstounlock;
    [SerializeField] private TextMeshProUGUI NoAvailLevel;

    void checkStar()
    {
        SaveFTAGame = SaveManager.Load();
        if (countHealth == 3)
        {
            starHolder.sprite = stars[2];
            if (currentStar < countHealth)
            {
                PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel, 1);
                switch (SelectedLevel)
                {
                    case "1":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isLeopardUnlock = true;
                        levelbordercompletedholder.sprite = levelborderimages[0];
                        break;
                    case "2":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isPigeonUnlock = true;
                        levelbordercompletedholder.sprite = levelborderimages[1];
                        break;
                    case "3":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isPiranhaUnlock = true;
                        levelbordercompletedholder.sprite = levelborderimages[2];
                        break;
                    case "4":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isBearUnlock = true;
                        levelbordercompletedholder.sprite = levelborderimages[3];
                        break;
                    case "5":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isOwlUnlock = true;
                        twostarstounlock.enabled = false;
                        levelbordercompletedholder.enabled = false;
                        break;
                }
            }
        }
        else if (countHealth == 2)
        {
            starHolder.sprite = stars[1];
            if (currentStar < countHealth)
            {
                PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel, 1);
                switch (SelectedLevel)
                {
                    case "1":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        levelbordercompletedholder.sprite = levelborderimages[0];
                        break;
                    case "2":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        levelbordercompletedholder.sprite = levelborderimages[1];
                        break;
                    case "3":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        levelbordercompletedholder.sprite = levelborderimages[2];
                        break;
                    case "4":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        levelbordercompletedholder.sprite = levelborderimages[3];
                        break;
                    case "5":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        twostarstounlock.enabled = false;
                        levelbordercompletedholder.enabled = false;
                        break;
                }
            }

        }
        else if (countHealth == 1)
        {
            starHolder.sprite = stars[0];
            if (currentStar <= countHealth)
            {
                switch (SelectedLevel)
                {
                    case "1":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        levelbordercompletedholder.sprite = levelborderimages[0];
                        break;
                    case "2":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        levelbordercompletedholder.sprite = levelborderimages[1];
                        break;
                    case "3":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        levelbordercompletedholder.sprite = levelborderimages[2];
                        break;
                    case "4":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        levelbordercompletedholder.sprite = levelborderimages[3];
                        break;
                    case "5":
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        twostarstounlock.enabled = false;
                        levelbordercompletedholder.enabled = false;
                        break;
                }
            }
        }
        SaveManager.Save(SaveFTAGame);
    }

    public Image starPrevious;

    public void checkCurrentStar()
    {
        switch (currentStar)
        {
            case 0:
                tryAnimalBtn.SetActive(false);
                NextLevelBtn.interactable = false;
                starPrevious.sprite = stars[3];
                buttonManagerGameWin();
                break;
            case 1:
                tryAnimalBtn.SetActive(false);
                NextLevelBtn.interactable = false;
                checkGameObjectlvl.SetActive(false);
                checkGameObject.SetActive(false);
                starPrevious.sprite = stars[0];
                buttonManagerGameWin();
                break;
            case 2:
                tryAnimalBtn.SetActive(false);
                NextLevelBtn.interactable = true;
                checkGameObjectlvl.SetActive(true);
                checkGameObject.SetActive(false);
                starPrevious.sprite = stars[1];
                buttonManagerGameWin();
                break;
            case 3:
                tryAnimalBtn.SetActive(true);
                NextLevelBtn.interactable = true;
                checkGameObjectlvl.SetActive(true);
                checkGameObject.SetActive(true);
                starPrevious.sprite = stars[2];
                break;
        }
    }

    void buttonManagerGameWin()
    {
        if (countHealth == 2)
        {
            tryAnimalBtn.SetActive(false);
            NextLevelBtn.interactable = true;
            checkGameObjectlvl.SetActive(true);
            checkGameObject.SetActive(false);
        }
        else if (countHealth == 3)
        {
            tryAnimalBtn.SetActive(true);
            NextLevelBtn.interactable = true;
            checkGameObjectlvl.SetActive(true);
            checkGameObject.SetActive(true);
        }
    }

    public GameObject clickToContinue;
    public void ClickToStart()
    {
        ClickAnytoStart.SetActive(true);
        clickToContinue.SetActive(true);
    }
    public bool isGuideClicked;
    public FTA_HelpButtonGuide guideScript;
    public void ToStartGame()
    {
        if (ClickAnytoStart.activeSelf == true)
        {
            CheckIfFisrtItemGuide = false;
            InstructionGamePanel.SetActive(false);
            startGame = true;
            ResumeGame();
        }
    }

    public GameObject confirmationToARCanvas;
    public TextMeshProUGUI animalToUnlockName;
    public Image animalImg;
    public Sprite[] animalSprites;
    public GameObject checkGameObject;
    public GameObject tryAnimalBtn;

    public GameObject BoyARGuide;
    public GameObject GirlARGuide;

    int AnimalIndex;

    public void TryAnimalARButton()
    {
        if (guide_chosen == "boy_guide")
        {
            BoyARGuide.SetActive(true);
            GirlARGuide.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            GirlARGuide.SetActive(true);
            BoyARGuide.SetActive(false);
        }

        guidePopUpAnimation.showGuidePopUp(confirmARPos, confirmationToARCanvas, panelFinish);
    }

    [SerializeField] private GameObject playAgainCanvas;

    public void levelCompletePlayAgain() 
    {
        guidePopUpAnimation.showGuidePopUp(confirmPlayAgainPos, playAgainCanvas, panelFinish);
    }

    public void playAgainNo() 
    {
        guidePopUpAnimation.hideGuidePopUp(confirmPlayAgainPos, playAgainCanvas, panelFinish);
    }

    public void ConfirmYesTryAnimalARButton()
    {
        audioManager.musicSource.Stop();
        StateNameController.tryAnimalAnimalIndex = AnimalIndex;
        StateNameController.isTryAnimalARClicked = true;
        SceneManager.LoadScene("Animal Selector AR");
    }
    public void ConfirmNoTryAnimalARButton()
    {
        guidePopUpAnimation.hideGuidePopUp(confirmARPos, confirmationToARCanvas, panelFinish);
    }
    
    void AnimaltoUnlock()
    {
        switch (SelectedLevel)
        {
            case "1":
                animalToUnlockName.text = "Leopard";
                animalImg.sprite = animalSprites[0];
                AnimalIndex = 10;
                NoAvailLevel.gameObject.SetActive(false);
                break;
            case "2":
                animalToUnlockName.text = "Pigeon";
                animalImg.sprite = animalSprites[1];
                AnimalIndex = 12;
                NoAvailLevel.gameObject.SetActive(false);
                break;
            case "3":
                animalToUnlockName.text = "Piranha";
                animalImg.sprite = animalSprites[2];
                AnimalIndex = 13;
                NoAvailLevel.gameObject.SetActive(false);
                break;
            case "4":
                animalToUnlockName.text = "Bear";
                animalImg.sprite = animalSprites[3];
                AnimalIndex = 1;
                NoAvailLevel.gameObject.SetActive(false);
                break;
            case "5":
                animalToUnlockName.text = "Owl";
                animalImg.sprite = animalSprites[4];
                AnimalIndex = 17;
                NoAvailLevel.gameObject.SetActive(true);
                twostarstounlock.gameObject.SetActive(false);
                checkGameObjectlvl.gameObject.SetActive(false);
                levelbordercompletedholder.gameObject.SetActive(false);

                break;
        }
    }
    public GameObject Guide;
    public void FTAHelpButton()
    {
        isGuideClicked = true;
        isPaused = true;
        Time.timeScale = 0f;
        Guide.SetActive(true);
        guideScript.CheckPageNumber();
        audioManager.sfxSource.Pause();
    }
    bool isStartTimerCounting = false;
    float countdownTimeStarts = 5.0f;

    void countdownStarts()
    {
        if (isStartTimerCounting)
        {
            countdownTimeStarts -= Time.deltaTime;

            if (countdownTimeStarts <= 1)
            {
                countdownTimeStarts = 5.0f;
                isStartTimerCounting = true;
            }
        }
    }

    public void StartCountdownStarts()
    {
        isStartTimerCounting = true;
        countdownStarts();
    }

    //----------TRIVIA---------//
    public GameObject triviaGameCanvas;
    public Image[] shadowImgContainerTrivia;
    public TMP_Text AnimalNameTrivia;
    public TMP_Text TriviaTextInfo;
    public Image AnimalImageTriva;
    public IEnumerator stopCoundown()
    {
        audioManager.sfxSource.Stop();
        audioManager.musicSource.Stop();
        yield return new WaitForSeconds(0.1f);
        audioManager.PlaySFX(audioManager.TriviaShowEffect);
    }

    public void openTriviaCanvas()
    {
        TriviaGuide();
        clickAnimalShadow(shadowImgContainerTrivia[0].gameObject);
        
        triviaGameCanvas.SetActive(true);
        try
        {
            StartCoroutine(stopCoundown());
        }
        catch
        {

        }
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);

    }
    public void closeTriviaCanvas()
    {
        triviaGameCanvas.SetActive(false);
        GameWin();
    }

    public void clickAnimalShadow(GameObject clickedAnimal)
    {
        foreach (Image shadowImgs in shadowImgContainerTrivia)
        {
            shadowImgs.color = Color.black;
        }

        Image clickedAnimalImg = clickedAnimal.GetComponent<Image>();
        ShowArrowTriviaGuide(clickedAnimal.name);
        Color enableCorrectAnswer = new Color(1.0f, 1.0f, 1.0f);
        clickedAnimalImg.color = enableCorrectAnswer;
        AnimalImageTriva.sprite = clickedAnimalImg.sprite;
        AnimalNameTrivia.text = SelectedArraySprites()[_index].name;
        animalGetAnimalName = AnimalNameTrivia.text;
        generateRandomTrivia();
    }
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    void ShowArrowTriviaGuide(string clickedAnimalImg)
    {
        if (clickedAnimalImg == "shadowleo")
        {
            Arrow1.SetActive(false);
            Arrow2.SetActive(true);
            Arrow3.SetActive(true);
        }
        else if (clickedAnimalImg == "shadowtig")
        {
            Arrow1.SetActive(true);
            Arrow2.SetActive(false);
            Arrow3.SetActive(true);
        }
        else if (clickedAnimalImg == "shadowzeb")
        {
            Arrow1.SetActive(true);
            Arrow2.SetActive(true);
            Arrow3.SetActive(false);
        }
    }

    public GameObject TriviaBoyGuide;
    public GameObject TriviaGirlGuide;
    public void TriviaGuide()
    {
        if (guide_chosen == "boy_guide")
        {
            TriviaBoyGuide.SetActive(true);
            TriviaGirlGuide.SetActive(false);
        }
        else if (guide_chosen == "girl_guide")
        {
            TriviaBoyGuide.SetActive(false);
            TriviaGirlGuide.SetActive(true);
        }
    }

    public int _index;
    public void getIndex(int index)
    {
        _index = index;
    }
    public string animalGetAnimalName;
    int randomNum;
    public void generateRandomTrivia()
    {
        Debug.Log("Animal Trivia!");
        switch (animalGetAnimalName)
        {
            case "Leopard":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Leopards are renowned for their ability to blend into their surroundings due to their spotted coat.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Their spots, called rosettes, provide excellent camouflage in various habitats.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Leopards have one of the most extensive geographical ranges of any big cat.";
                        break;
                }
                break;
            case "Tiger":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Tigers are the largest big cat species in the world.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Tigers are primarily nocturnal hunters. Their night vision is six times better than that of humans.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Tigers are good swimmers and often enjoy bathing in water to cool down in hot weather.";
                        break;
                }
                break;
            case "Zebra":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Zebras are known for their distinctive black and white stripes.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Zebras are social animals that often form herds for protection against predators.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Each zebra's stripe pattern is unique, much like human fingerprints.";
                        break;
                }
                break;
            case "Crab":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Crabs have a hard exoskeleton that protects their body and provides structural support.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Crabs have the ability to regenerate lost limbs if they are damaged or severed.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Crabs are known for their distinctive sideways or crabwise walking.";
                        break;
                }
                break;
            case "Piranha":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Piranhas are well-known for their sharp, interlocking teeth, which they use to rip apart prey.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Piranhas are primarily found in the rivers and tributaries of the Amazon Basin in South America.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Piranhas often hunt in groups, which can make them more effective predators.";
                        break;
                }
                break;
            case "Koi":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Koi fish, particularly the brightly colored varieties, have deep cultural and symbolic significance in Japan.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Koi have a relatively long lifespan compared to many other fish.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Koi come in a wide range of color varieties, including red, orange, yellow, blue, black, and white.";
                        break;
                }
                break;
            case "Duck":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Ducks have a special gland near their tails called the uropygial gland that produces oil.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Ducks have a varied diet and are omnivorous, eating aquatic plants, small fish, insects, and other small organisms.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "There are over 120 different species of ducks, each with unique characteristics and behaviors.";
                        break;
                }
                break;
            case "Owl":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "The structure of owl eyes allows them to see well in low light, making them skilled nocturnal hunters.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Despite their often stoic appearance, owls can exhibit a wide range of facial expressions, from curious to fierce.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "The heart-shaped facial disk of barn owls helps channel sound to their ears, making them exceptional hunters.";
                        break;
                }
                break;
            case "Pigeon":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Pigeons are known for forming strong, monogamous pair bonds. Mated pairs often stay together for life.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Pigeons are known for their distinctive cooing sounds, and their calls can vary among different breeds.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Pigeons have cultural and symbolic significance in various societies, often representing peace and love.";
                        break;
                }
                break;
            case "Camel":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Camels are often called ships of the desert because of their remarkable ability to store water.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Camels can live for up to 40 years, depending on their care and environment.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Camels have cultural importance in many societies, particularly in regions where they are essential for daily life.";
                        break;
                }
                break;
            case "Elephant":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Elephants are known for their remarkable memory.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Adult African elephants can weigh up to 14,000 pounds (6,350 kg).";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Some elephant populations have been observed using tools, such as sticks, to scratch themselves or reach food.";
                        break;
                }
                break;
            case "Seagull":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Seagulls are highly adaptable and can thrive in various environments, from coastal areas to urban settings.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Seagulls often gather in flocks, particularly when searching for food or resting.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Seagulls are known for their distinctive and often loud calls, which can vary among different species.";
                        break;
                }
                break;
            case "Bear":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Bears are known for their ability to hibernate during the winter months.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "In the wild, bears have varied lifespans depending on their species. Some can live up to 20-30 years or more in captivity.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Some bears can recognize themselves in a mirror.";
                        break;
                }
                break;
            case "Rhinoceros":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Rhinoceroses are known for their thick, tough skin, which can be as much as 1.5 inches (3.8 cm) thick.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "This skin helps protect them from thorns, branches, and insect bites.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Rhinoceroses have ancient ancestors and share a distant common lineage with horses and tapirs.";
                        break;
                }
                break;
            case "Bat":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "There are over 1,400 species of bats, making them one of the most diverse mammalian orders.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Bats emit high-pitched sounds and listen for the echoes to determine the location and shape of objects.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Bats are known for their relatively long lifespans, with some species living up to 30 years or more in the wild.";
                        break;
                }
                break;
            case "Crocodile":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Crocodiles are ancient reptiles that have been around for millions of years. ";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Crocodiles can sprint at speeds of up to 10 miles per hour (16 kilometers per hour) on land.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Crocodiles have been on Earth for over 200 million years";
                        break;
                }
                break;
            case "Deer":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "There are over 90 species of deer, including the white-tailed deer, red deer, and reindeer.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Deer are herbivores, primarily feeding on plants, leaves, twigs, and grasses.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Deer have excellent senses, including keen hearing and a strong sense of smell, which help them detect predators.";
                        break;
                }
                break;
            case "Octopus":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Octopuses are considered one of the most intelligent invertebrates.";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Most octopus species have relatively short lifespans, typically living only a few years.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Octopuses have three hearts, one for pumping blood to the body and two for sending it to the gills.";
                        break;
                }
                break;
            case "Shark":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Sharks are ancient creatures that have been around for over 400 million years";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Shark attacks on humans are rare, and most shark species are not interested in humans as prey.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "Sharks can go through thousands of teeth in their lifetime. Their teeth are continuously replaced.";
                        break;
                }
                break;
            case "Horse":
                switch (randomNum)
                {
                    case 0:
                        TriviaTextInfo.text = "Horses are known for their speed, and thoroughbred racehorses can reach speeds of over 40 miles per hour (65 km/h).";
                        break;
                    case 1:
                        TriviaTextInfo.text = "Horses have played a crucial role in human history, from transportation to agriculture and warfare.";
                        break;
                    case 2:
                        TriviaTextInfo.text = "The average lifespan of a horse is around 25-30 years, though some have been known to live well into their 40s.";
                        break;
                }
                break;
        }
    }
}