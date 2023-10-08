using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuSettingsGuide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public GameObject Settings_GO;
    public touchToNextMainMenuSettings _touchToNextMainMenuSettings;

    [Header("GUIDE POSITION 1")]
    public GameObject pos1_GO;
    public GameObject boyGuidePos1;
    public GameObject boyDialogPos1;
    public GameObject girlGuidePos1;
    public GameObject girldialogPos1;
    public GameObject backBtnPos1;
    public TMP_Text pageNumPos1;


    [Header("GUIDE POSITION 2")]
    public GameObject pos2_GO;
    public GameObject boyGuidePos2;
    public GameObject boyDialogPos2;
    public GameObject girlGuidePos2;
    public GameObject girldialogPos2;
    public TMP_Text pageNumPos2;


    [Header("Dialogues")]
    public TMP_Text welcomeTxt;
    public TMP_Text musicVolTxt;
    public TMP_Text animalVolumeTxt;
    public TMP_Text sfxVolumeTxt;
    public TMP_Text guideVolumeTxt;
    public TMP_Text changeNameTxt;
    public TMP_Text changeGuideTxt;
    public TMP_Text resetGameTxt;
    public TMP_Text backBtnTxt;
    public TMP_Text guideBtnTxt;

    [Header("Highlights")]
    public GameObject musicHighlight;
    public GameObject sfxHighlight;
    public GameObject animalVolHighlight;
    public GameObject guideVolHighlight;
    public GameObject changeNameHighlight;
    public GameObject changeGuideHighlight;
    public GameObject resetGameHighlight;
    public GameObject backHighlight;
    public GameObject guideHighlight;

    void Start()
    {
        loaddata = SaveManager.Load();
        guideChosen = StateNameController.guide_chosen;
        if (!StateNameController.mainMenuSettingsGuide)
        {
            _MainMenuSettingsGuide();
            StateNameController.mainMenuSettingsGuide = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        showDialogs();

    }
    public void skipTutorial()
    {
        pageNumPos1.text = "1/10";
        pageNumPos2.text = "1/10";
        _touchToNextMainMenuSettings.setPageCtr(1);
        disableAllGuideGameObjects();
        Settings_GO.SetActive(false);

        if (!loaddata.mainMenuSettingsGuide)
        {
            loaddata.mainMenuSettingsGuide = true;
            SaveManager.Save(loaddata);
        }
    }

    public void GuideBack()
    {
        _touchToNextMainMenuSettings.minusPageCtr();
        disableAllGuideGameObjects();
    }
    void disableAllGuideGameObjects()
    {

        welcomeTxt.gameObject.SetActive(false);

        musicVolTxt.gameObject.SetActive(false);
        musicHighlight.gameObject.SetActive(false);

        sfxVolumeTxt.gameObject.SetActive(false);
        sfxHighlight.gameObject.SetActive(false);

        animalVolumeTxt.gameObject.SetActive(false);
        animalVolHighlight.gameObject.SetActive(false);

        guideVolumeTxt.gameObject.SetActive(false);
        guideVolHighlight.gameObject.SetActive(false);

        changeNameTxt.gameObject.SetActive(false);
        changeNameHighlight.SetActive(false);

        changeGuideTxt.gameObject.SetActive(false);
        changeGuideHighlight.SetActive(false);

        resetGameTxt.gameObject.SetActive(false);
        resetGameHighlight.SetActive(false);

        backBtnTxt.gameObject.SetActive(false);
        backHighlight.gameObject.SetActive(false);

        guideBtnTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }

    public void _MainMenuSettingsGuide()
    {
        Settings_GO.SetActive(true);

        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);

        pageNumPos1.text = "1/10";

        if (guideChosen == "boy_guide")
        {
            _maleGuide();
        }
        else if (guideChosen == "girl_guide")
        {
            _femaleGuide();
        }
    }
    void _maleGuide()
    {
        boyGuidePos1.SetActive(true);
        boyGuidePos2.SetActive(true);
        boyDialogPos1.SetActive(true);
        boyDialogPos2.SetActive(true);


        girlGuidePos1.SetActive(false);
        girldialogPos1.SetActive(false);
        girlGuidePos2.SetActive(false);
        girldialogPos2.SetActive(false);

    }
    void _femaleGuide()
    {
        girlGuidePos1.SetActive(true);
        girldialogPos1.SetActive(true);
        girlGuidePos2.SetActive(true);
        girldialogPos2.SetActive(true);

        boyGuidePos1.SetActive(false);
        boyGuidePos2.SetActive(false);
        boyDialogPos1.SetActive(false);
        boyDialogPos2.SetActive(false);
    }
    void showDialogs()
    {

        if (pageNumPos1.text == "1/10")
        {
            welcomeTxt.gameObject.SetActive(true);
            backBtnPos1.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);



        }
        else if (pageNumPos1.text == "2/10")
        {

            welcomeTxt.gameObject.SetActive(false);
            backBtnPos1.SetActive(true);

            musicVolTxt.gameObject.SetActive(true);
            musicHighlight.gameObject.SetActive(true);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

        }
        else if (pageNumPos1.text == "3/10")
        {

            welcomeTxt.gameObject.SetActive(false);


            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(true);
            animalVolHighlight.gameObject.SetActive(true);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);


        }
        else if (pageNumPos1.text == "4/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(true);
            sfxHighlight.gameObject.SetActive(true);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
        }
        else if (pageNumPos1.text == "5/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(true);
            guideVolHighlight.gameObject.SetActive(true);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

        }
        else if (pageNumPos1.text == "6/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(true);
            changeNameHighlight.SetActive(true);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "7/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(true);
            changeGuideHighlight.SetActive(true);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "8/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(true);
            resetGameHighlight.SetActive(true);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "9/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(true);
            backHighlight.gameObject.SetActive(true);

            guideBtnTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "10/10")
        {
            welcomeTxt.gameObject.SetActive(false);

            musicVolTxt.gameObject.SetActive(false);
            musicHighlight.gameObject.SetActive(false);

            sfxVolumeTxt.gameObject.SetActive(false);
            sfxHighlight.gameObject.SetActive(false);

            animalVolumeTxt.gameObject.SetActive(false);
            animalVolHighlight.gameObject.SetActive(false);

            guideVolumeTxt.gameObject.SetActive(false);
            guideVolHighlight.gameObject.SetActive(false);

            changeNameTxt.gameObject.SetActive(false);
            changeNameHighlight.SetActive(false);

            changeGuideTxt.gameObject.SetActive(false);
            changeGuideHighlight.SetActive(false);

            resetGameTxt.gameObject.SetActive(false);
            resetGameHighlight.SetActive(false);

            backBtnTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideBtnTxt.gameObject.SetActive(true);
            guideHighlight.gameObject.SetActive(true);
        }
    }
}
