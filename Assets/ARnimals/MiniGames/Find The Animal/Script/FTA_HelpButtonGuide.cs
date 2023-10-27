using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FTA_HelpButtonGuide : MonoBehaviour
{
    SaveObject GuideLoadData;

    AudioManager AudioManager;

    public FTA_GameManager gameManager;

    public GameObject Health;
    public GameObject ShadowHint;
    public GameObject HiddenBg;
    public GameObject HintBorder;
    public GameObject Timer;
    public GameObject Settings;
    public GameObject HelpGuide;

    public GameObject welcomeguidetxt;
    public GameObject boardshadowtxt;
    public GameObject hearttxt;
    public GameObject hinttxt;
    public GameObject timertxt;
    public GameObject hidinganimaltxt;
    public GameObject settingstxt;
    public GameObject guidedtxt;

    public GameObject BackBtn;

    public GameObject Guideoff;

    public TextMeshProUGUI PageNumbertxt;

    int pageNumber = 1;

    void Start()
    {
        GuideLoadData = SaveManager.Load();
        GuideChosen = GuideLoadData.guideChosen;
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        CheckPageNumber();
        GuideBoyorGirl();
    }
    

    void Update()
    {

    }
    public void CheckPageNumber()
    {
        DisableAll();
        switch (pageNumber)
        {
            case 1:
                welcomeguidetxt.SetActive(true);
                PageNumbertxt.text = "1/8";
                BackBtn.SetActive(false);
                NarratorGuide();
                break;
            case 2:
                boardshadowtxt.SetActive(true);
                ShadowHint.SetActive(true);
                PageNumbertxt.text = "2/8";
                BackBtn.SetActive(true);
                NarratorGuide();
                break;
            case 3:
                hearttxt.SetActive(true);
                Health.SetActive(true);
                PageNumbertxt.text = "3/8";
                NarratorGuide();
                break;
            case 4:
                hinttxt.SetActive(true);
                HintBorder.SetActive(true);
                PageNumbertxt.text = "4/8";
                NarratorGuide();
                break;
            case 5:
                timertxt.SetActive(true);
                Timer.SetActive(true);
                PageNumbertxt.text = "5/8";
                NarratorGuide();
                break;
            case 6:
                hidinganimaltxt.SetActive(true);
                HiddenBg.SetActive(true);
                PageNumbertxt.text = "6/8";
                NarratorGuide();
                break;
            case 7:
                settingstxt.SetActive(true);
                Settings.SetActive(true);
                PageNumbertxt.text = "7/8";
                NarratorGuide();
                break;
            case 8:
                guidedtxt.SetActive(true);
                HelpGuide.SetActive(true);
                PageNumbertxt.text = "8/8";
                NarratorGuide();
                break;
        }
    }

    public void DisableAll()
    {
        welcomeguidetxt.SetActive(false);

        boardshadowtxt.SetActive(false);
        ShadowHint.SetActive(false);

        hearttxt.SetActive(false);
        Health.SetActive(false);

        hinttxt.SetActive(false);
        HintBorder.SetActive(false);

        timertxt.SetActive(false);
        Timer.SetActive(false);

        hidinganimaltxt.SetActive(false);
        HiddenBg.SetActive(false);

        settingstxt.SetActive(false);
        Settings.SetActive(false);

        guidedtxt.SetActive(false);
        HelpGuide.SetActive(false);
    }


    public void clicktoNext()
    {
        if (pageNumber <= 7)
        {
            pageNumber += 1;
            CheckPageNumber();
        }
        else
        {
            pageNumber = 1;
            Guideoff.SetActive(false);
            gameManager.ResumeGame();
            CheckPageNumber();
            if (gameManager.CheckIfFisrtItemGuide)
            {
                gameManager.InstructionGamePanel.SetActive(true);
                gameManager.Invoke("StartCountdownStarts", 0.8f);
                gameManager.Invoke("ClickToStart", 3f);
            }
            GuideLoadData.FTA_GAME_GUIDE = true;
            SaveManager.Save(GuideLoadData);
            AudioManager.guideSource.Stop();
            gameManager.isGuideClicked = false;
            AudioManager.sfxSource.UnPause();
        }
    }
    public void BackButton()
    {
        pageNumber -= 1;
        CheckPageNumber();
    }
    public void SkipButton()
    {
        pageNumber = 1;
        Guideoff.SetActive(false);
        gameManager.ResumeGame();
        CheckPageNumber();
        if (gameManager.CheckIfFisrtItemGuide)
        {
            gameManager.InstructionGamePanel.SetActive(true);
            gameManager.Invoke("StartCountdownStarts", 0.8f);
            gameManager.Invoke("ClickToStart", 3f);
        }
        GuideLoadData.FTA_GAME_GUIDE = true;
        SaveManager.Save(GuideLoadData);
        AudioManager.guideSource.Stop();
        gameManager.isGuideClicked = false;
        AudioManager.sfxSource.UnPause();
    }

    public GameObject BoyGuide;
    public GameObject GirlGuide;

    string GuideChosen;
    public void GuideBoyorGirl()
    {
        if (GuideChosen == "boy_guide")
        {
            BoyGuide.SetActive(true);
            GirlGuide.SetActive(false);
        }
        else if (GuideChosen == "girl_guide")
        {
            BoyGuide.SetActive(false);
            GirlGuide.SetActive(true);
        }
    }
    public void NarratorGuide()
    {
        if (gameManager.isGuideClicked)
        {
            if (GuideChosen == "boy_guide")
            {
                AudioManager.PlayGuide(AudioManager.FTA_Patrick[pageNumber - 1]);
            }
            else if (GuideChosen == "girl_guide")
            {
                AudioManager.PlayGuide(AudioManager.FTA_Sandy[pageNumber - 1]);
            }
        }
    }
}
