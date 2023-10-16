using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using System;

public class FTA_GameManager : MonoBehaviour
{
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

    SaveObject SaveFTAGame;

    AudioManager audioManager;

    bool guideTutorialisDone;

    private Vector3[] positions;

    private void Start()
    {
        SaveFTAGame = SaveManager.Load();
        guideTutorialisDone = SaveFTAGame.FTA_GAME_GUIDE;
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            if (audioManager.musicSource.isPlaying)
            {

            }
            else
            {
                audioManager.playBGMMusic(audioManager.FTA_BGM);
            }
        }
        catch
        {
            Debug.Log("No AudioManager");
        }
        
        guide_chosen = SaveFTAGame.guideChosen;
        HintsLeft = 1;
        SelectedLevel = PlayerPrefs.GetString("FTA_SelectedLevel");
        SelectedArraySprites();
        CheckLevel();
        initializePositionsofItems();
        RandomlyAssignSprites();
        RandomlyAssignPositionToItems();
        countHealth = health.transform.childCount;
        settingsMenuObject.SetActive(false);
        InstructionGamePanel.SetActive(true);
        Invoke("StartCountdownStarts", 0.8f);
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
            }
        }
        countdownHints();
        if (InstructionGamePanel.activeSelf == true)
        {
            Invoke("ClickToStart", 3f);
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
            Debug.Log("Correct");
            shadowImgs[0].color = enableCorrectAnswer;
            clickedAnimal.SetActive(false);
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
            shadowImgs[1].color = enableCorrectAnswer;
            clickedAnimal.SetActive(false);
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
            shadowImgs[2].color = enableCorrectAnswer;
            clickedAnimal.SetActive(false);
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
    private void checkIfAllFound()
    {
        Color enableCorrectAnswer = new Color(1.0f, 1.0f, 1.0f);
        if (shadowImgs[0].color == enableCorrectAnswer && shadowImgs[1].color == enableCorrectAnswer && shadowImgs[2].color == enableCorrectAnswer)
        {
            checkStar();
            GameWin();
            PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel, 1);
        }
    }

    [Header("Panel/Settings")]
    public GameObject panelGameOver;
    public GameObject panelFinish;
    private bool isGameOver = false;
    private bool isPaused = false;
    public GameObject settingsMenuObject;
    public GameObject wrongAnswerPanel;
    public void GameOver()
    {
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);
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
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);
        panelFinish.SetActive(true);
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        settingsMenuObject.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingsMenuObject.SetActive(false);
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
        RestartGuideConfirm.SetActive(true);
        settingsMenuObject.SetActive(false);
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
        }
        catch
        {

        }
    }
    public void CloseConfirmationQuit()
    {
        QuitGuideConfirm.SetActive(false);
        settingsMenuObject.SetActive(true);
    }

    public GameObject RestartGuideConfirm;
    public GameObject guide_boy_restart;
    public GameObject guide_girl_restart;
    public void ConfirmRestart()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_Game");
    }
    public void CloseConfirmRestart()
    {
        RestartGuideConfirm.SetActive(false);
        settingsMenuObject.SetActive(true);
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

        QuitGuideConfirm.SetActive(true);
    }

    public void confirmQuitNoButtonFunction()
    {
        switch (confirmQuitCode)
        {
            case "OptionsUI":
                settingsMenuObject.SetActive(true);
                break;
            case "GameOverUI":
                panelGameOver.SetActive(true);
                break;
        }
        QuitGuideConfirm.SetActive(false);
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
        ExploreGuidePanel.SetActive(true);
        panelGameOver.SetActive(false);
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
        panelGameOver.SetActive(true);
        ExploreGuidePanel.SetActive(false);
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

    private void DisplayTimer()
    {
        float remainingTime = Mathf.Max(0f, timeLimit - timer);
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

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
    int currentStar;
    void checkStar()
    {
        if (countHealth == 3)
        {
            if (currentStar < countHealth)
            {
                switch (SelectedLevel)
                {
                    case "1":
                        starHolder.sprite = stars[2];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isLeopardUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "2":
                        starHolder.sprite = stars[2];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isPigeonUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "3":
                        starHolder.sprite = stars[2];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isPiranhaUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "4":
                        starHolder.sprite = stars[2];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isBearUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "5":
                        starHolder.sprite = stars[2];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 3);
                        SaveFTAGame.isOwlUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                }
            }
        }
        else if (countHealth == 2)
        {
            if (currentStar < countHealth)
            {
                switch (SelectedLevel)
                {
                    case "1":
                        starHolder.sprite = stars[1];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        SaveFTAGame.isLeopardUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "2":
                        starHolder.sprite = stars[1];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        SaveFTAGame.isPigeonUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "3":
                        starHolder.sprite = stars[1];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        SaveFTAGame.isPiranhaUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "4":
                        starHolder.sprite = stars[1];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        SaveFTAGame.isBearUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                    case "5":
                        starHolder.sprite = stars[1];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 2);
                        SaveFTAGame.isOwlUnlock = true;
                        checkGameObject.SetActive(true);
                        break;
                }
            }

        }
        else if (countHealth == 1)
        {
            
            if (currentStar <= countHealth)
            {
                switch (SelectedLevel)
                {
                    case "1":
                        starHolder.sprite = stars[0];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        tryAnimalBtn.SetActive(false);
                        break;
                    case "2":
                        starHolder.sprite = stars[0];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        tryAnimalBtn.SetActive(false);
                        break;
                    case "3":
                        starHolder.sprite = stars[0];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        tryAnimalBtn.SetActive(false);
                        break;
                    case "4":
                        starHolder.sprite = stars[0];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        tryAnimalBtn.SetActive(false);
                        break;
                    case "5":
                        starHolder.sprite = stars[0];
                        PlayerPrefs.SetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 1);
                        tryAnimalBtn.SetActive(false);
                        break;
                }
            }
        }
        SaveManager.Save(SaveFTAGame);
    }
    public void ClickToStart()
    {
        ClickAnytoStart.SetActive(true);
    }
    public bool isGuideClicked;
    public FTA_HelpButtonGuide guideScript;
    public void ToStartGame()
    {
        if (!guideTutorialisDone)
        {
            InstructionGamePanel.SetActive(false);
            startGame = true;
            FTAHelpButton();
        }
        else
        {
            if (startGame == false && ClickAnytoStart.activeSelf == true)
            {
                InstructionGamePanel.SetActive(false);
                startGame = true;
            }
        }   
    }

    public GameObject confirmationToARCanvas;
    public TextMeshProUGUI animalToUnlockName;
    public Image animalImg;
    public Sprite[] animalSprites;
    public GameObject checkGameObject;
    public GameObject tryAnimalBtn;

    public void TryAnimalARButton()
    {
        confirmationToARCanvas.SetActive(true);
    }
    public void ConfirmYesTryAnimalARButton()
    {
        SceneManager.LoadScene("Animal Selector AR");
    }
    public void ConfirmNoTryAnimalARButton()
    {
        confirmationToARCanvas.SetActive(false);
    }
    void AnimaltoUnlock()
    {
        switch (SelectedLevel)
        {
            case "1":
                animalToUnlockName.text = "Leopard";
                animalImg.sprite = animalSprites[0];
                break;
            case "2":
                animalToUnlockName.text = "Pigeon";
                animalImg.sprite = animalSprites[1];
                break;
            case "3":
                animalToUnlockName.text = "Piranha";
                animalImg.sprite = animalSprites[2];
                break;
            case "4":
                animalToUnlockName.text = "Bear";
                animalImg.sprite = animalSprites[3];
                break;
            case "5":
                animalToUnlockName.text = "Owl";
                animalImg.sprite = animalSprites[4];
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
    }
    public TMP_Text timerStart;
    bool isStartTimerCounting = false;
    float countdownTimeStarts = 3.0f;

    void countdownStarts()
    {
        if (isStartTimerCounting)
        {
            countdownTimeStarts -= Time.deltaTime;

            if (countdownTimeStarts <= 1)
            {
                countdownTimeStarts = 3.0f;
                isStartTimerCounting = true;
                timerStart.gameObject.SetActive(false);
            }
            UpdateStartText();
        }
    }

    public void StartCountdownStarts()
    {
        isStartTimerCounting = true;
        countdownStarts();
        timerStart.gameObject.SetActive(true);

    }
    private void UpdateStartText()
    {
        timerStart.text = Convert.ToInt16(countdownTimeStarts).ToString();
    }
}