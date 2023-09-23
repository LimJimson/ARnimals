using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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

    public GameObject playAgainConfirm;
    public GameObject restartLevelConfirm;
    public GameObject winLevel;

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


    [Header("Canvas/UI")]
    public GameObject optionsUI;

    private void Start()
    {
        existingSO = SaveManager.Load();
        levelSelected = StateNameController.levelClickedMG2;
        guide_chosen = StateNameController.guide_chosen;
        confirmCorrect.SetActive(false);
        confirmWrong.SetActive(false);
        optionsUI.SetActive(false);
        GameUI.SetActive(false);

        if ( levelSelected == 0)
        {
            levelSelected = 1;
        }

        if (string.IsNullOrEmpty(guide_chosen))
        {
            guide_chosen = "boy_guide";
        }

        curr_lvl.text = "Level "+ levelSelected.ToString();
        curr_lvl.gameObject.SetActive(true);
        showCurrentLevel();

        questionNum = 1;
        checkQuestion();

        randomizedAnimal();
        checkAnimal();
        randomizeChoiceBtnsAndPlaySndBtns();

    }

    public void showCurrentLevel()
    {
        StartCoroutine(WaitForAnimationFinish());

    }
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

    public Sprite[] starsSprites;
    public Image _starWin;
    public TMP_Text lvlCompleted;
    void checkStar()
    {
        
        winLevel.SetActive(true);
        lvlCompleted.text = "LEVEL <color=yellow><b>" + levelSelected.ToString()+ "</b></color> COMPLETED!";
        if(life == 3)
        {
            _starWin.sprite = starsSprites[3];
        }
        else if(life == 2)
        {
            _starWin.sprite = starsSprites[2];
        }
        else if(life == 1)
        {
            _starWin.sprite = starsSprites[1];
        }
    }
    void checkQuestion()
    {
        if(levelSelected == 1)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 3";
            if (questionNum == 4)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
            }
        }
        else if(levelSelected == 2)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 5";
            if (questionNum == 6)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
            }
        }
        else if (levelSelected == 3)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 8";
            if (questionNum == 9)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
            }
        }
        else if (levelSelected == 4)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 10";
            if (questionNum == 11)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
            }
        }
        else if (levelSelected == 5)
        {
            questionNumTxt.text = "Question # " + questionNum.ToString() + " / 12";
            if (questionNum == 13)
            {
                GameUI.SetActive(false);
                compareCurrentLvl_UnlockLvl();
                showNextLvlBtn();
                checkStar();
            }
        }
    }
    public GameObject nextLvlBtn;
    void showNextLvlBtn()
    {
        if (levelSelected <= 5)
        {
            nextLvlBtn.SetActive(true);
        }
        else
        {
            nextLvlBtn.SetActive(false);
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
        else if (levelSelected >= existingSO.getUnlockedLevelMG2())
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
            int randomNum = Random.Range(0, soundBtns.Length);
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
            int rand = Random.Range(i, inputList.Count);
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
    IEnumerator waitForSountTxtDelay()
    {

            if (guide_chosen == "boy_guide")
            {
                waitForSoundTxt.SetActive(true);
                boy_guide_waitForSnd.SetActive(true);
                waitSndPlaying = true;
                yield return (new WaitForSeconds(1f));
                waitForSoundTxt.SetActive(false);
                boy_guide_waitForSnd.SetActive(false);
                waitSndPlaying = false;
            }
            else if (guide_chosen == "girl_guide")
            {
                waitForSoundTxt.SetActive(true);
                girl_guide_waitForSnd.SetActive(true);
                waitSndPlaying = true;
                yield return (new WaitForSeconds(1f));
                waitForSoundTxt.SetActive(false);
                girl_guide_waitForSnd.SetActive(false);
                waitSndPlaying = false;
            }

    }


    public void correctAnswer()
    {
        hideConfirmCorrect();
        stopSound();
        
        
        questionNum += 1;
        checkQuestion();
        
        
        randomizedAnimal();
        checkAnimal();


        for (int i = 0; i < playSoundBtns.Length; i++)
        {
            playSoundBtns[i].onClick.RemoveAllListeners();
            soundBtns[i].onClick.RemoveAllListeners();
        }

        randomizeChoiceBtnsAndPlaySndBtns();

    }

    public void wrongAnswer()
    {
        hideConfirmWrong();
        life-=1;
        lifeChecker();
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
        gameOver.SetActive(true);
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
            randomIndex = Random.Range(0, totalAnimals);
        } while (usedAnimalIndices.Contains(randomIndex));

        // Add the randomIndex to the usedAnimalIndices list
        usedAnimalIndices.Add(randomIndex);

        animalIndex = randomIndex;
    }
    public void goToAnimalInfo()
    {
        SceneManager.LoadScene("Animal_Information");
    }

    public GameObject exploreConfirm;
    public GameObject boy_guide_explore;
    public GameObject girl_guide_explore;
    public void showConfirmExplore()
    {
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
    public void hideConfirmExplore()
    {
        exploreConfirm.SetActive(false);
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitLevel()
    {
        SceneManager.LoadScene("GTAFS_lvlSelect");
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
        confirmCorrect.SetActive(false);
    }
    public GameObject boy_guide_playAgain;
    public GameObject girl_guide_playAgain;
    public void showPlayAgainConfirm()
    {
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
        playAgainConfirm.SetActive(false);
    }

    public GameObject boy_guide_retry;
    public GameObject girl_guide_retry;


    public void showRetryAgainConfirm()
    {
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
        restartLevelConfirm.SetActive(false);
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
        confirmWrong.SetActive(false);
    }
    public GameObject boy_guide_quit;
    public GameObject girl_guide_quit;
    public void showConfirmQuit()
    {
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
        confirmationQuit.SetActive(false);
    }
    public void stopSound()
    {
        audioSrc.Stop();
    }
}
