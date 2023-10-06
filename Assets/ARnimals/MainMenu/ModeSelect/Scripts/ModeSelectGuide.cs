using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectGuide : MonoBehaviour
{
    string GuideChosen;
    SaveObject loaddata;
    public TouchToNextModeSelect _TouchToNextModeSelectScript;
    public TMPro.TMP_Text pageNum;

    [Header("Guide Navi Buttons")]
    public GameObject _guideBack_ModeSelect;

    [Header("Guide")]
    public GameObject modeSelect_guide;
    public GameObject mode_SelectTxt;

    public GameObject Animals_AR_btn;
    public GameObject Animals_AR_txt;

    public GameObject minigames_btn;
    public GameObject minigames_txt;

    public GameObject back_txt;
    public GameObject back_btn;

    public GameObject guide_btn;
    public GameObject guide_txt;

    public GameObject maleGuide;
    public GameObject dialog_maleGuide;
    public GameObject femaleGuide;
    public GameObject dialog_femaleGuide;

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

        loaddata = SaveManager.Load();
        GuideChosen = StateNameController.guide_chosen;
        if (!StateNameController.modeSelectGuide)
        {
            _modeSelectGuide();

            StateNameController.modeSelectGuide = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        showDialogs();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToARExp()
    {
        SceneManager.LoadScene("Animal Selector AR");
    }

    public void goToMiniGames()
    {
        SceneManager.LoadScene("MiniGamesSelect");
    }
    public void _modeSelectGuide()
    {
        pageNum.text = "1/5";
        modeSelect_guide.gameObject.SetActive(true);
        pageNum.gameObject.SetActive(true);
        if (GuideChosen == "boy_guide")
        {
            _maleGuide();
        }
        else if (GuideChosen == "girl_guide")
        {
            _femaleGuide();
        }
    }
    void _maleGuide()
    {
        maleGuide.SetActive(true);
        dialog_maleGuide.SetActive(true);
        femaleGuide.SetActive(false);
        dialog_femaleGuide.SetActive(false);
    }
    void _femaleGuide()
    {
        femaleGuide.SetActive(true);
        dialog_femaleGuide.SetActive(true);
        maleGuide.SetActive(false);
        dialog_maleGuide.SetActive(false);
    }

    public void skipTutorial()
    {
        pageNum.text = "1/5";
        _TouchToNextModeSelectScript.setPageCtr(1);
        disableAllGuideGameObjects();
        modeSelect_guide.SetActive(false);
        if (!loaddata.ModeSelectTutorialDone)
        {
            loaddata.ModeSelectTutorialDone = true;
            SaveManager.Save(loaddata);
        }
    }
    public void GuideBack()
    {
        _TouchToNextModeSelectScript.minusPageCtr();
        disableAllGuideGameObjects();
    }

    void disableAllGuideGameObjects()
    {
        guide_btn.SetActive(false);
        guide_txt.SetActive(false);

        mode_SelectTxt.SetActive(false);

        Animals_AR_btn.SetActive(false);
        Animals_AR_txt.SetActive(false);

        minigames_btn.SetActive(false);
        minigames_txt.SetActive(false);

        back_btn.SetActive(false);
        back_txt.SetActive(false);
    }

    void showDialogs()
    {
        if (pageNum.text == "1/5")
        {
            _guideBack_ModeSelect.SetActive(false);
            guide_btn.SetActive(false);
            guide_txt.SetActive(false);
            Animals_AR_btn.SetActive(false);
            Animals_AR_txt.SetActive(false);

            //welcome
            mode_SelectTxt.SetActive(true);

        }
        else if (pageNum.text == "2/5")
        {
            _guideBack_ModeSelect.SetActive(true);
            mode_SelectTxt.SetActive(false);
            minigames_btn.SetActive(false);
            minigames_txt.SetActive(false);

            //AR Experience
            Animals_AR_btn.SetActive(true);
            Animals_AR_txt.SetActive(true);


        }
        else if (pageNum.text == "3/5")
        {
            Animals_AR_btn.SetActive(false);
            Animals_AR_txt.SetActive(false);
            back_btn.SetActive(false);
            back_txt.SetActive(false);

            //mini-games
            minigames_btn.SetActive(true);
            minigames_txt.SetActive(true);

        }
        else if (pageNum.text == "4/5")
        {
            minigames_btn.SetActive(false);
            minigames_txt.SetActive(false);
            guide_btn.SetActive(false);
            guide_txt.SetActive(false);

            //back button
            back_btn.SetActive(true);
            back_txt.SetActive(true);
        }
        else if (pageNum.text == "5/5")
        {
            back_btn.SetActive(false);
            back_txt.SetActive(false);

            //guide button
            guide_btn.SetActive(true);
            guide_txt.SetActive(true);
        }
    }
}
