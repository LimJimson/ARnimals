using HG.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ScriptHandler : MonoBehaviour
{
    new string name;
    string guideChosen;

    public SaveObject soScript;
    private InputLogic inputLogicScript;

    public Button continueBtn;
    public Button optionsBtn;
    public Button ResetGameBtn;

    private enableInputField enableInputFieldScript;

    public TMP_Text playerNameLoggedIn;
    public Animator animator;

   
    public GameObject nameTxtField;
    public GameObject OptionsCanvas;
   

    public GameObject changeNameBtn;

    AudioManager audioManager;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        inputLogicScript = GetComponent<InputLogic>();
        enableInputFieldScript = GetComponent<enableInputField>();
        optionsBtn.interactable = false;

        //canvas
        resetGameconfirmationWindow.SetActive(false);
        changeNameConfirmWindow.SetActive(false);

        OptionsCanvas.SetActive(false);

        // Load the saved data
        soScript = SaveManager.Load();
        name = soScript.getName();
        guideChosen = soScript.getGuide();

        

        StateNameController.mainMenuGuide =soScript.MainMenuTutorialDone;
        StateNameController.modeSelectGuide =soScript.ModeSelectTutorialDone;
        StateNameController.animalSelectGuide =soScript.AnimalSelectTutorialDone;
        StateNameController.ARExperienceGuide =soScript.ARExpTutorialDone;
        StateNameController.miniGamesSelectGuide = soScript.MiniGamesTutorialDone;
        StateNameController.mainMenuSettingsGuide = soScript.mainMenuSettingsGuide;
        StateNameController.animalInfoGuide = soScript.animalInfoGuide;
        StateNameController.player_name = name;
        StateNameController.guide_chosen = guideChosen;
        StateNameController.GTS_GAME_GUIDE = soScript.GTS_GAME_GUIDE;
        

        if (!string.IsNullOrEmpty(name))
        {

            StartCoroutine(WaitForAnimationFinish());

            ResetGameBtn.gameObject.SetActive(true);
            changeNameBtn.gameObject.SetActive(true);
            // If the name is not null or empty, hide the name text field and show the player name text
            if (string.IsNullOrEmpty(StateNameController.guide_chosen))
            {
                continueBtn.onClick.RemoveAllListeners();
                continueBtn.onClick.AddListener(inputLogicScript.NoGuideSelected);
                
            }
            else
            {
                continueBtn.onClick.RemoveAllListeners();
                continueBtn.onClick.AddListener(inputLogicScript.GoToMainMenu);
            }

            StateNameController.successfullDataFetch = true;
            
            nameTxtField.SetActive(false);
            playerNameLoggedIn.SetText("Currently, playing as: <color=#FFCD06><b><u>\n<size=20>" + name + "</size></u></b></color>");

        }
        else
        {
            // If the name is null or empty, show the name text field and hide the player name text
            if (string.IsNullOrEmpty(StateNameController.guide_chosen))
            {
                continueBtn.onClick.RemoveAllListeners();
                continueBtn.onClick.AddListener(inputLogicScript.continueBtnClickedNoSave);
            }
            else
            {
                continueBtn.onClick.RemoveAllListeners();
                continueBtn.onClick.AddListener(inputLogicScript.continueBtnClickedWithSave);
            }
            
            ResetGameBtn.gameObject.SetActive(false);
            changeNameBtn.gameObject.SetActive(false);
            nameTxtField.SetActive(true);
            playerNameLoggedIn.gameObject.SetActive(false);
        }

    }

    

    // ----- CHANGE NAME -----
    public void changeName()
    {
        soScript.name = "";
        StateNameController.player_name = "";
        SaveManager.Save(soScript);
        Invoke("loadTitleScreen", 0.7f);
    }
    void loadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public GameObject changeNameConfirmWindow;
    public GameObject changeNameGuideMale;
    public GameObject changeNameGuideFemale;
    public void openChangeNameConfirmWindow()
    {
        if (guideChosen == "boy_guide") 
        {
            changeNameGuideMale.SetActive(true);
            changeNameGuideFemale.SetActive(false);
            changeNameConfirmWindow.SetActive(true);
        }
        else if(guideChosen == "girl_guide")
        {
            changeNameGuideFemale.SetActive(true);
            changeNameGuideMale.SetActive(false);
            changeNameConfirmWindow.SetActive(true);
        }
        else if (string.IsNullOrEmpty(guideChosen))
        {
            changeNameGuideMale.SetActive(true);
            changeNameGuideFemale.SetActive(false);
            changeNameConfirmWindow.SetActive(true);
        }

    }
    public void closeChangeNameConfirmWindow()
    {
        changeNameConfirmWindow.SetActive(false);
    }

    // ----- RESET GAME -----
    public GameObject resetGameconfirmationWindow;
    public GameObject resetGameconfirmationGuideMale;
    public GameObject resetGameconfirmationFemale;
    public void openResetGameConfirmationWindow()
    {

        if (guideChosen == "boy_guide")
        {
            resetGameconfirmationGuideMale.SetActive(true);
            resetGameconfirmationFemale.SetActive(false);
            resetGameconfirmationWindow.SetActive(true);
        }
        else if (guideChosen == "girl_guide")
        {
            resetGameconfirmationFemale.SetActive(true);
            resetGameconfirmationGuideMale.SetActive(false);
            resetGameconfirmationWindow.SetActive(true);
        }else if (string.IsNullOrEmpty(guideChosen))
        {
            resetGameconfirmationGuideMale.SetActive(true);
            resetGameconfirmationFemale.SetActive(false);
            resetGameconfirmationWindow.SetActive(true);
        }
    }

    public void closeResetGameConfirmationWindow()
    {
        resetGameconfirmationWindow.SetActive(false);
    }


    public void resetGame()
    {
        SaveManager.DeleteFile();
        CTF_Reset.CTF_ResetProgress();
    }

    //Button Scripts
    public void openSettings()
    {
        OptionsCanvas.SetActive(true);
    }
    public void closeSettings()
    {
        OptionsCanvas.SetActive(false);
    }


    IEnumerator WaitForAnimationFinish()
    {
        playerNameLoggedIn.gameObject.SetActive(true);
        // Wait until the animation is finished
        Debug.Log("WaitForAnimationFinish coroutine called!");

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle_button"))
        {
            yield return null;
        }

        Debug.Log("Animation has finished!");
        
        // Enable the button after the animation is finished
        continueBtn.interactable = true;
        optionsBtn.interactable = true;
    }



}