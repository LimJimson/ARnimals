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
    public GameObject ConfirmGuideChange;
    public GameObject ConfirmResetGame;
    public GameObject ConfirmQuit;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        MainMenu.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        MainMenuGuide.gameObject.SetActive(false);
        ConfirmGuideChange.gameObject.SetActive(false);
        ConfirmResetGame.gameObject.SetActive(false);
        ConfirmQuit.SetActive(false);
    }

// Button Scripts
    
    public void openChangeGuideConfirmationWindow()
    {
        ConfirmGuideChange.SetActive(true);
    }
    public void closeChangeGuideConfirmationWindow()
    {
        ConfirmGuideChange.SetActive(false);
    }
    public void openResetGameConfirmationWindow()
    {
        ConfirmResetGame.SetActive(true);
    }
    public void closeResetGameConfirmationWindow()
    {
        ConfirmResetGame.SetActive(false);
    }
    public void ResetGameClickedYes()
    {
        PlayerPrefs.SetInt("CTF_IsTutorialDone", 0);
        PlayerPrefs.SetInt("CTF_Lvl1", 0);
        PlayerPrefs.SetInt("CTF_Lvl2", 0);
        PlayerPrefs.SetInt("CTF_Lvl3", 0);
        PlayerPrefs.SetInt("CTF_Lvl4", 0);
        PlayerPrefs.SetInt("CTF_Lvl5", 0);
        SaveManager.DeleteFile();
    }
    
    public void goToGuideSelect()
    {
        SceneManager.LoadScene("GuideSelector");
    }
    public void goToModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void goToAnimalSelectionScene()
    {
        
        SceneManager.LoadScene("Animal Information");
    }
    
    public void goToSettingsMenu()
    {
        Settings.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);

    }

    public void closeApplication()
    {
        Application.Quit();
        Debug.Log("Application Quit!");
    }
    public void goToMainMenu()
    {
        Settings.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    public void showQuitConfirm()
    {
        ConfirmQuit.gameObject.SetActive(true);
    }
    public void hideQuitConfirm()
    {
        ConfirmQuit.gameObject.SetActive(false);
    }




}
