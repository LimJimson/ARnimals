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
	
	[Header("Fade Transition")]
	[SerializeField] private Image transitionToOutImg;
    [SerializeField] private Image transitionToInImg;
	[SerializeField] private GameObject plainBlackPanel;
	
	private string buttonCode;

    private bool transitionInDone = false;

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
	
	private void Update() 
	{
        if (!transitionInDone) 
        {
            StartCoroutine(showTransitionAfterDelay());
            transitionInDone = true;
        }
		checkIfTransitionIsDone();
	}
	
	private IEnumerator showTransitionAfterDelay() 
	{
		plainBlackPanel.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		plainBlackPanel.SetActive(false);
		transitionToInImg.gameObject.SetActive(true);
	}

	private void checkIfTransitionIsDone() 
    {

        bool achievedImgPositionOut = transitionToOutImg.color.a >= 0.9999 && transitionToOutImg.color.a <= 1.0001;
        bool achievedImgPositionIn = transitionToInImg.color.a >= -0.0001 && transitionToInImg.color.a <= 0.0001;

        if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "Animal_Information") 
        {
            SceneManager.LoadScene("Animal_Information");
        }
		else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "ModeSelect")
		{
			SceneManager.LoadScene("ModeSelect");
		}
        else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "GuideSelector")
		{
			SceneManager.LoadScene("GuideSelector");
		}
        else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "Settings")
		{
            Settings.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
            transitionToOutImg.gameObject.SetActive(false);
            StartCoroutine(showTransitionAfterDelay());
		}
        else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "MainMenu")
		{
            Settings.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
            transitionToOutImg.gameObject.SetActive(false);
            StartCoroutine(showTransitionAfterDelay());
		}

        if (transitionToInImg.gameObject.activeSelf && achievedImgPositionIn) 
        {
            transitionToInImg.gameObject.SetActive(false);
        }
    }

    // Button Scripts
    public void goToModeSelect()
    {
		buttonCode = "ModeSelect";
        transitionToOutImg.gameObject.SetActive(true);
    }

    public void goToAnimalSelectionScene()
    {
		buttonCode = "Animal_Information";
        transitionToOutImg.gameObject.SetActive(true);
    }

    public void goToSettingsMenu()
    {
        mainMenuSettingsGuideScript.settingsGuide();

        buttonCode = "Settings";

        transitionToOutImg.gameObject.SetActive(true);
    }


    public void goToMainMenu()
    {
        buttonCode = "MainMenu";
        transitionToOutImg.gameObject.SetActive(true);
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
        buttonCode = "GuideSelector";
        transitionToOutImg.gameObject.SetActive(true);
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
