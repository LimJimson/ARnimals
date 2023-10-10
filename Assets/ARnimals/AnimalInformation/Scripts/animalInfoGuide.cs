using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class animalInfoGuide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public touchToNextAnimal_Info _touchToNextAnimal_Info;
    public AnimalInfoScript _animalInfoScript;

    public GameObject _animalInfoGuide;
    public GameObject _realMainAnimalInfo;
    public GameObject _realAnimalInfoGO;

    public GameObject clickAnywherePos1;
    public GameObject clickAnywherePos2;

    public GameObject videoPlayerGO;

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
    public GameObject backBtnPos2;
    public TMP_Text pageNumPos2;

    [Header("GUIDE POSITION 3")]
    public GameObject pos3_GO;
    public GameObject boyGuidePos3;
    public GameObject boyDialogPos3;
    public GameObject girlGuidePos3;
    public GameObject girldialogPos3;
    public GameObject backBtnPos3;
    public TMP_Text pageNumPos3;


    [Header("Dialogues")]
    public TMP_Text welcomeTxt;
    public TMP_Text categorizeTxt;
    public TMP_Text chooseAnimalTxt;
    public TMP_Text animalTxt;
    public TMP_Text speakerTxt;
    public TMP_Text vidTxt;
    public TMP_Text playVidTxt;
    public TMP_Text fullScreenVidTxt;
    public TMP_Text informationTxt;
    public TMP_Text settingsTxt;
    public TMP_Text backAnimalInfoSelectTxt;
    public TMP_Text backMainMenuTxt;
    public TMP_Text guideTxt;

    [Header("Highlights")]
    public GameObject categorizeHighlight;
    public GameObject chooseAnimalHighlight;
    public GameObject animalHighlight;
    public GameObject speakerHighlight;
    public GameObject vidHighlight;
    public GameObject playVidHighlight;
    public GameObject fullScreenVidHighlight;
    public GameObject informationHighlight;
    public GameObject settingsHighlight;
    public GameObject backAnimalInfoSelectHighlight;
    public GameObject backMainMenuHighlight;
    public GameObject guideHighlight;

    void Start()
    {
        loaddata = SaveManager.Load();
        guideChosen = StateNameController.guide_chosen;
        if (!StateNameController.animalInfoGuide)
        {
            _animalInformationGuide();

            StateNameController.animalInfoGuide = true;
        }

    }

    void Update()
    {
        showDialogs();
    }
    public GameObject backAndGuideBtns;
    public void skipTutorial()
    {
        pageNumPos1.text = "1/13";
        pageNumPos2.text = "1/13";
        pageNumPos3.text = "1/13";
        _touchToNextAnimal_Info.setPageCtr(1);

        backAndGuideBtns.SetActive(true);
        disableAllGuideGameObjects();
        _animalInfoGuide.SetActive(false);


        videoPlayerGO.gameObject.SetActive(false);
        _realAnimalInfoGO.SetActive(false);
        _realMainAnimalInfo.SetActive(true);


        if (!loaddata.animalInfoGuide)
        {
            loaddata.animalInfoGuide = true;
            SaveManager.Save(loaddata);
        }
    }
    public void disableAllGuideGameObjects()
    {

        welcomeTxt.gameObject.SetActive(false);
        categorizeTxt.gameObject.SetActive(false);
        categorizeHighlight.SetActive(false);

        chooseAnimalTxt.gameObject.SetActive(false);
        chooseAnimalHighlight.SetActive(false);

        animalTxt.gameObject.SetActive(false);
        animalHighlight.SetActive(false);

        speakerTxt.gameObject.SetActive(false);
        speakerHighlight.SetActive(false);

        vidTxt.gameObject.SetActive(false);
        vidHighlight.SetActive(false);

        playVidTxt.gameObject.SetActive(false);
        playVidHighlight.SetActive(false);

        fullScreenVidTxt.gameObject.SetActive(false);
        fullScreenVidHighlight.SetActive(false);

        informationTxt.gameObject.SetActive(false);
        informationHighlight.SetActive(false);

        settingsTxt.gameObject.SetActive(false);
        settingsHighlight.SetActive(false);

        backAnimalInfoSelectTxt.gameObject.SetActive(false);
        backAnimalInfoSelectHighlight.SetActive(false);

        backMainMenuTxt.gameObject.SetActive(false);
        backMainMenuHighlight.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.SetActive(false);

    }
    public void GuideBack()
    {
        _touchToNextAnimal_Info.minusPageCtr();
        disableAllGuideGameObjects();
    }
    public void _animalInformationGuide()
    {
        _animalInfoGuide.gameObject.SetActive(true);
        _animalInfoScript.chosenAnimalIndex = 1;
        _animalInfoScript.showAnimalInfo();
        _realMainAnimalInfo.SetActive(true);
        _realAnimalInfoGO.SetActive(false);
        backAndGuideBtns.SetActive(true);
        videoPlayerGO.gameObject.SetActive(false);
        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);
        pos3_GO.SetActive(false);

        pageNumPos1.text = "1/13";

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
        boyDialogPos3.SetActive(true);
        boyDialogPos3.SetActive(true);


        girlGuidePos1.SetActive(false);
        girldialogPos1.SetActive(false);
        girlGuidePos2.SetActive(false);
        girldialogPos2.SetActive(false);
        girlGuidePos3.SetActive(false);
        girldialogPos3.SetActive(false);

    }
    void _femaleGuide()
    {
        girlGuidePos1.SetActive(true);
        girldialogPos1.SetActive(true);
        girlGuidePos2.SetActive(true);
        girldialogPos2.SetActive(true);
        girlGuidePos3.SetActive(true);
        girldialogPos3.SetActive(true);

        boyGuidePos1.SetActive(false);
        boyGuidePos2.SetActive(false);
        boyDialogPos1.SetActive(false);
        boyDialogPos2.SetActive(false);
        boyDialogPos3.SetActive(false);
        boyDialogPos3.SetActive(false);
    }

    void showDialogs()
    {

        if (pageNumPos1.text == "1/13")
        {
            
            welcomeTxt.gameObject.SetActive(true);
            backBtnPos1.SetActive(false);

            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);


        }
        else if (pageNumPos1.text == "2/13")
        {
            
            categorizeHighlight.SetActive(true);
            categorizeTxt.gameObject.SetActive(true);
            backBtnPos1.SetActive(true);

            _realMainAnimalInfo.SetActive(true);
            _realAnimalInfoGO.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);

        }
        else if (pageNumPos1.text == "3/13")
        {
            
            chooseAnimalHighlight.SetActive(true);
            chooseAnimalTxt.gameObject.SetActive(true);

            _realAnimalInfoGO.SetActive(false);
            _realMainAnimalInfo.SetActive(true);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
            pos3_GO.SetActive(false);

            videoPlayerGO.gameObject.SetActive(false);
            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);
            backAndGuideBtns.SetActive(true);
            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "4/13")
        {
            
            animalTxt.gameObject.SetActive(true);
            animalHighlight.SetActive(true);
            backAndGuideBtns.SetActive(false);
            _realAnimalInfoGO.SetActive(true);
            _realMainAnimalInfo.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);
            videoPlayerGO.gameObject.SetActive(true);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalHighlight.SetActive(false);
            chooseAnimalTxt.gameObject.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);

        }
        else if (pageNumPos1.text == "5/13")
        {
            
            speakerTxt.gameObject.SetActive(true);
            speakerHighlight.SetActive(true);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);

        }
        else if (pageNumPos1.text == "6/13")
        {
            
            vidTxt.gameObject.SetActive(true);
            vidHighlight.SetActive(true);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "7/13")
        {
           
            playVidTxt.gameObject.SetActive(true);
            playVidHighlight.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "8/13")
        {
            
            fullScreenVidTxt.gameObject.SetActive(true);
            fullScreenVidHighlight.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);

        }
        else if (pageNumPos1.text == "9/13")
        {
            
            informationTxt.gameObject.SetActive(true);
            informationHighlight.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "10/13")
        {
            
            settingsTxt.gameObject.SetActive(true);
            settingsHighlight.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);

        }
        else if (pageNumPos1.text == "11/13")
        {
            
            backAnimalInfoSelectTxt.gameObject.SetActive(true);
            backAnimalInfoSelectHighlight.SetActive(true);

            _realMainAnimalInfo.SetActive(false);
            _realAnimalInfoGO.SetActive(true);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(true);

            videoPlayerGO.gameObject.SetActive(true);
            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);
            backAndGuideBtns.SetActive(false);
            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "12/13")
        {
            
            backMainMenuTxt.gameObject.SetActive(true);
            backMainMenuHighlight.SetActive(true);
            backAndGuideBtns.SetActive(true);
            _realMainAnimalInfo.SetActive(true);
            _realAnimalInfoGO.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);
            videoPlayerGO.gameObject.SetActive(false);
            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.SetActive(false);
        }
        else if (pageNumPos1.text == "13/13")
        {
            
            guideTxt.gameObject.SetActive(true);
            guideHighlight.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);
            categorizeTxt.gameObject.SetActive(false);
            categorizeHighlight.SetActive(false);

            chooseAnimalTxt.gameObject.SetActive(false);
            chooseAnimalHighlight.SetActive(false);

            animalTxt.gameObject.SetActive(false);
            animalHighlight.SetActive(false);

            speakerTxt.gameObject.SetActive(false);
            speakerHighlight.SetActive(false);

            vidTxt.gameObject.SetActive(false);
            vidHighlight.SetActive(false);

            playVidTxt.gameObject.SetActive(false);
            playVidHighlight.SetActive(false);

            fullScreenVidTxt.gameObject.SetActive(false);
            fullScreenVidHighlight.SetActive(false);

            informationTxt.gameObject.SetActive(false);
            informationHighlight.SetActive(false);

            settingsTxt.gameObject.SetActive(false);
            settingsHighlight.SetActive(false);

            backAnimalInfoSelectTxt.gameObject.SetActive(false);
            backAnimalInfoSelectHighlight.SetActive(false);

            backMainMenuTxt.gameObject.SetActive(false);
            backMainMenuHighlight.SetActive(false);


        }


    }
}
