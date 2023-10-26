using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AR_Guide : MonoBehaviour
{
    SaveObject loaddata;
    string guideChosen;
    public GameObject ARExpGuideGO;
    public ARPlacement ARPlacementScript;
    public touchToNextAR touchToNextARScript;



    public GameObject clickAnywhere1;
    public GameObject clickAnywhere2;

    [Header("GUIDE POSITION 1")]
    public GameObject pos1_GO;
    public GameObject boyGuidePos1;
    public GameObject boyDialogPos1;
    public GameObject girlGuidePos1;
    public GameObject girldialogPos1;
    public TMP_Text pageNumPos1;
    public Button backBtnPOS1;


    [Header("GUIDE POSITION 2")]
    public GameObject pos2_GO;
    public GameObject boyGuidePos2;
    public GameObject boyDialogPos2;
    public GameObject girlGuidePos2;
    public GameObject girldialogPos2;
    public TMP_Text pageNumPos2;

    [Header("GUIDE POSITION 3")]
    public GameObject pos3_GO;
    public GameObject boyGuidePos3;
    public GameObject boyDialogPos3;
    public GameObject girlGuidePos3;
    public GameObject girldialogPos3;
    public TMP_Text pageNumPos3;


    [Header("Dialogues")]
    public TMP_Text welcomeTxt;
    public TMP_Text paw_txt;
    public TMP_Text spawnedAnimal_txt;
    public TMP_Text animalPointer_txt;
    public TMP_Text resizeAnimal_txt;
    public TMP_Text joystick_txt;
    public TMP_Text narrate_txt;
    public TMP_Text animalDetails_txt;
    public TMP_Text spawnAdditional_txt;
    public TMP_Text Habitat_txt;
    public TMP_Text speaker_txt;
    public TMP_Text camera_txt;
    public TMP_Text record_txt;
    public TMP_Text gallery_txt;
    public TMP_Text settings_txt;
    public TMP_Text backTxt;
    public TMP_Text guideTxt;

    [Header("Highlights")]
    public GameObject pawHighlight;
    public GameObject pointerHighlight;
    public GameObject animalHighlight;
    public GameObject resizeAnimalHighlight;
    public GameObject joystickHighlight;
    public GameObject narrateHighlight;
    public GameObject animalInfoHighlight;
    public GameObject spawnAdditionalAnimalHighlight;
    public GameObject habitatHighlight;
    public GameObject speakerHighlight;
    public GameObject cameraHighlight;
    public GameObject recordHighlight;
    public GameObject galleryHighlight;
    public GameObject settingsHighlight;
    public GameObject backHighlight;
    public GameObject guideHighlight;

    public bool isGuideActive;

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
        guideChosen = loaddata.guideChosen;

    }
    public void guideVoiceOver()
    {
        try
        {
            if (touchToNextARScript.pageCounter == 1)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[0]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[0]);
                }

            }
            else if (touchToNextARScript.pageCounter == 2)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[1]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[1]);
                }
            }
            else if (touchToNextARScript.pageCounter == 3)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[2]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[2]);
                }
            }
            else if (touchToNextARScript.pageCounter == 4)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[3]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[3]);
                }
            }
            else if (touchToNextARScript.pageCounter == 5)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[4]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[4]);
                }
            }
            else if (touchToNextARScript.pageCounter == 6)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[5]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[5]);
                }
            }
            else if (touchToNextARScript.pageCounter == 7)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[6]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[6]);
                }
            }
            else if (touchToNextARScript.pageCounter == 8)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[7]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[7]);
                }
            }
            else if (touchToNextARScript.pageCounter == 9)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[8]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[8]);
                }
            }
            else if (touchToNextARScript.pageCounter == 10)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[9]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[9]);
                }
            }
            else if (touchToNextARScript.pageCounter == 11)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[10]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[10]);
                }
            }
            else if (touchToNextARScript.pageCounter == 12)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[11]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[11]);
                }
            }
            else if (touchToNextARScript.pageCounter == 13)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[12]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[12]);
                }
            }
            else if (touchToNextARScript.pageCounter == 14)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[13]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[13]);
                }
            }
            else if (touchToNextARScript.pageCounter == 15)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[14]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[14]);
                }
            }
            else if (touchToNextARScript.pageCounter == 16)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[15]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[15]);
                }
            }
            else if (touchToNextARScript.pageCounter == 17)
            {
                if (guideChosen == "boy_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpPatrick[16]);
                }
                else if (guideChosen == "girl_guide")
                {
                    audioManager.PlayGuide(audioManager.ARExpSandy[16]);
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
    public void skipTutorial()
    {
        pageNumPos1.text = "1/17";
        pageNumPos2.text = "1/17";
        touchToNextARScript.setPageCtr(1);
        stopGuideVoice();
        disableAllGuideGameObjects();
        isGuideActive = false;
        ARExpGuideGO.SetActive(false);

        if (!loaddata.ARExpTutorialDone)
        {
            loaddata.ARExpTutorialDone = true;
            SaveManager.Save(loaddata);
        }
    }

    public void GuideBack()
    {
        touchToNextARScript.minusPageCtr();
        guideVoiceOver();
        if (touchToNextARScript.pageCounter == 2)
        {
            ARPlacementScript.destroyObject();
        }

        disableAllGuideGameObjects();


    }
    public void checkIfGuideIsDone()
    {
        if (!StateNameController.ARExperienceGuide)
        {
            _ARExpGuide();

            StateNameController.ARExperienceGuide = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        showDialogs();
    }

    void disableAllGuideGameObjects()
    {

        welcomeTxt.gameObject.SetActive(false);

        paw_txt.gameObject.SetActive(false);
        pawHighlight.gameObject.SetActive(false);

        spawnedAnimal_txt.gameObject.SetActive(false);
        animalHighlight.gameObject.SetActive(false);

        resizeAnimal_txt.gameObject.SetActive(false);
        resizeAnimalHighlight.gameObject.SetActive(false);

        animalPointer_txt.gameObject.SetActive(false);
        pointerHighlight.gameObject.SetActive(false);

        joystick_txt.gameObject.SetActive(false);
        joystickHighlight.gameObject.SetActive(false);

        narrate_txt.gameObject.SetActive(false);
        narrateHighlight.gameObject.SetActive(false);

        animalDetails_txt.gameObject.SetActive(false);
        animalInfoHighlight.gameObject.SetActive(false);

        spawnAdditional_txt.gameObject.SetActive(false);
        spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

        habitatHighlight.gameObject.SetActive(false);
        Habitat_txt.gameObject.SetActive(false);

        speaker_txt.gameObject.SetActive(false);
        speakerHighlight.gameObject.SetActive(false);

        camera_txt.gameObject.SetActive(false);
        cameraHighlight.gameObject.SetActive(false);

        record_txt.gameObject.SetActive(false);
        recordHighlight.gameObject.SetActive(false);

        galleryHighlight.gameObject.SetActive(false);
        gallery_txt.gameObject.SetActive(false);

        settingsHighlight.gameObject.SetActive(false);
        settings_txt.gameObject.SetActive(false);

        backTxt.gameObject.SetActive(false);
        backHighlight.gameObject.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }
    public void _ARExpGuide()
    {
        ARExpGuideGO.gameObject.SetActive(true);
        isGuideActive = true;

        pos1_GO.SetActive(true);
        pos2_GO.SetActive(false);

        ARPlacementScript.destroyObject();

        pageNumPos1.text = "1/17";
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
    void _maleGuide()
    {
        boyGuidePos1.SetActive(true);
        boyGuidePos2.SetActive(true);
        boyGuidePos3.SetActive(true);

        boyDialogPos1.SetActive(true);
        boyDialogPos2.SetActive(true);
        boyDialogPos3.SetActive(true);
        


        girlGuidePos1.SetActive(false);
        girlGuidePos2.SetActive(false);
        girlGuidePos3.SetActive(false);

        girldialogPos1.SetActive(false);
        girldialogPos2.SetActive(false);
        girldialogPos3.SetActive(false);
        
        

    }
    void _femaleGuide()
    {

        girlGuidePos1.SetActive(true);
        girlGuidePos2.SetActive(true);
        girlGuidePos3.SetActive(true);

        girldialogPos1.SetActive(true);
        girldialogPos2.SetActive(true);
        girldialogPos3.SetActive(true);

        boyGuidePos1.SetActive(false);
        boyGuidePos2.SetActive(false);
        boyGuidePos3.SetActive(false);

        boyDialogPos1.SetActive(false);
        boyDialogPos2.SetActive(false);
        boyDialogPos3.SetActive(false);
    }
    public void showDialogs()
    {

        if (pageNumPos1.text == "1/17")
        {
            welcomeTxt.gameObject.SetActive(true);
            backBtnPOS1.gameObject.SetActive(false);
            clickAnywhere1.SetActive(true);
            clickAnywhere2.SetActive(false);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


        }
        else if (pageNumPos1.text == "2/17")
        {
            backBtnPOS1.gameObject.SetActive(true);
            paw_txt.gameObject.SetActive(true);
            pawHighlight.gameObject.SetActive(true);

            

            clickAnywhere1.SetActive(false);
            clickAnywhere2.SetActive(true);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);


            welcomeTxt.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "3/17")
        {

            spawnedAnimal_txt.gameObject.SetActive(true);
            animalHighlight.gameObject.SetActive(true);
            clickAnywhere1.SetActive(true);
            clickAnywhere2.SetActive(false);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);

        }
        else if (pageNumPos1.text == "4/17")
        {
            animalPointer_txt.gameObject.SetActive(true);
            pointerHighlight.SetActive(true);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(true);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "5/17")
        {

            resizeAnimal_txt.gameObject.SetActive(true);
            resizeAnimalHighlight.gameObject.SetActive(true);

            pos1_GO.SetActive(false);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "6/17")
        {
            joystick_txt.gameObject.SetActive(true);
            joystickHighlight.gameObject.SetActive(true);

            pos1_GO.SetActive(true);
            pos2_GO.SetActive(false);
            pos3_GO.SetActive(false);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "7/17")
        {
            narrate_txt.gameObject.SetActive(true);
            narrateHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);


        }
        else if (pageNumPos1.text == "8/17")
        {
            animalDetails_txt.gameObject.SetActive(true);
            animalInfoHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "9/17")
        {
            spawnAdditional_txt.gameObject.SetActive(true);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "10/17")
        {

            habitatHighlight.gameObject.SetActive(true);
            Habitat_txt.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "11/17")
        {

            speaker_txt.gameObject.SetActive(true);
            speakerHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "12/17")
        {

            camera_txt.gameObject.SetActive(true);
            cameraHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "13/17")
        {

            record_txt.gameObject.SetActive(true);
            recordHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "14/17")
        {
            galleryHighlight.gameObject.SetActive(true);
            gallery_txt.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "15/17")
        {

            settingsHighlight.gameObject.SetActive(true);
            settings_txt.gameObject.SetActive(true);


            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "16/17")
        {


            backTxt.gameObject.SetActive(true);
            backHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);
                
            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            guideTxt.gameObject.SetActive(false);
            guideHighlight.gameObject.SetActive(false);
        }
        else if (pageNumPos1.text == "17/17")
        {
            guideTxt.gameObject.SetActive(true);
            guideHighlight.gameObject.SetActive(true);

            welcomeTxt.gameObject.SetActive(false);

            paw_txt.gameObject.SetActive(false);
            pawHighlight.gameObject.SetActive(false);

            spawnedAnimal_txt.gameObject.SetActive(false);
            animalHighlight.gameObject.SetActive(false);

            resizeAnimal_txt.gameObject.SetActive(false);
            resizeAnimalHighlight.gameObject.SetActive(false);

            animalPointer_txt.gameObject.SetActive(false);
            pointerHighlight.gameObject.SetActive(false);

            joystick_txt.gameObject.SetActive(false);
            joystickHighlight.gameObject.SetActive(false);

            narrate_txt.gameObject.SetActive(false);
            narrateHighlight.gameObject.SetActive(false);

            animalDetails_txt.gameObject.SetActive(false);
            animalInfoHighlight.gameObject.SetActive(false);

            spawnAdditional_txt.gameObject.SetActive(false);
            spawnAdditionalAnimalHighlight.gameObject.SetActive(false);

            habitatHighlight.gameObject.SetActive(false);
            Habitat_txt.gameObject.SetActive(false);

            speaker_txt.gameObject.SetActive(false);
            speakerHighlight.gameObject.SetActive(false);

            camera_txt.gameObject.SetActive(false);
            cameraHighlight.gameObject.SetActive(false);

            record_txt.gameObject.SetActive(false);
            recordHighlight.gameObject.SetActive(false);

            galleryHighlight.gameObject.SetActive(false);
            gallery_txt.gameObject.SetActive(false);

            settingsHighlight.gameObject.SetActive(false);
            settings_txt.gameObject.SetActive(false);

            backTxt.gameObject.SetActive(false);
            backHighlight.gameObject.SetActive(false);


        }

    }
}
