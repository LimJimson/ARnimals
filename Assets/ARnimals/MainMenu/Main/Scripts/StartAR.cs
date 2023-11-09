using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartAR : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas Settings;
    public Canvas MainMenuGuide;

    SaveObject loaddata;

    string guide_chosen;

    public TMP_Text playerName;
    AudioManager audioManager;
    [SerializeField] private FadeSceneTransitions fadeScene;

    public MainMenuSettingsGuide mainMenuSettingsGuideScript;
    bool isGuideFinished;

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
        guide_chosen = loaddata.guideChosen;
        if (string.IsNullOrEmpty(guide_chosen))
        {
            guide_chosen = "boy_guide";
        }

        playerName.text = "Hi, <color=#FFCD06>" + StateNameController.player_name+"</color>!" ;
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
		StartCoroutine(fadeScene.FadeOut("ModeSelect"));
    }

    public void goToAnimalSelectionScene()
    {
		StartCoroutine(fadeScene.FadeOut("Animal_Information"));
    }

    public void goToSettingsMenu()
    {
        
        StartCoroutine(waitForTransition(fadeScene.FadeOut(MainMenu.gameObject, Settings.gameObject), fadeScene.FadeIn()));
        mainMenuSettingsGuideScript.settingsGuide();

    }


    public void goToMainMenu()
    {
        StartCoroutine(waitForTransition(fadeScene.FadeOut(Settings.gameObject, MainMenu.gameObject), fadeScene.FadeIn()));
        loaddata.mainMenuSettingsGuide = true;
        SaveManager.Save(loaddata);

    }

    private IEnumerator waitForTransition(IEnumerator first, IEnumerator second) 
    {
        StartCoroutine(first);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(second);
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
        StartCoroutine(fadeScene.FadeOut("GuideSelector"));
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
        try
        {
            audioManager.musicSource.Stop();
        }
        catch
        {

        }
        CTF_Reset.CTF_ResetProgress();
        FTA_ResetBtn.FTA_ResetProgress();
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
        try
        {
            audioManager.musicSource.Stop();
        }
        catch
        {

        }
        loaddata.name = "";
        StateNameController.player_name = "";
        SaveManager.Save(loaddata);
        Invoke("loadTitleScreen",0.7f);
    }
    
    void loadTitleScreen()
    {
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
