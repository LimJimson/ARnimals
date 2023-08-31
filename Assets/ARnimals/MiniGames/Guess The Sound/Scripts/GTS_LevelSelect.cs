using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GTS_LevelSelect : MonoBehaviour
{
    public SaveObject soScript;
    SaveObject loadedData;
    public GameObject[] locklevel; //index 0 at lvl 2
    public GameObject[] unlockAnimal; //index 0 at unlock1
    public Button[] lvlBtns; //index 0 at lvl 2

    int unlockedLvl;
    void Start()
    {
        loadedData = SaveManager.Load();
        unlockedLvl = loadedData.unlockedLevelMG2 +1;

        if (unlockedLvl == 1)
        {
            unlockAnimal[0].SetActive(true);
            lockLvl_disableBtn();
        }
        else if (unlockedLvl == 2)
        {
            unlockAnimal[1].SetActive(true);
            locklevel[0].SetActive(false);
            lockLvl_disableBtn();
        }
        else if (unlockedLvl == 3)
        {
            unlockAnimal[1].SetActive(false);
            locklevel[0].SetActive(false);
            unlockAnimal[2].SetActive(true);
            locklevel[1].SetActive(false);
            lockLvl_disableBtn();

        }
        else if (unlockedLvl == 4)
        {
            unlockAnimal[1].SetActive(false);
            locklevel[0].SetActive(false);
            unlockAnimal[2].SetActive(false);
            locklevel[1].SetActive(false);
            unlockAnimal[3].SetActive(true);
            locklevel[2].SetActive(false);
            lockLvl_disableBtn();

        }
        else if (unlockedLvl == 5)
        {
            unlockAnimal[1].SetActive(false);
            locklevel[0].SetActive(false);
            unlockAnimal[2].SetActive(false);
            locklevel[1].SetActive(false);
            unlockAnimal[3].SetActive(false);
            locklevel[2].SetActive(false);
            unlockAnimal[4].SetActive(true);
            locklevel[3].SetActive(false);
            lockLvl_disableBtn();
        }else if (unlockedLvl == 6)
        {
            unlockAnimal[1].SetActive(false);
            locklevel[0].SetActive(false);
            unlockAnimal[2].SetActive(false);
            locklevel[1].SetActive(false);
            unlockAnimal[3].SetActive(false);
            locklevel[2].SetActive(false);
            unlockAnimal[4].SetActive(false);
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
    public void StartGame(Button clickedButton)
    {
        string buttonName = clickedButton.name;
        string numericPart = buttonName.Substring(3); // Assuming "lvl" prefix is present
        int levelNumber = int.Parse(numericPart);

        StateNameController.levelClickedMG2 = levelNumber;
        Debug.Log("Button clicked: Level " + levelNumber);

        // Additional logic based on the level number

        SceneManager.LoadScene("GTAFS_Game");
    }

}