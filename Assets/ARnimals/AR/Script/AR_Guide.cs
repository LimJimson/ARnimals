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


    [Header("Dialogues")]
    public TMP_Text welcomeTxt;
    public TMP_Text paw_txt;
    public TMP_Text spawnedAnimal_txt;
    public TMP_Text animalPointer_txt;
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


    void Start()
    {
        loaddata = SaveManager.Load();
        guideChosen = StateNameController.guide_chosen;
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

        animalPointer_txt.gameObject.SetActive(false);
        pointerHighlight.gameObject.SetActive(false);

        joystick_txt.gameObject.SetActive(false);
        joystickHighlight.gameObject.SetActive(false);

        narrate_txt.gameObject.SetActive(false);
        narrateHighlight.gameObject.SetActive(false);

        animalDetails_txt.gameObject.SetActive(false);
        animalInfoHighlight.gameObject.SetActive(false);

        animalPointer_txt.gameObject.SetActive(false);
        pointerHighlight.gameObject.SetActive(false);

        backTxt.gameObject.SetActive(false);
        backHighlight.gameObject.SetActive(false);

        guideTxt.gameObject.SetActive(false);
        guideHighlight.gameObject.SetActive(false);

    }
    public void _ARExpGuide()
    {
        ARExpGuideGO.gameObject.SetActive(true);

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




        }
        else if (pageNumPos1.text == "2/6")
        {


        }
        else if (pageNumPos1.text == "3/6")
        {



        }
        else if (pageNumPos1.text == "4/6")
        {

        }
        else if (pageNumPos1.text == "5/6")
        {

        }
        else if (pageNumPos1.text == "6/6")
        {

        }

    }
}
