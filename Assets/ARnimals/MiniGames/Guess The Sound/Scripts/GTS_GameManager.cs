using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GTS_GameManager : MonoBehaviour
{
    SaveObject existingSO;
    public int levelSelected;
    public TMP_Text curr_lvl;
    public int questionNum;
    public TMP_Text questionNumTxt;
    public GameObject gameOver;
    public GameObject confirmationQuit;
    public GameObject GameUI;
    public Animator animator;
    public Animator waitForSoundtxtAnimator;
    public GameObject waitForSoundTxt;

    public GameObject confirmCorrect;
    public GameObject confirmWrong;
    public GameObject confirmGoToARExp;
    public GameObject playAgainConfirm;
    public GameObject restartLevelConfirm;
    public GameObject winLevel;
    public GTS_Trivia GTS_TriviaScript;
    int HintsLeft;
    [Header("Animal")]
    public int animalIndex;
    public Image[] AnimalsContainer;

    [Header("Life")]
    [SerializeField] private int life = 3;
    public Image heart_1;
    public Image heart_2;
    public Image heart_3;
    public Sprite[] healthBarSprites;

    [Header("Sounds")]
    public AudioSource audioSrc;
    public AudioClip[] AnimalSounds;

    [Header("animal sound button")]
    public Button[] soundBtns;


    [Header("play animal sound button")]
    public Button[] playSoundBtns;

    [Header("PopUp Animator")]
    [SerializeField] private Animator quitAnimator;
    [SerializeField] private Animator retryAnimator;
    [SerializeField] private Animator answerCorrectAnimator;
    [SerializeField] private Animator answerWrongAnimator;
    [SerializeField] private Animator exploreAnimator;
    [SerializeField] private Animator playAgainAnimator;
    [SerializeField] private Animator arAnimator;

    [Header("Canvas/UI")]
    public GameObject optionsUI;

    AudioManager audioManager;
    private void Start()
    {
        HintsLeft = 2;
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            if (audioManager.musicSource.isPlaying)
            {
                audioManager.musicSource.Stop();
                audioManager.playBGMMusic(audioManager.GTS_BGM); // play GTS BGM
            }
            else
            {
                audioManager.playBGMMusic(audioManager.GTS_BGM);
            }
            if (audioManager.sfxSource.isPlaying)
            {
                audioManager.sfxSource.Stop();
            }
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

        existingSO = SaveManager.Load();
        levelSelected = StateNameController.levelClickedMG2;
        guide_chosen = StateNameController.guide_chosen;
        confirmCorrect.SetActive(false);
        confirmWrong.SetActive(false);
        optionsUI.SetActive(false);
        GameUI.SetActive(false);
        checkCurrentStar();



        if (levelSelected == 0)
        {
            levelSelected = 1;
        }

        if (string.IsNullOrEmpty(guide_chosen))
        {
            guide_chosen = "boy_guide";
        }

        curr_lvl.text = "Level " + levelSelected.ToString();
        curr_lvl.gameObject.SetActive(true);
        showCurrentLevel();

        questionNum = 1;
        checkQuestion();

        randomizedAnimal();
        checkAnimal();
        randomizeChoiceBtnsAndPlaySndBtns();

    }

    private void Update()
    {
        countdownHints();
        pause_unpauseBGM();
        enableGameOverGOs();
        enableLvlCompleteGOs();
    }

    [SerializeField] private GameObject[] levelCompleteGOs;
    private float enablerTimer = 0.7f;

    private void enableLvlCompleteGOs() 
    {
        if(winLevel.activeSelf) 
        {
            levelCompleteGOs[0].SetActive(true);

            if (enablerTimer > 0f)
            {
                enablerTimer -= Time.unscaledDeltaTime;
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
                    enablerTimer = 0.7f;
                }
            }
        }
    }

    [SerializeField] private GameObject[] gameOverGOs;

    private void enableGameOverGOs() 
    {
        if(gameOver.activeSelf) 
        {
            gameOverGOs[0].SetActive(true);

            if (enablerTimer > 0f)
            {
                enablerTimer -= Time.unscaledDeltaTime;
            }
            else 
            {
                gameOverGOs[1].SetActive(true);
            }
        }
    }

    void pause_unpauseBGM()
    {
        //pauseBGM if speaker is clicked

        if (audioSrc.isPlaying)
        {
            try { audioManager.musicSource.Pause(); } catch { }
        }
        else
        {
            try { audioManager.musicSource.UnPause(); } catch { }
        }
    }
    public TMP_Text hintsTxt;
    public GameObject hintsGO;
    public Animator hintsAnim;

    public GameObject hintGuideBoy;
    public GameObject hintGuideGirl;
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

    }
    public TMP_Text numOfHints;
    void hintTxt()
    {

        if (HintsLeft != 0)
        {
            playSoundCorrectAnswer();
            HintsLeft -= 1;
            if (HintsLeft == 0)
            {
                hintsTxt.text = "No more hints left";
            }
            else
            {
                hintsTxt.text = "<color=#FFFF00>" + HintsLeft + " </color>hint left";
            }
            StartCoroutine(_showHintLeft());
        }
        else if (HintsLeft == 0)
        {
            
            hintsTxt.text = "No more hints left";
            StartCoroutine(_showHintLeft());
            try { audioManager.PlaySFX(audioManager.wrongAnswer); } catch { }

        }
        numOfHints.text = HintsLeft + "/2";
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
    float countdownTimeHints = 3.0f;
    public Button HintsButton;

    void countdownHints()
    {
        if (isHintsTimerCounting)
        {
            countdownTimeHints -= Time.deltaTime;

            if (countdownTimeHints <= 0)
            {
                countdownTimeHints = 3.0f;
                isHintsTimerCounting = false;
                timerHints.gameObject.SetActive(false);
                HintsButton.interactable = true;

            }

            UpdateTimerText();
        }
    }

    public void StartCountdownHints()
    {
        if (!audioSrc.isPlaying && HintsLeft != 0)
        {
            isHintsTimerCounting = true;
            countdownHints();
            timerHints.gameObject.SetActive(true);
            HintsButton.interactable = false;
        }
        else
        {
            hintsTxt.text = "<color=#FFFF00>Wait</color> for the <color=#00FFFF>sound</color> to <color=#00FFFF>finish</color> before using <color=#00FFFF>hint</color>!";
            StartCoroutine(_showHintLeft());
        }

        if (HintsLeft == 0)
        {
            countdownHints();
        }

    }


    private void UpdateTimerText()
    {
        timerHints.text = Convert.ToInt16(countdownTimeHints).ToString();
    }

    public void showCurrentLevel()
    {
        StartCoroutine(WaitForAnimationFinish());

    }
    public GTS_Guide gts_guideScript;
    IEnumerator WaitForAnimationFinish()
    {
        // Wait until the animation is finished
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("currLvl_idle"))
        {
            yield return null;
        }

        Debug.Log("Animation has finished!");
        curr_lvl.gameObject.SetActive(false);
        GameUI.SetActive(true);
        gts_guideScript.Invoke("checkIfGuideIsDone", 1f);
    }
    void checkAnimal()
    {
        for (int i = 0; i < AnimalsContainer.Length; i++)
        {
            if (i == animalIndex)
            {
                AnimalsContainer[i].gameObject.SetActive(true); // Enable the image at matching index
            }
            else
            {
                AnimalsContainer[i].gameObject.SetActive(false); // Disable all other images
            }
        }
    }
    int currentStar;
    public Image previousStarRecord;
    void checkCurrentStar()
    {
        switch (levelSelected)
        {
            case 1:
                currentStar = existingSO.GTS_lvl1_star;
                ARanimalIndex = 14;
                break;
            case 2:
                currentStar = existingSO.GTS_lvl2_star;
                ARanimalIndex = 2;

                break;
            case 3:
                currentStar = existingSO.GTS_lvl3_star;
                ARanimalIndex = 0;

                break;
            case 4:
                currentStar = existingSO.GTS_lvl4_star;
                ARanimalIndex = 9;

                break;
            case 5:
                currentStar = existingSO.GTS_lvl5_star;
                ARanimalIndex = 3;
                break;
        }
    }

    public Sprite[] animalImgToUnlockSprite;
    public Image animalImg;
    public GameObject checkImg;
    public TMP_Text animalName;
    void showAnimalReward()
    {
        switch (levelSelected)
        {
            case 1:
                animalImg.sprite = animalImgToUnlockSprite[0];
                animalName.text = "Rhinoceros";
                if (existingSO.isRhinoUnlock)
                {
                    checkImg.SetActive(true);
                }
                else
                {
                    checkImg.SetActive(false);
                }
                break;
            case 2:
                animalImg.sprite = animalImgToUnlockSprite[1];
                animalName.text = "Camel";
                if (existingSO.isCamelUnlock)
                {
                    checkImg.SetActive(true);
                }
                else
                {
                    checkImg.SetActive(false);
                }
                break;
            case 3:
                animalImg.sprite = animalImgToUnlockSprite[2];
                animalName.text = "Bat";
                if (existingSO.isBatUnlock)
                {
                    checkImg.SetActive(true);
                }
                else
                {
                    checkImg.SetActive(false);
                }
                break;
            case 4:
                animalImg.sprite = animalImgToUnlockSprite[3];
                animalName.text = "Koi";
                if (existingSO.isKoiUnlock)
                {
                    checkImg.SetActive(true);
                }
                else
                {
                    checkImg.SetActive(false);
                }
                break;
            case 5:
                animalImg.sprite = animalImgToUnlockSprite[4];
                animalName.text = "Crab";
                if (existingSO.isCrabUnlock)
                {
                    checkImg.SetActive(true);
                }
                else
                {
                    checkImg.SetActive(false);
                }
                break;
        }
    }

    public Sprite[] starsSprites;
    public Image _starWin;
    public TMP_Text lvlCompleted;
    public GameObject tryARBtn;

    void checkStar()
    {
        try
        {
            audioManager.PlaySFX(audioManager.winLevel);
            audioManager.musicSource.Stop();
        } catch { }


        if (life == 3)
        {
            _starWin.sprite = starsSprites[3];
            unlockAnimal();
            showAnimalReward();
            if (currentStar <= life)
            {
                switch (levelSelected)
                {
                    case 1:
                        existingSO.GTS_lvl1_star = 3;
                        break;
                    case 2:
                        existingSO.GTS_lvl2_star = 3;
                        break;
                    case 3:
                        existingSO.GTS_lvl3_star = 3;
                        break;
                    case 4:
                        existingSO.GTS_lvl4_star = 3;
                        break;
                    case 5:
                        existingSO.GTS_lvl5_star = 3;
                        break;
                }


            }
        }
        else if (life == 2)
        {
            _starWin.sprite = starsSprites[2];
            showAnimalReward();
            if (currentStar < life)
            {
                switch (levelSelected)
                {
                    case 1:
                        existingSO.GTS_lvl1_star = 2;
                        break;
                    case 2:
                        existingSO.GTS_lvl2_star = 2;
                        break;
                    case 3:
                        existingSO.GTS_lvl3_star = 2;
                        break;
                    case 4:
                        existingSO.GTS_lvl4_star = 2;
                        break;
                    case 5:
                        existingSO.GTS_lvl5_star = 2;
                        break;
                }
            }

        }
        else if (life == 1)
        {
            _starWin.sprite = starsSprites[1];
            showAnimalReward();
            if (currentStar <= life)
            {
                switch (levelSelected)
                {
                    case 1:
                        existingSO.GTS_lvl1_star = 1;
                        break;
                    case 2:
                        existingSO.GTS_lvl2_star = 1;
                        break;
                    case 3:
                        existingSO.GTS_lvl3_star = 1;
                        break;
                    case 4:
                        existingSO.GTS_lvl4_star = 1;
                        break;
                    case 5:
                        existingSO.GTS_lvl5_star = 1;
                        break;
                }
            }
        }
        SaveManager.Save(existingSO);
    }
    void winLevelLogic()
    {
        switch (currentStar)
        {
            case 0:
                previousStarRecord.sprite = starsSprites[0];
                tryARBtn.SetActive(false);
                checkImg.SetActive(false);

                nextLvlBtn.interactable = false;
                checkImgUnlockedLevelBoard.SetActive(false);
                if (life == 2)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                }
                else if (life == 3)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                    tryARBtn.SetActive(true);
                    checkImg.SetActive(true);
                }
                break;
            case 1:

                previousStarRecord.sprite = starsSprites[1];
                tryARBtn.SetActive(false);
                checkImg.SetActive(false);

                nextLvlBtn.interactable = false;
                checkImgUnlockedLevelBoard.SetActive(false);

                if (life == 2)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                }
                else if (life == 3)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                    tryARBtn.SetActive(true);
                    checkImg.SetActive(true);
                }

                break;
            case 2:
                previousStarRecord.sprite = starsSprites[2];
                tryARBtn.SetActive(false);
                checkImg.SetActive(false);

                nextLvlBtn.interactable = true;
                checkImgUnlockedLevelBoard.SetActive(true);

                if (life == 2)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                }
                else if (life == 3)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                    tryARBtn.SetActive(true);
                    checkImg.SetActive(true);
                }
                break;
            case 3:
                previousStarRecord.sprite = starsSprites[3];
                if (life == 3)
                {
                    nextLvlBtn.interactable = true;
                    checkImgUnlockedLevelBoard.SetActive(true);
                    tryARBtn.SetActive(true);
                    checkImg.SetActive(true);
                }
                break;
        }



    }

    void checkQuestion()
    {
        if (levelSelected == 1)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 3";
            if (questionNum == 4)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                checkStar();
                unlockLevelBoard();
                winLevelLogic();
                showNextLvlBtn();
            }
        }
        else if (levelSelected == 2)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 4";
            if (questionNum == 5)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
                unlockLevelBoard();
                winLevelLogic();
                showNextLvlBtn();
            }
        }
        else if (levelSelected == 3)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 4";
            if (questionNum == 5)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
                unlockLevelBoard();
                winLevelLogic();
                showNextLvlBtn();
            }
        }
        else if (levelSelected == 4)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 5";
            if (questionNum == 6)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
                unlockLevelBoard();
                winLevelLogic();
                showNextLvlBtn();
            }
        }
        else if (levelSelected == 5)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 5";
            if (questionNum == 6)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
                unlockLevelBoard();
                winLevelLogic();
                showNextLvlBtn();
            }
        }


    }
    public GameObject mainNextLevelUnlockGO;
    public Image levelToUnlockImg;
    public Sprite[] levelsSprite;
    public GameObject levelUnlockGO;
    public TMP_Text allLevelsUnlockedTxt;
    public GameObject checkImgUnlockedLevelBoard;


    void unlockLevelBoard()
    {
        switch (levelSelected)
        {
            case 1:
                levelToUnlockImg.sprite = levelsSprite[0];
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                break;
            case 2:
                levelToUnlockImg.sprite = levelsSprite[1];
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                break;
            case 3:
                levelToUnlockImg.sprite = levelsSprite[2];
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                break;
            case 4:
                levelToUnlockImg.sprite = levelsSprite[3];
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                break;
            case 5:
                levelUnlockGO.SetActive(false);
                allLevelsUnlockedTxt.gameObject.SetActive(true);
                nextLvlBtn.interactable = false;
                switch (currentStar)
                {
                    case 3:
                        tryARBtn.SetActive(true);
                        checkImg.SetActive(true);
                        break;
                }
                break;
        }

        winLevel.SetActive(true);
        lvlCompleted.text = "LEVEL <color=yellow><b>" + levelSelected.ToString() + "</b></color> COMPLETED!";

    }
    void unlockAnimal()
    {
        switch (levelSelected)
        {
            case 1:
                existingSO.isRhinoUnlock = true;
                break;
            case 2:
                existingSO.isCamelUnlock = true;
                break;
            case 3:
                existingSO.isBatUnlock = true;
                break;
            case 4:
                existingSO.isKoiUnlock = true;
                break;
            case 5:
                existingSO.isCrabUnlock = true;
                break;

        }
    }
    public Button nextLvlBtn;
    void showNextLvlBtn()
    {
        if (levelSelected == 5)
        {
            nextLvlBtn.gameObject.SetActive(false);
        }
    }
    public void nextLevel()
    {
            StateNameController.levelClickedMG2 += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void compareCurrentLvl_UnlockLvl()
    {
        if (levelSelected < existingSO.getUnlockedLevelMG2())
        {

        }
        else if (existingSO.getUnlockedLevelMG2() == 5)
        {
        }
        else if (levelSelected >= existingSO.getUnlockedLevelMG2() && life >= 2)
        {
            existingSO.setUnlockedLevelMG2(1);
            SaveManager.Save(existingSO);
        }
    }
    public void randomizeChoiceBtnsAndPlaySndBtns()
    {
        // Randomize the sound of choices
        var soundArray = GetUniqueRandomElements(list, soundBtns.Length);

        // Assign button listener to all of the buttons
        for (int i = 0; i < soundBtns.Length; i++)
        {
            int index = i;
            soundBtns[i].onClick.AddListener(showConfirmWrong);
            playSoundBtns[i].onClick.AddListener(() => playSoundWrongAnswer(soundArray[index]));
        }

        // Check if the correct answer is in the choices
        if (!soundArray.Contains(animalIndex))
        {
            int randomNum = UnityEngine.Random.Range(0, soundBtns.Length);
            // Remove listeners from the randomly selected button
            soundBtns[randomNum].onClick.RemoveAllListeners();
            playSoundBtns[randomNum].onClick.RemoveAllListeners();

            // Add the correct choice to the button
            soundBtns[randomNum].onClick.AddListener(showConfirmCorrect);
            playSoundBtns[randomNum].onClick.AddListener(playSoundCorrectAnswer);
        }
        else
        {
            int matchingIndex = soundArray.IndexOf(animalIndex);

            //remove listeners
            soundBtns[matchingIndex].onClick.RemoveAllListeners();
            playSoundBtns[matchingIndex].onClick.RemoveAllListeners();
        
            // Add the correct choice to the button with matching index
            soundBtns[matchingIndex].onClick.AddListener(showConfirmCorrect);
            playSoundBtns[matchingIndex].onClick.AddListener(playSoundCorrectAnswer);
        }
    }


    List<int> list = new List<int> { 0, 1, 2, 3, 4 };

    List<T> GetUniqueRandomElements<T>(List<T> inputList, int count)
    {
        List<T> inputListClone = new List<T>(inputList);
        Shuffle(inputListClone);
        return inputListClone.GetRange(0, count);
    }

    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = UnityEngine.Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;

        }
    }

    public void playSoundCorrectAnswer()
    {
        if (!audioSrc.isPlaying)
        {
            if (!waitSndPlaying)
            {
                audioSrc.PlayOneShot(AnimalSounds[animalIndex]);
            }
        }
        else
        {
            StartCoroutine(waitForSountTxtDelay());
        }

    }

    public void playSoundWrongAnswer(int soundIndex)
    {
        if (!audioSrc.isPlaying)
        {
            if (!waitSndPlaying)
            {
                audioSrc.PlayOneShot(AnimalSounds[soundIndex]);
            }
        }
        else
        {
            if (!waitSndPlaying)
            {
                StartCoroutine(waitForSountTxtDelay());
            }
        }
    }
    bool waitSndPlaying;
    public GameObject boy_guide_waitForSnd;
    public GameObject girl_guide_waitForSnd;
    string guide_chosen;

    public Animator waitForSndBoy;
    public Animator waitForSndGirl;
    public Animator waitForSndTxt;
    IEnumerator waitForSountTxtDelay()
    {

            if (guide_chosen == "boy_guide")
            {
                waitForSoundTxt.SetActive(true);
                boy_guide_waitForSnd.SetActive(true);
                waitSndPlaying = true;
                yield return (new WaitForSeconds(0.5f));
                waitForSndBoy.SetTrigger("closeGuideBoy");
                waitForSndTxt.SetTrigger("closeGuideTxt");
                while (!waitForSndBoy.GetCurrentAnimatorStateInfo(0).IsName("fadeInAndOut_waitForSoundFinish") && !waitForSndTxt.GetCurrentAnimatorStateInfo(0).IsName("fadeInAndOut_waitForSoundFinish"))
                {
                    yield return null;
                }
                waitForSoundTxt.SetActive(false);
                boy_guide_waitForSnd.SetActive(false);
                waitSndPlaying = false;
            }
            else if (guide_chosen == "girl_guide")
            {
                waitForSoundTxt.SetActive(true);
                girl_guide_waitForSnd.SetActive(true);
                waitSndPlaying = true;
                yield return (new WaitForSeconds(0.5f));
                waitForSndGirl.SetTrigger("closeGuideGirl");
                waitForSndTxt.SetTrigger("closeGuideTxt");
                while (!waitForSndBoy.GetCurrentAnimatorStateInfo(0).IsName("fade_Out_waitForSNDFemale") && !waitForSndTxt.GetCurrentAnimatorStateInfo(0).IsName("fadeInAndOut_waitForSoundFinish"))
                    {
                        yield return null;
                    }
                waitForSoundTxt.SetActive(false);
                girl_guide_waitForSnd.SetActive(false);
                waitSndPlaying = false;
            }


    }

    public GameObject factsGuideGO;
    public Animator factsGuideAnim;


    IEnumerator _showFacts()
    {
        HintsButton.interactable = false;
        GTS_TriviaScript.generateTrivia();
        factsGuideGO.SetActive(true);
        yield return new WaitForSeconds(2f);
        factsGuideAnim.SetTrigger("TriviaOut");
        yield return new WaitForSeconds(1f);
        factsGuideGO.SetActive(false);
        HintsButton.interactable = true;
    }
    public void correctAnswer()
    {

        confirmCorrect.SetActive(false);

        StopAllCoroutines();
        hideConfirmCorrect();
        try
        {
            audioManager.PlaySFX(audioManager.correctAnswer);
        }
        catch
        {

        }
        stopSound();
        audioSrc.PlayOneShot(AnimalSounds[animalIndex]);
        StartCoroutine(_showFacts());

        questionNum += 1;
        Invoke("checkQuestion",2.8f);
        Invoke("randomizedAnimal", 2.8f);
        Invoke("checkAnimal", 2.8f);


        for (int i = 0; i < playSoundBtns.Length; i++)
        {
            playSoundBtns[i].onClick.RemoveAllListeners();
            soundBtns[i].onClick.RemoveAllListeners();
        }

        Invoke("randomizeChoiceBtnsAndPlaySndBtns", 2.8f);

    }

    public Animator dmgEffect;
    public GameObject damagePanel;
    public void wrongAnswer()
    {
        confirmWrong.SetActive(false);
        StartCoroutine(dmgPlayer());
        hideConfirmWrong();
        life -=1;
        lifeChecker();

        try { audioManager.PlaySFX(audioManager.wrongAnswer); }
        catch { }
       

    }
    
    IEnumerator dmgPlayer()
    {
        damagePanel.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        damagePanel.SetActive(false);
    }
    public void lifeChecker()
    {
        if (life == 3)
        {
            heart_3.sprite = healthBarSprites[0];
            heart_2.sprite = healthBarSprites[0];
            heart_1.sprite = healthBarSprites[0];

        }
        else if (life == 2)
        {
            heart_3.sprite = healthBarSprites[1];
        }
        else if(life == 1)
        {
            heart_2.sprite = healthBarSprites[1];
        }
        else if (life == 0)
        {
            heart_1.sprite = healthBarSprites[1];
            gameOverUI();
        }
    }
    public GameObject boy_guide_gameOver;
    public GameObject girl_guide_gameOver;
    void gameOverUI()
    {
        confirmCorrect.SetActive(false);
        confirmWrong.SetActive(false);
        gameOver.SetActive(true);
        audioManager.PlaySFX(audioManager.loseLevel);
        audioManager.musicSource.Stop();

        if (guide_chosen == "boy_guide")
        {
            boy_guide_gameOver.SetActive(true);
            girl_guide_gameOver.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_gameOver.SetActive(false);
            girl_guide_gameOver.SetActive(true);
        }
    }

    public GameObject exploreConfirm;
    public GameObject boy_guide_explore;
    public GameObject girl_guide_explore;
    public void showConfirmExplore()
    {
        gameOver.SetActive(false);
        exploreConfirm.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_explore.SetActive(true);
            girl_guide_explore.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_explore.SetActive(false);
            girl_guide_explore.SetActive(true);
        }

    }
    
    public void goToAnimalInfo()
    {
        audioManager.musicSource.Stop();
        StateNameController.failedAnimal = animalIndex;
        StateNameController.isGTSExploreClicked = true;
        SceneManager.LoadScene("Animal_Information");
    }

    private List<int> usedAnimalIndices = new List<int>();

    public void randomizedAnimal()
    {
        // Generate a random animal index that has not been used before
        int totalAnimals = AnimalsContainer.Length;

        if (usedAnimalIndices.Count >= totalAnimals)
        {
            // All animals have been used, reset the usedAnimalIndices list
            usedAnimalIndices.Clear();
        }

        int randomIndex;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, totalAnimals);
        } while (usedAnimalIndices.Contains(randomIndex));

        // Add the randomIndex to the usedAnimalIndices list
        usedAnimalIndices.Add(randomIndex);

        animalIndex = randomIndex;
    }

    public void hideConfirmExplore()
    {
        StartCoroutine(disablePopUp(exploreAnimator, exploreConfirm, gameOver));
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitLevel()
    {
        try { audioManager.musicSource.Stop(); }
        catch { }
        
        SceneManager.LoadScene("GTAFS_lvlSelect");
    }

    public GameObject boy_guide_goToAR;
    public GameObject girl_guide_goToAR;
    public void showConfirmGoToAR()
    {
        winLevel.SetActive(false);
        confirmGoToARExp.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_goToAR.SetActive(true);
            girl_guide_goToAR.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_goToAR.SetActive(false);
            girl_guide_goToAR.SetActive(true);
        }
    }

    public void hideConfirmGoToAR()
    {
        StartCoroutine(disablePopUp(arAnimator, confirmGoToARExp, winLevel));
    }
    
    int ARanimalIndex;
    public void goToAR()
    {
        audioManager.musicSource.Stop();
        StateNameController.tryAnimalAnimalIndex = ARanimalIndex;
        StateNameController.isTryAnimalARClicked = true;
        SceneManager.LoadScene("Animal Selector AR");
    }

    public void showOptions()
    {
        optionsUI.SetActive(true);
    }
    public void hideOptions()
    {
        optionsUI.SetActive(false);
    }

    public GameObject boy_guide_correct;
    public GameObject girl_guide_correct;
    public void showConfirmCorrect()
    {
        confirmCorrect.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_correct.SetActive(true);
            girl_guide_correct.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_correct.SetActive(false);
            girl_guide_correct.SetActive(true);
        }
    }

    public void hideConfirmCorrect()
    {
        StartCoroutine(disablePopUp(answerCorrectAnimator, confirmCorrect));
    }
    public GameObject boy_guide_playAgain;
    public GameObject girl_guide_playAgain;
    public void showPlayAgainConfirm()
    {
        winLevel.SetActive(false);
        playAgainConfirm.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_playAgain.SetActive(true);
            girl_guide_playAgain.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_playAgain.SetActive(false);
            girl_guide_playAgain.SetActive(true);
        }
    }
    public void hidePlayAgainConfirm()
    {
        StartCoroutine(disablePopUp(playAgainAnimator, playAgainConfirm, winLevel));
    }
    public GameObject boy_guide_retry;
    public GameObject girl_guide_retry;


    public void showRetryAgainConfirm()
    {
        optionsUI.SetActive(false);
        restartLevelConfirm.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_retry.SetActive(true);
            girl_guide_retry.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_retry.SetActive(false);
            girl_guide_retry.SetActive(true);
        }
        
    }

    public void hideRetryAgainConfirm()
    {
        StartCoroutine(disablePopUp(retryAnimator, restartLevelConfirm, optionsUI));
    }
    public GameObject boy_guide_wrong;
    public GameObject girl_guide_wrong;
    public void showConfirmWrong()
    {
        confirmWrong.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_wrong.SetActive(true);
            girl_guide_wrong.SetActive(false);

        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_wrong.SetActive(false);
            girl_guide_wrong.SetActive(true);
        }
    }
    public void hideConfirmWrong()
    {
        StartCoroutine(disablePopUp(answerWrongAnimator, confirmWrong));
    }
    public GameObject boy_guide_quit;
    public GameObject girl_guide_quit;
    private string confirmQuitCode;
    public void showConfirmQuit(string code)
    {
        confirmQuitCode = code;
        optionsUI.SetActive(false);
        gameOver.SetActive(false);
        confirmationQuit.SetActive(true);
        if (guide_chosen == "boy_guide")
        {
            boy_guide_quit.SetActive(true);
            girl_guide_quit.SetActive(false);
            
        }
        else if (guide_chosen == "girl_guide")
        {
            boy_guide_quit.SetActive(false);
            girl_guide_quit.SetActive(true);
        }
    }
    public void hideConfirmQuit()
    {
        StartCoroutine(disablePopUp());
    }
    public void stopSound()
    {
        audioSrc.Stop();
    }

    private IEnumerator disablePopUp(Animator animator, GameObject disable, GameObject enable) 
    {
        animator.SetTrigger("XButton");
        yield return new WaitForSecondsRealtime(.5f);
        disable.SetActive(false);
        enable.SetActive(true);
    }

    private IEnumerator disablePopUp(Animator animator, GameObject disable) 
    {
        animator.SetTrigger("XButton");
        yield return new WaitForSecondsRealtime(.5f);
        disable.SetActive(false);
    }
    private IEnumerator disablePopUp() 
    {
        quitAnimator.SetTrigger("XButton");
        yield return new WaitForSecondsRealtime(.5f);
        confirmationQuit.SetActive(false);
        switch(confirmQuitCode) 
        {
            case "OptionsUI":
                optionsUI.SetActive(true);
                break;
            case "GameOver":
                gameOver.SetActive(true);
                break;
        }  
    }
}
