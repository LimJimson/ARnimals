using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGuide : MonoBehaviour
{
    string GuideChosen;

    public Canvas main_menu_guide;
    public TouchToNextMainMenu _TouchToNextMainMenuGuideScript;
    public GameObject origHelpBtn;

    public TMP_Text pageNum;

    [Header("Guide Navi Buttons")]
    public GameObject skipBtn;
    public GameObject _GuideBackBtn;

    [Header("Guide")]
    public GameObject firstStartTxt;
    public GameObject firstStartTxtGirl;

    public GameObject main_menuTxt;

    public GameObject startBtn;
    public GameObject startHelpTxt;

    public GameObject AnimalsBtn;
    public GameObject AnimalsHelpTxt;

    public GameObject SettingsBtn;
    public GameObject SettingsHelpTxt;

    public GameObject QuitBtn;
    public GameObject QuitBtnHelpTxt;

    public GameObject HelpBtn;
    public GameObject HelpTxt;

    public GameObject maleGuide;
    public GameObject femaleGuide;
    void Start()
    {
        GuideChosen = StateNameController.guide_chosen;
        SaveObject loaddata = SaveManager.Load();
        if (string.IsNullOrEmpty(GuideChosen))
        {
            GuideChosen = "boy_guide";
        }


        if (!StateNameController.mainMenuGuide)
        {
            checkGuideGender();
            _TouchToNextMainMenuGuideScript.minusCtr();
            guideBtnClicked();
            loaddata.MainMenuTutorialDone = true;
            SaveManager.Save(loaddata);
            StateNameController.mainMenuGuide = true;
        }


    }

    
    void Update()
    {
        showDialogs();
    }

    public void checkGuideGender()
    {
        if (GuideChosen == "boy_guide")
        {
            firstStartTxt.SetActive(true);
            firstStartTxtGirl.SetActive(false);
        }
        else if (GuideChosen == "girl_guide")
        {
            firstStartTxtGirl.SetActive(true);
            firstStartTxt.SetActive(false);
        }
    }
    
    public void skipTutorial()
    {

        pageNum.text = "1/6";
        _TouchToNextMainMenuGuideScript.setPageCtr(1);
        disableAllGuideGameObjects();
        main_menu_guide.gameObject.SetActive(false);
        
    }

    public void GuideBack()
    {
        _TouchToNextMainMenuGuideScript.minusCtr();
        disableAllGuideGameObjects();
    }

    void disableAllGuideGameObjects()
    {
        firstStartTxt.SetActive(false);
        firstStartTxtGirl.SetActive(false);

        main_menuTxt.SetActive(false);

        startBtn.SetActive(false);
        startHelpTxt.SetActive(false);

        AnimalsBtn.SetActive(false);
        AnimalsHelpTxt.SetActive(false);

        SettingsBtn.SetActive(false);
        SettingsHelpTxt.SetActive(false);

        QuitBtn.SetActive(false);
        QuitBtnHelpTxt.SetActive(false);

        HelpBtn.SetActive(false);
        HelpTxt.SetActive(false);

        
    }


    public void guideBtnClicked()
    {
        
        main_menu_guide.gameObject.SetActive(true);
        pageNum.gameObject.SetActive(true);

        if (!StateNameController.mainMenuGuide)
        {
            pageNum.text = "";
            checkGuideGender();
        }
        else
        {
            pageNum.text = "1/6";
        }

        if (GuideChosen == "boy_guide")
        {
            _maleGuide();
        }
        else if (GuideChosen == "girl_guide")
        {
            _femaleGuide();
        }
    }
    public void _maleGuide()
    {
        maleGuide.SetActive(true);
        femaleGuide.SetActive(false);
    }

    public void _femaleGuide()
    {
        maleGuide.SetActive(false);
        femaleGuide.SetActive(true);
    }

    void showDialogs()
    {

        if (pageNum.text == "1/6")
        {
            HelpBtn.SetActive(false);
            HelpTxt.SetActive(false);
            firstStartTxt.SetActive(false);
            firstStartTxtGirl.SetActive(false);
            _GuideBackBtn.SetActive(false);
            startBtn.SetActive(false);
            startHelpTxt.SetActive(false);
            

            //skip button
            skipBtn.SetActive(true);

            //welcome message
            main_menuTxt.SetActive(true);

        }
        else if (pageNum.text == "2/6")
        {

            main_menuTxt.SetActive(false);
            AnimalsBtn.SetActive(false);
            AnimalsHelpTxt.SetActive(false);
            //back button
            _GuideBackBtn.SetActive(true);

            //start
            startBtn.SetActive(true);
            startHelpTxt.SetActive(true);

        }
        else if (pageNum.text == "3/6")
        {
            startBtn.SetActive(false);
            startHelpTxt.SetActive(false);
            SettingsBtn.SetActive(false); 
            SettingsHelpTxt.SetActive(false);

            //animals
            AnimalsBtn.SetActive(true);
            AnimalsHelpTxt.SetActive(true);

        }
        else if (pageNum.text == "4/6")
        {
            AnimalsBtn.SetActive(false);
            AnimalsHelpTxt.SetActive(false);
            QuitBtn.SetActive(false);
            QuitBtnHelpTxt.SetActive(false);

            //settings
            SettingsBtn.SetActive(true);
            SettingsHelpTxt.SetActive(true);
        }
        else if (pageNum.text == "5/6")
        {
            SettingsBtn.SetActive(false);
            SettingsHelpTxt.SetActive(false);
            HelpBtn.SetActive(false);
            HelpTxt.SetActive(false);

            //quit
            QuitBtn.SetActive(true);
            QuitBtnHelpTxt.SetActive(true);
        }
        else if (pageNum.text == "6/6")
        {
            QuitBtn.SetActive(false);
            QuitBtnHelpTxt.SetActive(false);
            //guide
            HelpBtn.SetActive(true);
            HelpTxt.SetActive(true);
        }
        
    }
    //settings guide

    
}
