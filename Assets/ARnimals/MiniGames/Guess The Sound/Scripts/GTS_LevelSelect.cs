using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GTS_LevelSelect : MonoBehaviour
{
    SaveObject loadedData;
    string guide_chosen;
    public GameObject[] locklevel; //index 0 at lvl 2
    public Button[] lvlBtns; //index 0 at lvl 2
    int currentStars;
    int unlockedLvl;

    AudioManager audioManager;
    void Start()
    {
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            if (audioManager.musicSource.isPlaying)
            {

            }
            else
            {
                audioManager.playBGMMusic(audioManager.mainBG);
            }
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

        loadedData = SaveManager.Load();
        guide_chosen = StateNameController.guide_chosen;
        unlockedLvl = loadedData.unlockedLevelMG2;
        checkUnlockLevel();
        
        
    }
    void checkUnlockLevel()
    {
        if (unlockedLvl == 1)
        {
            lockLvl_disableBtn();
        }
        if (unlockedLvl == 2)
        {
            locklevel[0].SetActive(false);
            lvlBtns[0].interactable = true;
            lockLvl_disableBtn();
        }
        if (unlockedLvl == 3)
        {
            for (int i = 0; i <= 2; i++)
            {
                locklevel[i].SetActive(false);
                lvlBtns[i].interactable = true;
            }
            lockLvl_disableBtn();

        }
        if (unlockedLvl == 4)
        {
            for (int i = 0; i <= 3; i++)
            {
                locklevel[i].SetActive(false);
                lvlBtns[i].interactable = true;
            }
            lockLvl_disableBtn();

        }
        if (unlockedLvl == 5)
        {

            for (int i = 0; i <= 4; i++)
            {
                locklevel[i].SetActive(false);
                lvlBtns[i].interactable = true;
            }
            lockLvl_disableBtn();
        }
        if (unlockedLvl == 6)
        {
            locklevel[0].SetActive(false);
            locklevel[1].SetActive(false);
            locklevel[2].SetActive(false);
            locklevel[3].SetActive(false);
            lockLvl_disableBtn();
        }
    }
    void lockLvl_disableBtn()
    { 

        for (int i = unlockedLvl - 1; i < locklevel.Length; i++)
        {
            locklevel[i].SetActive(true);
            lvlBtns[i].interactable = false;
        }
    }

    public Sprite[] levelSpriteContainer;
    public Image levelSelectedImg;
    public Sprite[] starsSpriteContainer;
    public Image CurrentStarsImg;
    public GameObject playConfirm;

    public Sprite[] unlockAnimalImgSprites;
    public Image unlockAnimalImg;
    public GameObject checkImg;

    int levelNumber;
    public TMP_Text animalName;
    public Button tryAnimal;

    public GameObject mainNextLevelUnlockGO;
    public Image levelToUnlockImg;
    public Sprite[] levelsSprite;
    public GameObject levelUnlockGO;
    public TMP_Text allLevelsUnlockedTxt;
    public GameObject checkImgUnlockedLevelBoard;

    void checkCurrentStars()
    {
        if (currentStars == 3)
        {
            //Animal
            CurrentStarsImg.sprite = starsSpriteContainer[0];
            unlockAnimalImg.color = new Color32(142, 142, 142, 255);
            tryAnimal.gameObject.SetActive(true);
            checkImg.SetActive(true);

            // unlockLevelBoard
            checkImgUnlockedLevelBoard.SetActive(true);
        }
        else if (currentStars == 2)
        {
            //Animal
            CurrentStarsImg.sprite = starsSpriteContainer[1];
            unlockAnimalImg.color = new Color32(255, 255, 255, 255);
            checkImg.SetActive(false);// animal
            tryAnimal.gameObject.SetActive(false);


            // unlockLevelBoard
            checkImgUnlockedLevelBoard.SetActive(true);
        }
        else if (currentStars == 1)
        {
            //Animal
            CurrentStarsImg.sprite = starsSpriteContainer[2];
            unlockAnimalImg.color = new Color32(255, 255, 255, 255);
            checkImg.SetActive(false);// animal
            tryAnimal.gameObject.SetActive(false);

            // unlockLevelBoard
            checkImgUnlockedLevelBoard.SetActive(false);

        }
        else
        {
            //Animal
            CurrentStarsImg.sprite = starsSpriteContainer[3];
            unlockAnimalImg.color = new Color32(255, 255, 255, 255);
            checkImg.SetActive(false);// animal
            tryAnimal.gameObject.SetActive(false);

            // unlockLevelBoard
            checkImgUnlockedLevelBoard.SetActive(false);

        }
    }

    void changePlayConfirmVariables()
    {
        switch (levelNumber)
        {
            case 1:
                levelSelectedImg.sprite = levelSpriteContainer[0];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[0];
                currentStars = loadedData.GTS_lvl1_star;
                animalName.text = "Rhinoceros";

                // unlockLevelBoard
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                levelToUnlockImg.sprite = levelsSprite[0];
                checkCurrentStars();


                break;
            case 2:
                levelSelectedImg.sprite = levelSpriteContainer[1];
                currentStars = loadedData.GTS_lvl2_star;
                unlockAnimalImg.sprite = unlockAnimalImgSprites[1];
                animalName.text = "Camel";

                // unlockLevelBoard
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                levelToUnlockImg.sprite = levelsSprite[1];

                checkCurrentStars();


                break;
            case 3:
                levelSelectedImg.sprite = levelSpriteContainer[2];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[2];
                currentStars = loadedData.GTS_lvl3_star;
                animalName.text = "Bat";

                // unlockLevelBoard
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                levelToUnlockImg.sprite = levelsSprite[2];

                checkCurrentStars();

                break;
            case 4:
                levelSelectedImg.sprite = levelSpriteContainer[3];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[3];
                currentStars = loadedData.GTS_lvl4_star;
                animalName.text = "Koi";

                // unlockLevelBoard
                levelUnlockGO.SetActive(true);
                allLevelsUnlockedTxt.gameObject.SetActive(false);
                levelToUnlockImg.sprite = levelsSprite[3];

                checkCurrentStars();


                break;
            case 5:
                levelSelectedImg.sprite = levelSpriteContainer[4];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[4];
                currentStars = loadedData.GTS_lvl5_star;
                animalName.text = "Crab";


                // unlockLevelBoard
                levelUnlockGO.SetActive(false);
                allLevelsUnlockedTxt.gameObject.SetActive(true);

                checkCurrentStars();

                break;
        }
    }
    public GameObject confirmGoToARExp;
    public GameObject boy_guide_goToAR;
    public GameObject girl_guide_goToAR;
    public void showConfirmGoToAR()
    {
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
        confirmGoToARExp.SetActive(false);
    }

    public void StartGame(Button clickedButton)
    {
        string buttonName = clickedButton.name;
        string numericPart = buttonName.Substring(3); // Assuming "lvl" prefix is present in GameObject name
        levelNumber = int.Parse(numericPart);

        StateNameController.levelClickedMG2 = levelNumber;
        Debug.Log("Button clicked: Level " + levelNumber);
        changePlayConfirmVariables();
        
        showPlayConfirm();
    }
    public void hidePlayConfirm()
    {
        playConfirm.SetActive(false);
    }
    public void showPlayConfirm()
    {
        playConfirm.SetActive(true);
    }
    public void _startGame()
    {
        SceneManager.LoadScene("GTAFS_Game");
    }
}