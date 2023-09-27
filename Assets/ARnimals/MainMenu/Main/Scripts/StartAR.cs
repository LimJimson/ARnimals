using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAR : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas Settings;
    public Canvas MainMenuGuide;

    SaveObject loaddata;

    string guide_chosen;




    void Start()
    {
        loaddata = SaveManager.Load();
        guide_chosen = StateNameController.guide_chosen;
        if (string.IsNullOrEmpty(guide_chosen))
        {
            guide_chosen = "boy_guide";
        }
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        MainMenu.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        MainMenuGuide.gameObject.SetActive(false);
        ConfirmGuideChange.gameObject.SetActive(false);
        ConfirmResetGame.gameObject.SetActive(false);
        ConfirmQuit.SetActive(false);
    }

    // Button Scripts
    public void goToModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void goToAnimalSelectionScene()
    {

        SceneManager.LoadScene("Animal_Information");
    }

    public void goToSettingsMenu()
    {
        Settings.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);

    }


    public void goToMainMenu()
    {
        Settings.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    // -----CHANGE GUIDE CONFIRMATION -----

    public GameObject changeGuideMale;
    public GameObject changeGuideFemale;
    public GameObject ConfirmGuideChange;
    public void openChangeGuideConfirmationWindow()
    {
        if (guide_chosen == "boy_guide")
        {
            changeGuideMale.SetActive(true);
            changeGuideFemale.SetActive(false);
            ConfirmGuideChange.SetActive(true);
        }
        else if(guide_chosen == "girl_guide")
        {
            changeGuideFemale.SetActive(true);
            changeGuideMale.SetActive(false);
            ConfirmGuideChange.SetActive(true);
        }
        
    }

    public void closeChangeGuideConfirmationWindow()
    {
        ConfirmGuideChange.SetActive(false);
    }

    public void goToGuideSelect()
    {
        SceneManager.LoadScene("GuideSelector");
    }

    // -----RESET GAME CONFIRMATION -----

    public GameObject resetGuideMale;
    public GameObject resetGuideFemale;
    public GameObject ConfirmResetGame;
    public void openResetGameConfirmationWindow()
    {
        
        if (guide_chosen == "boy_guide")
        {
            resetGuideMale.SetActive(true);
            resetGuideFemale.SetActive(false);
            ConfirmResetGame.SetActive(true);
        }
        else if (guide_chosen == "girl_guide")
        {
            resetGuideFemale.SetActive(true);
            resetGuideMale.SetActive(false);
            ConfirmResetGame.SetActive(true);
        }
    }
    public void closeResetGameConfirmationWindow()
    {
        ConfirmResetGame.SetActive(false);
    }
    public void ResetGameClickedYes()
    {
        CTF_Reset.CTF_ResetProgress();
        SaveManager.DeleteFile();
    }

    // -----CHANGE NAME CONFIRMATION -----

    public GameObject changeNameGuideMale;
    public GameObject changeNameGuideFemale;
    public GameObject ConfirmChangeName;

    public void openChangeNameConfirmationWindow()
    {

        if (guide_chosen == "boy_guide")
        {
            changeNameGuideMale.SetActive(true);
            changeNameGuideFemale.SetActive(false);
            ConfirmChangeName.SetActive(true);
        }
        else if (guide_chosen == "girl_guide")
        {
            changeNameGuideFemale.SetActive(true);
            changeNameGuideMale.SetActive(false);
            ConfirmChangeName.SetActive(true);
        }
    }
    public void closeChangeNameConfirmationWindow()
    {
        ConfirmChangeName.SetActive(false);
    }
    public void changeNameClickedYes ()
    {
        loaddata.name = "";
        SaveManager.Save(loaddata);
        SceneManager.LoadScene("TitleScreen");
    }

    // -----QUIT GAME CONFIRMATION -----
    public GameObject quitGuideMale;
    public GameObject quitGuideFemale;
    public GameObject ConfirmQuit;
    public void showQuitConfirm()
    {
        if (guide_chosen == "boy_guide")
        {
            quitGuideMale.SetActive(true);
            quitGuideFemale.SetActive(false);
            ConfirmQuit.gameObject.SetActive(true);
        }
        else if (guide_chosen == "girl_guide")
        {
            quitGuideFemale.SetActive(true);
            quitGuideMale.SetActive(false);
            ConfirmQuit.gameObject.SetActive(true);
        }

    }
    public void hideQuitConfirm()
    {
        ConfirmQuit.gameObject.SetActive(false);
    }

    public void closeApplication()
    {
        Application.Quit();
        Debug.Log("Application Quit!");
    }

}
