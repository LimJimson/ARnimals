using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GTS_Guide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public GameObject GTS_GameGuideGO;
    public GTS_touchToNextGuide gts_touchToNextScript;

    AudioManager audioManager;

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
    public TMP_Text welcome_txt;
    public TMP_Text animal_txt;
    public TMP_Text choices_speakerBtns_txt;
    public TMP_Text speaker_txt;
    public TMP_Text choices_txt;
    public TMP_Text wrongAns_txt;
    public TMP_Text question_txt;
    public TMP_Text hint_txt;
    public TMP_Text settings_txt;
    public TMP_Text guideTxt;

    [Header("Highlights")]
    public GameObject animalHighlight;
    public GameObject speakerHighlight;
    public GameObject choicesHighlight;
    public GameObject wrongAns_Hearts_Highlight;
    public GameObject questionHighlight;
    public GameObject hintHighlight;
    public GameObject settingsHighlight;
    public GameObject guideHighlight;

    public GameObject[] objectsToHide;

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
        guideChosen = loaddata.guideChosen;

    }
    public void checkIfGuideIsDone()
    {
        if (!StateNameController.GTS_GAME_GUIDE)
        {
            GTS_GUIDE();

            StateNameController.GTS_GAME_GUIDE = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        showDialogs();
    }
    public void guideVoiceOver()
    {
        try
        {
            if (gts_touchToNextScript.pageCounter == 1)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[0]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[0]);
                }

            }
            else if (gts_touchToNextScript.pageCounter == 2)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[1]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[1]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 3)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[2]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[2]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 4)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[3]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[3]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 5)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[4]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[4]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 6)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[5]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[5]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 7)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[6]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[6]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 8)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[7]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[7]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 9)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[8]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[8]);
                }
            }
            else if (gts_touchToNextScript.pageCounter == 10)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Patrick[9]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.GTS_Sandy[9]);
                }
            }
        }
        catch
        {

        }

    }
    public void stopGuideVoice()
    {
        try { audioManager.guideSource.Stop(); } catch { }
    }

    public void hideObjects()
    {
        foreach(GameObject go in objectsToHide)
        {
            go.SetActive(false);
        }
    }

    public void showObjects()
    {
        foreach (GameObject go in objectsToHide)
        {
            go.SetActive(true);
        }
    }
    void disableAllGuideGameObjects()
    {

        welcome_txt.gameObject.SetActive(false);

        animal_txt.gameObject.SetActive(false);
        animalHighlight.gameObject.SetActive(false);

        choices_speakerBtns_txt.gameObject.SetActive(false);

        speaker_txt.gameObject.SetActive(false);
        speakerHighlight.gameObject.SetActive(false);

        choices_txt.gameObject.SetActive(false);
        choicesHighlight.gameObject.SetActive(false);

        wrongAns_txt.gameObject.SetActive(false);
        wrongAns_Hearts_Highlight.gameObject.SetActive(false);

        question_txt.gameObject.SetActive(false);
        questionHighlight.gameObject.SetActive(false);

        hint_txt.gameObject.SetActive(false);
        hintHighlight.gameObject.SetActive(false);

        settings_txt.gameObject.SetActive(false);
        settingsHighlight.gameObject.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }
    public GameObject[] placeHolderImages;
    public void showPlaceHolderImg()
    {
        foreach (GameObject placeHolderImage in placeHolderImages)
        {
            placeHolderImage.SetActive(true);
        }
    }
    public void hidePlaceHolderImg()
    {
        foreach (GameObject placeHolderImage in placeHolderImages)
        {
            placeHolderImage.SetActive(false);
        }
    }
    public void GTS_GUIDE()
    {
        GTS_GameGuideGO.gameObject.SetActive(true);
        hideObjects();
        showPlaceHolderImg();

        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);

        pageNumPos1.text = "1/10";
        guideVoiceOver();

        if (guideChosen == "boy_guide")
        {
            _maleGuide();
        }
        else if (guideChosen == "girl_guide")
        {
            _femaleGuide();
        }
    }

    public void skipTutorial()
    {
        pageNumPos1.text = "1/10";
        pageNumPos2.text = "1/10";
        gts_touchToNextScript.setPageCtr(1);
        stopGuideVoice();
        disableAllGuideGameObjects();
        GTS_GameGuideGO.SetActive(false);
        hidePlaceHolderImg();
        showObjects();

        if (!loaddata.GTS_GAME_GUIDE)
        {
            loaddata.GTS_GAME_GUIDE = true;
            SaveManager.Save(loaddata);
        }
    }

    public void GuideBack()
    {
        gts_touchToNextScript.minusPageCtr();
        guideVoiceOver();
        disableAllGuideGameObjects();
        

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

    public void showDialogs()
    {
        if (pageNumPos1.text == "1/10")
        {

            welcome_txt.gameObject.SetActive(true);
            backBtnPos1.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "2/10")
        {

            welcome_txt.gameObject.SetActive(false);
            backBtnPos1.SetActive(true);

            animal_txt.gameObject.SetActive(true);
            animalHighlight.gameObject.SetActive(true);

            choices_speakerBtns_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
        }
        else if (pageNumPos1.text == "3/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(true);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(true);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(true);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
        }
        else if (pageNumPos1.text == "4/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(true);
            speakerHighlight.gameObject.SetActive(true);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "5/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(true);
            choicesHighlight.gameObject.SetActive(true);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "6/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(true);
            wrongAns_Hearts_Highlight.gameObject.SetActive(true);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
            
            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
        }
        else if (pageNumPos1.text == "7/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(true);
            questionHighlight.gameObject.SetActive(true);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
        }
        else if (pageNumPos1.text == "8/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(true);
            hintHighlight.gameObject.SetActive(true);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "9/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(true);
            settingsHighlight.gameObject.SetActive(true);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "10/10")
        {
            welcome_txt.gameObject.SetActive(false);

            animal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            choices_speakerBtns_txt.gameObject.SetActive(false);
            
            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            choices_txt.gameObject.SetActive(false);
            choicesHighlight.gameObject.SetActive(false);

            wrongAns_txt.gameObject.SetActive(false);
            wrongAns_Hearts_Highlight.gameObject.SetActive(false);

            question_txt.gameObject.SetActive(false);
            questionHighlight.gameObject.SetActive(false);

            hint_txt.gameObject.SetActive(false);
            hintHighlight.gameObject.SetActive(false);

            settings_txt.gameObject.SetActive(false);
            settingsHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(true);
            guideHighlight.gameObject.SetActive(true);
        }

    }
}
