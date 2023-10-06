using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGamesGuide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public GameObject MiniGameSelectGuide;

    public touchToNextMiniGames _TouchToNextMiniGameSelectScript;
    public GameObject backButton;
    public GameObject realBackBtn;
    public GameObject realGuideBtn;

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
    public TMP_Text MG1Txt;
    public TMP_Text MG2Txt;
    public TMP_Text MG3Txt;
    public TMP_Text backTxt;
    public TMP_Text guideTxt;

    [Header("Highlights")]
    public GameObject MG1Highlight;
    public GameObject MG2Highlight;
    public GameObject MG3Highlight;
    public GameObject backHighlight;
    public GameObject guideHighlight;

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
        guideChosen = StateNameController.guide_chosen;
        if (!StateNameController.miniGamesSelectGuide)
        {
            _MiniGameSelectGuide();

            StateNameController.miniGamesSelectGuide = true;
        }
        
    }

    public void skipTutorial()
    {
        pageNumPos1.text = "1/6";
        pageNumPos2.text = "1/6";
        _TouchToNextMiniGameSelectScript.setPageCtr(1);
        disableAllGuideGameObjects();
        MiniGameSelectGuide.SetActive(false);
        realGuideBtn.SetActive(true);

        if (!loaddata.MiniGamesTutorialDone)
        {
            loaddata.MiniGamesTutorialDone = true;
            SaveManager.Save(loaddata);
        }
    }

    public void GuideBack()
    {
        _TouchToNextMiniGameSelectScript.minusPageCtr();
        disableAllGuideGameObjects();
    }

    void disableAllGuideGameObjects()
    {


        welcomeTxt.gameObject.SetActive(false);

        MG1Txt.gameObject.SetActive(false);
        MG1Highlight.gameObject.SetActive(false);

        MG2Txt.gameObject.SetActive(false);
        MG2Highlight.gameObject.SetActive(false);

        MG3Txt.gameObject.SetActive(false);
        MG3Highlight.gameObject.SetActive(false);

        backTxt.gameObject.SetActive(false);
        backHighlight.gameObject.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }

    void Update()
    {
        showDialogs();
    }
    public void _MiniGameSelectGuide()
    {
        MiniGameSelectGuide.gameObject.SetActive(true);

        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);

        pageNumPos1.text = "1/6";

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
        
        if (pageNumPos1.text == "1/6")
        {
            realGuideBtn.SetActive(true);
            welcomeTxt.gameObject.SetActive(true);
            backButton.SetActive(false);

            MG1Txt.gameObject.SetActive(false);
            MG1Highlight.gameObject.SetActive(false);

            MG2Txt.gameObject.SetActive(false);
            MG2Highlight.gameObject.SetActive(false);

            MG3Txt.gameObject.SetActive(false);
            MG3Highlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            

        }
        else if (pageNumPos1.text == "2/6")
        {
            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);


            MG1Txt.gameObject.SetActive(true);
            MG1Highlight.gameObject.SetActive(true);
            backButton.SetActive(true);

            MG2Txt.gameObject.SetActive(false);
            MG2Highlight.gameObject.SetActive(false);

            MG3Txt.gameObject.SetActive(false);
            MG3Highlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

        }
        else if (pageNumPos1.text == "3/6")
        {

            welcomeTxt.gameObject.SetActive(false);


            MG1Txt.gameObject.SetActive(false);
            MG1Highlight.gameObject.SetActive(false);

            MG2Txt.gameObject.SetActive(true);
            MG2Highlight.gameObject.SetActive(true);

            MG3Txt.gameObject.SetActive(false);
            MG3Highlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);


        }
        else if (pageNumPos1.text == "4/6")
        {
            MG1Txt.gameObject.SetActive(false);
            MG1Highlight.gameObject.SetActive(false);

            MG2Txt.gameObject.SetActive(false);
            MG2Highlight.gameObject.SetActive(false);

            MG3Txt.gameObject.SetActive(true);
            MG3Highlight.gameObject.SetActive(true);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
        }
        else if (pageNumPos1.text == "5/6")
        {
            MG1Txt.gameObject.SetActive(false);
            MG1Highlight.gameObject.SetActive(false);

            MG2Txt.gameObject.SetActive(false);
            MG2Highlight.gameObject.SetActive(false);

            MG3Txt.gameObject.SetActive(false);
            MG3Highlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(true);
            backHighlight.gameObject.SetActive(true);
            realBackBtn.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
        }
        else if (pageNumPos1.text == "6/6")
        {
            MG1Txt.gameObject.SetActive(false);
            MG1Highlight.gameObject.SetActive(false);

            MG2Txt.gameObject.SetActive(false);
            MG2Highlight.gameObject.SetActive(false);

            MG3Txt.gameObject.SetActive(false);
            MG3Highlight.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);
            realBackBtn.SetActive(true);

            guideTxt.gameObject.SetActive(true);
            guideHighlight.gameObject.SetActive(true);
            realGuideBtn.SetActive(false);
        }

    }
}
