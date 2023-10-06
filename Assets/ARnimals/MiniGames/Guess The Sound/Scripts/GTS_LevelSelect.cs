using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GTS_LevelSelect : MonoBehaviour
{
    SaveObject loadedData;
    public GameObject[] locklevel; //index 0 at lvl 2
    public Button[] lvlBtns; //index 0 at lvl 2
    int currentStarsLvl1;
    int currentStarsLvl2;
    int currentStarsLvl3;
    int currentStarsLvl4;
    int currentStarsLvl5;
    int unlockedLvl;
    void Start()
    {
        loadedData = SaveManager.Load();
        unlockedLvl = loadedData.unlockedLevelMG2;
        checkUnlockLevel();
        
        
    }
    void checkUnlockLevel()
    {
        if (unlockedLvl == 1)
        {
            lockLvl_disableBtn();
        }
        else if (unlockedLvl == 2)
        {
            locklevel[0].SetActive(false);
            lockLvl_disableBtn();
        }
        else if (unlockedLvl == 3)
        {
            locklevel[0].SetActive(false);
            locklevel[1].SetActive(false);
            lockLvl_disableBtn();

        }
        else if (unlockedLvl == 4)
        {
            locklevel[0].SetActive(false);
            locklevel[1].SetActive(false);
            locklevel[2].SetActive(false);
            lockLvl_disableBtn();

        }
        else if (unlockedLvl == 5)
        {
            locklevel[0].SetActive(false);
            locklevel[1].SetActive(false);
            locklevel[2].SetActive(false);
            locklevel[3].SetActive(false);
            lockLvl_disableBtn();
        }
        else if (unlockedLvl == 6)
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

    void changePlayConfirmVariables()
    {
        switch (levelNumber)
        {
            case 1:
                levelSelectedImg.sprite = levelSpriteContainer[0];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[0];
                currentStarsLvl1 = loadedData.GTS_lvl1_star;
                if (currentStarsLvl1 == 3)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[0];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl1 == 2)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[1];
                    unlockAnimalImg.color = new Color32(142, 142, 142,255);
                    checkImg.SetActive(true);

                }
                else if (currentStarsLvl1 == 1)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[2];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                else
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[3];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                break;
            case 2:
                levelSelectedImg.sprite = levelSpriteContainer[1];
                currentStarsLvl2 = loadedData.GTS_lvl2_star;
                unlockAnimalImg.sprite = unlockAnimalImgSprites[1];
                if (currentStarsLvl2 == 3)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[0];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl2 == 2)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[1];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl2 == 1)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[2];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                else
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[3];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                break;
            case 3:
                levelSelectedImg.sprite = levelSpriteContainer[2];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[2];
                currentStarsLvl3 = loadedData.GTS_lvl3_star;
                if (currentStarsLvl3 == 3)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[0];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl3 == 2)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[1];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl3 == 1)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[2];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                else
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[3];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                break;
            case 4:
                levelSelectedImg.sprite = levelSpriteContainer[3];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[3];
                currentStarsLvl4 = loadedData.GTS_lvl4_star;
                if (currentStarsLvl4 == 3)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[0];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl4 == 2)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[1];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl4 == 1)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[2];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                else
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[3];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                break;
            case 5:
                levelSelectedImg.sprite = levelSpriteContainer[4];
                unlockAnimalImg.sprite = unlockAnimalImgSprites[4];
                currentStarsLvl5 = loadedData.GTS_lvl5_star;
                if (currentStarsLvl5 == 3)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[0];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl5 == 2)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[1];
                    unlockAnimalImg.color = new Color32(142, 142, 142, 255);
                    checkImg.SetActive(true);
                }
                else if (currentStarsLvl5 == 1)
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[2];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                else
                {
                    CurrentStarsImg.sprite = starsSpriteContainer[3];
                    unlockAnimalImg.color = new Color32(255, 255, 255, 255);
                    checkImg.SetActive(false);
                }
                break;
        }
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