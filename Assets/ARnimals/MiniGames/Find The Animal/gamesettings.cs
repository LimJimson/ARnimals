using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamesettings : MonoBehaviour
{
    string guide_chosen;
    SaveObject existingSO;
    public GameObject GameUI;
    public int levelSelected;
    public GameObject confirmCorrect;
    public GameObject confirmWrong;
    public GameObject confirmationQuit;
    public GameObject playAgainConfirm;
    public GameObject restartLevelConfirm;
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

        if (levelSelected == 0)
        {
            levelSelected = 1;
        }

        if (string.IsNullOrEmpty(guide_chosen))
        {
            guide_chosen = "boy_guide";
        }

    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitLevel()
    {
        SceneManager.LoadScene("FTA_lvlSelect");
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
}