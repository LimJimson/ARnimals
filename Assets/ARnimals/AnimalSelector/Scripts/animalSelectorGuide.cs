using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class animalSelectorGuide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public TouchToNextASGuide _TouchToNextASGuideScript;
    public animalSelection _animalSelectionScript;

    public GameObject animalName_txt;
    public GameObject selectAnimal_txt;

    public GameObject animalSelectGuide;
    public GameObject backButton;
    public GameObject animalExampleNoHighlight;
    public GameObject startBtnNoHighlight;

    [Header("GUIDE POSITION 1")]
    public GameObject pos1_GO;
    public GameObject boyGuidePos1;
    public GameObject boyDialogPos1;
    public GameObject girlGuidePos1;
    public GameObject girldialogPos1;
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
    public TMP_Text animalBoxTxt;
    public TMP_Text lockedAnimalsTxt;
    public TMP_Text animalExampleTxt;
    public TMP_Text startTxt;
    public TMP_Text backTxt;
    public TMP_Text guideTxt;

    [Header("Highlights")]
    public GameObject animalsHighlight;
    public GameObject lockedAnimalsHighlight;
    public GameObject animalExampleHighlight;
    public GameObject startHighlight;
    public GameObject backHighlight;
    public GameObject guideHighlight;
    void Start()
    {
        loaddata = SaveManager.Load();
        guideChosen = StateNameController.guide_chosen;
        if (!StateNameController.animalSelectGuide)
        {
            _animalSelectGuide();

            StateNameController.animalSelectGuide = true;
        }
    }

    public void skipTutorial()
    {
        pageNumPos1.text = "1/7";
        pageNumPos2.text = "1/7";
        _TouchToNextASGuideScript.setPageCtr(1);
        disableAllGuideGameObjects();
        animalSelectGuide.SetActive(false);
        if (!loaddata.AnimalSelectTutorialDone)
        {
            loaddata.AnimalSelectTutorialDone = true;
            SaveManager.Save(loaddata);
        }
    }
    public void GuideBack()
    {
        _TouchToNextASGuideScript.minusPageCtr();
        disableAllGuideGameObjects();
    }

    void disableAllGuideGameObjects()
    {


        welcomeTxt.gameObject.SetActive(false);

        animalBoxTxt.gameObject.SetActive(false);
        animalsHighlight.gameObject.SetActive(false);

        lockedAnimalsTxt.gameObject.SetActive(false);
        lockedAnimalsHighlight.gameObject.SetActive(false);

        animalExampleTxt.gameObject.SetActive(false);
        animalExampleHighlight.gameObject.SetActive(false);

        animalExampleNoHighlight.gameObject.SetActive(false);

        startBtnNoHighlight.gameObject.SetActive(false);

        startTxt.gameObject.SetActive(false);
        startHighlight.gameObject.SetActive(false);

        backTxt.gameObject.SetActive(false);
        backHighlight.gameObject.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }

    public void _animalSelectGuide()
    {
        animalSelectGuide.gameObject.SetActive(true);
        animalName_txt.gameObject.SetActive(false);
        selectAnimal_txt.gameObject.SetActive(false);
        animalExampleNoHighlight.gameObject.SetActive(false);
        _animalSelectionScript.resetSelection();

        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);

        pageNumPos1.text = "1/7";

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

    void Update()
    {
        showDialogs();
    }
    void showDialogs()
    {

        if (pageNumPos1.text == "1/7")
        {
            welcomeTxt.gameObject.SetActive(true);
            backButton.SetActive(false);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);



        }
        else if (pageNumPos1.text == "2/7")
        {

            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(true);
            animalsHighlight.gameObject.SetActive(true);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

        }
        else if (pageNumPos1.text == "3/7")
        {


            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(true);
            lockedAnimalsHighlight.gameObject.SetActive(true);

            animalExampleNoHighlight.gameObject.SetActive(false);
            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);



        }
        else if (pageNumPos1.text == "4/7")
        {
            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(true);
            animalExampleHighlight.gameObject.SetActive(true);

            animalExampleNoHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);
            startBtnNoHighlight.gameObject.SetActive(true);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);


        }
        else if (pageNumPos1.text == "5/7")
        {
            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            animalExampleNoHighlight.gameObject.SetActive(true);

            startTxt.gameObject.SetActive(true);
            startHighlight.gameObject.SetActive(true);
            startBtnNoHighlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


        }
        else if (pageNumPos1.text == "6/7")
        {
            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);
            startBtnNoHighlight.gameObject.SetActive(true);

            backTxt.gameObject.SetActive(true);
            backHighlight.gameObject.SetActive(true);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "7/7")
        {
            welcomeTxt.gameObject.SetActive(false);
            backButton.SetActive(true);

            animalBoxTxt.gameObject.SetActive(false);
            animalsHighlight.gameObject.SetActive(false);

            lockedAnimalsTxt.gameObject.SetActive(false);
            lockedAnimalsHighlight.gameObject.SetActive(false);

            animalExampleTxt.gameObject.SetActive(false);
            animalExampleHighlight.gameObject.SetActive(false);

            startTxt.gameObject.SetActive(false);
            startHighlight.gameObject.SetActive(false);
            startBtnNoHighlight.gameObject.SetActive(true);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(true);
            guideHighlight.gameObject.SetActive(true);
        }

    }
}
