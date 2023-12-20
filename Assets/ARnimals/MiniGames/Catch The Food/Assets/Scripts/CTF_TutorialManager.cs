using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CTF_TutorialManager : MonoBehaviour
{

    AudioManager audioManager;
    SaveObject so;

    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject pauseAndHpCanvas;

    [SerializeField] private CTF_GameStartManager gameStartManager;
    [SerializeField] private GameObject gameResumeTimerManager;

    [Header("Game Objects")]

    [SerializeField] private GameObject[] tutorialGameObjects;


    [Header("Game Buttons and Components")]

    [SerializeField] private Canvas[] tutorialGameObjectsCanvas;

    [Header("TutorialComponents")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private TextMeshProUGUI click2NextTxtRight;
    [SerializeField] private TextMeshProUGUI click2NextTxtLeft;
    [SerializeField] private TextMeshProUGUI click2NextTxtBottm;
    [SerializeField] private GameObject click2NextTxtBottomGameObject;
    [SerializeField] private GameObject click2NextTxtRightGameObject;
    [SerializeField] private GameObject click2NextTxtLeftGameObject;

    private string guideChosen;

    [SerializeField] private Image guide;

    [SerializeField] private Image dialogBox;

    [SerializeField] private TextMeshProUGUI dialogText;

    [SerializeField] private GameObject tutorial;

    [SerializeField] private Sprite[] spriteForGuide;
    [SerializeField] private TextMeshProUGUI pageNumTxt;
    [SerializeField] private Sprite[] spriteForDialogBox;

    [Header("Trivias")]
    [SerializeField] private GameObject[] trivias;
    [SerializeField] private GameObject panelForTrivia;

    [SerializeField] private GameObject[] boyGuideForMenus;
    [SerializeField] private GameObject[] girlGuideForMenus;

    [SerializeField] private int pageNum = 0;

    private string guide_name;

    public TextMeshProUGUI PageNumTxt
    {
        get {return pageNumTxt;}
        set {pageNumTxt = value;}
    }

    public int PageNum 
    {
        get {return pageNum;}
        set {pageNum = value;}
    }

    private void Start() 
    {
        so = SaveManager.Load();

        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
			Debug.Log("AudioManager Available");
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

        checkGuide();
        pagesContents();
        disableAllGameObjects();
        backButton.SetActive(false);
        audioManager.playBGMMusic(audioManager.CTF_BGM);
        
        bool isTutorialDone = PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 1;
        if (isTutorialDone) {
            tutorialCanvas.SetActive(false);
            startGamePanel.SetActive(true);
            pauseAndHpCanvas.SetActive(true);
        }
        else 
        {
            tutorialCanvas.SetActive(true);
            startGamePanel.SetActive(false);
            pauseAndHpCanvas.SetActive(false);
            audioManager.musicSource.Pause();
        }
    }

    private void Update() 
    {
        //pagesContents();
    }

    private void showGuide(int guideSprite, int dialogBoxSprite, string name, GameObject[] guideForMenus)
    {
		boyGuideForMenus[0].SetActive(false);
        boyGuideForMenus[1].SetActive(false);
        boyGuideForMenus[2].SetActive(false);
		boyGuideForMenus[3].SetActive(false);
        boyGuideForMenus[4].SetActive(false);
        girlGuideForMenus[0].SetActive(false);
        girlGuideForMenus[1].SetActive(false);
        girlGuideForMenus[2].SetActive(false);
		girlGuideForMenus[3].SetActive(false);
        girlGuideForMenus[4].SetActive(false);
		
        guide.sprite = spriteForGuide[guideSprite];
        dialogBox.sprite = spriteForDialogBox[dialogBoxSprite];
        guide_name = name;
        guideForMenus[0].SetActive(true);
        guideForMenus[1].SetActive(true);
        guideForMenus[2].SetActive(true);
		guideForMenus[3].SetActive(true);
        guideForMenus[4].SetActive(true);
    } 

    private void checkGuide() 
    {
        guideChosen = so.guideChosen;

        if(string.IsNullOrEmpty(guideChosen)) 
        {
            guideChosen = "boy_guide";
        }

        if (guideChosen == "boy_guide") 
        {
            showGuide(0, 0, "Patrick", boyGuideForMenus);
        }
        else if (guideChosen == "girl_guide") 
        {
            showGuide(1, 1, "Sandy", girlGuideForMenus);
        }
    }

    private void playGuideVoiceOver(int currentPage) 
    {
        try{audioManager.guideSource.Stop();} catch{ }

        if (guideChosen == "boy_guide") 
        {
            try{audioManager.PlayGuide(audioManager.CTF_Patrick[currentPage]);} catch{}
        }
        else if (guideChosen == "girl_guide") 
        {
            try{audioManager.PlayGuide(audioManager.CTF_Sandy[currentPage]);} catch{}
        }
    }
	
    public void backBtnFunction() 
    {
        hideAllComponents();
        
        if (pageNum >= 1)
        {
            pageNum--;
            pagesContents();
        }

        pageNumTxt.text = pageNum.ToString() + "/10";
    }
    
    public void skipBtnFunction() 
    {
        tutorialCanvas.SetActive(false);
        startGamePanel.SetActive(true);
        pauseAndHpCanvas.SetActive(true);

        if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 0) {
            gameResumeTimerManager.SetActive(false);
            audioManager.musicSource.UnPause();
        }
        else 
        {
            gameResumeTimerManager.SetActive(true);
        }

        if (gameStartManager.GetGameStarted() == true) 
        {
            startGamePanel.SetActive(false);
        }

        PlayerPrefs.SetInt("CTF_IsTutorialDone", 1);
        try{audioManager.guideSource.Stop();} catch{}
    }

    public void clickToNext()
    {
        hideAllComponents();

        if (pageNum < 10)
        {
            pageNum++;
            pagesContents();
        }
        else 
        {
            tutorialCanvas.SetActive(false);
            startGamePanel.SetActive(true);
            pauseAndHpCanvas.SetActive(true);

            if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 0) 
            {
                gameResumeTimerManager.SetActive(false);
                audioManager.musicSource.UnPause();
            }
            else {
                gameResumeTimerManager.SetActive(true);
            }

            if (gameStartManager.GetGameStarted() == true) 
            {
                startGamePanel.SetActive(false);
            }

            PlayerPrefs.SetInt("CTF_IsTutorialDone", 1);
            try{audioManager.guideSource.Stop();} catch{}
        }

        if (pageNum > 1) 
        {
            backButton.SetActive(true);
        }
        pageNumTxt.text = pageNum.ToString() + "/10";
    }

    private void tutorialIntro() 
    {
            hideAllComponents();
            pageNumTxt.text = "";
            dialogText.fontSize = 45f;
            dialogText.text = "Welcome to <color=yellow>Catch the Food</color>, a fun game where you need to catch the right food for the animals!";            
            tutorial.transform.localPosition = (new Vector3(50.49997f, -160.5615f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 199f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 235f, 0f);
            playGuideVoiceOver(0);
    }

    public void pagesContents() 
    {
        if(pageNum == 0) 
        {
            if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 0) 
            {
                tutorialIntro();
            }
            else 
            {
                tutorial.SetActive(false);
                panelForTrivia.SetActive(true);            
                hideAllComponents();
				try{audioManager.guideSource.Stop();} catch{}
                showClickToNextTxt(click2NextTxtBottomGameObject,click2NextTxtBottm, 1);

                // Retrieve the selected level from PlayerPrefs
                string selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");

                // Change the background based on the selected level
                switch (selectedLevel)
                {
                    case "1":
                        trivias[0].SetActive(true);
                        break;
                    case "2":
                        trivias[1].SetActive(true);
                        break;
                    case "3":
                        trivias[2].SetActive(true);
                        break;
                    case "4":
                        trivias[3].SetActive(true);
                        break;
                    case "5":
                        trivias[4].SetActive(true);
                        break;
                }
            }

            backButton.SetActive(false);
        }
        else if (pageNum == 1) 
        {
            tutorial.SetActive(true);
            trivias[0].SetActive(false);
            trivias[1].SetActive(false);
            trivias[2].SetActive(false);
            trivias[3].SetActive(false);
            trivias[4].SetActive(false);
            panelForTrivia.SetActive(false);

            if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 1) == 1) 
            {
                backButton.SetActive(true);
            }
            else 
            {
                backButton.SetActive(false);
            }

            dialogText.fontSize = 39f;
            dialogText.text = "Introducing your <color=yellow>animal character</color>! You can help this special animal move left and right to catch the yummy food falling from above.";

            tutorial.transform.localPosition = (new Vector3(0f, -160.0615f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 194f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 240f, 0f);

            showComponent(tutorialGameObjectsCanvas[0], tutorialGameObjects[0]);
            playGuideVoiceOver(1);

        }
        else if (pageNum == 2) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "Here are the <color=yellow>foods</color> for your animal character! Your job is to <color=yellow>catch the right foods</color> and <color=red>avoid the wrong ones</color> as they fall down.";

            tutorial.transform.localPosition = (new Vector3(-81f, -272.1f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 228f, 0f);

            showComponent(tutorialGameObjectsCanvas[1], tutorialGameObjects[1]);
            playGuideVoiceOver(2);
        }
        else if (pageNum == 3) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "See the foods with <color=yellow>green borders</color>? That's what the animal loves to munch on! But the ones with <color=red>red borders</color>? Those are no-go";

            tutorial.transform.localPosition = (new Vector3(-81f, -272.1f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 228f, 0f);

            tutorialGameObjects[2].SetActive(false);

            showComponent(tutorialGameObjectsCanvas[1], tutorialGameObjects[1]);
            playGuideVoiceOver(3);
        }
        else if (pageNum == 4) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "Here are the <color=yellow>powerups</color>! They pop up randomly, so try to catch them when you see them. They'll give your animal a big boost!";
            tutorial.transform.localPosition = (new Vector3(-81f, -272.1f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 228f, 0f);

            tutorialGameObjects[1].SetActive(false);

            showComponent(tutorialGameObjectsCanvas[2], tutorialGameObjects[2]);
            playGuideVoiceOver(4);
        }
        else if (pageNum == 5) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "These are the <color=yellow>powerup signs</color>. They show up when you catch a powerup, so you'll know how long the powerup will last.";
            tutorial.transform.localPosition = (new Vector3(-81f, -272.1f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 228f, 0f);

            tutorialGameObjects[2].SetActive(true);

            showComponent(tutorialGameObjectsCanvas[3], tutorialGameObjects[3]);
            playGuideVoiceOver(5);
        }
        else if (pageNum == 6) 
        {
            dialogText.fontSize = 44f;
            dialogText.text = "Here's your <color=yellow>animal's score</color>! Each correct food caught will earn you one point. Aim for a high score!";
            tutorial.transform.localPosition = (new Vector3(576f, -39f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogText.transform.localPosition = new Vector3(-248.31f, 220f, 0f);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            tutorialGameObjects[1].SetActive(false); //Foods
            tutorialGameObjects[2].SetActive(false); //PowerUps
            tutorialGameObjects[3].SetActive(false); //PowerUpSigns

            showComponent(tutorialGameObjectsCanvas[4], tutorialGameObjects[4]);
            playGuideVoiceOver(6);
        }
        else if (pageNum == 7) 
        {
            dialogText.fontSize = 37f;
            dialogText.text = "Watch out for your <color=yellow>animal’s health</color>! If you eat the wrong food, you’ll lose a heart. Remember, your animal only has three hearts, so be careful! ";

            tutorial.transform.localPosition = (new Vector3(502f, -72f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 200f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 239f, 0f);

            showComponent(tutorialGameObjectsCanvas[5], tutorialGameObjects[5]);
            playGuideVoiceOver(7);
        }
        else if (pageNum == 8) 
        {
            dialogText.fontSize = 36.5f;
            dialogText.text = "Introducing the <color=yellow>game’s timer</color>! You have 60 seconds to catch the falling foods. To earn a reward, aim to score 10 or more without losing all your hearts before time runs out. Good luck!";

            tutorial.transform.localPosition = (new Vector3(371f, -110f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 207f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.5f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 241f, 0f);

            showComponent(tutorialGameObjectsCanvas[6], tutorialGameObjects[6]);
            playGuideVoiceOver(8);
        }
        else if (pageNum == 9) 
        {
            dialogText.fontSize = 37f;
            dialogText.text = "Introducing the <color=yellow>settings button</color>. If you want to adjust the volume, restart, or quit the game, simply click on this button. It gives you control over the game settings. Have fun!";

            tutorial.transform.localPosition = (new Vector3(52f, -84f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);
            
            dialogBox.transform.localPosition = new Vector3(-238.421f, 216f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.5f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 260f, 0f);

            showComponent(tutorialGameObjectsCanvas[7], tutorialGameObjects[7]);
            playGuideVoiceOver(9);
        }
        else if (pageNum == 10) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "Introducing the <color=yellow>help button</color>! If you need assistance, simply press this button and I'll be there to help you. Don't hesitate to call me whenever you need assistance.";

            tutorial.transform.localPosition = (new Vector3(573f, -61f, 0f)); 

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 2);

            showComponent(tutorialGameObjectsCanvas[8], tutorialGameObjects[8]);
            playGuideVoiceOver(10);
        }
    }
    private void showClickToNextTxt(GameObject gameObject, TextMeshProUGUI tmpText, int choice) 
    {
        click2NextTxtLeftGameObject.SetActive(false);
        click2NextTxtRightGameObject.SetActive(false);
        click2NextTxtBottomGameObject.SetActive(false);

        gameObject.SetActive(true);

        string clickToNext = "Tap anywhere to go next";
        string clickToClose = "Tap anywhere to close the tutorial";

        if (choice == 1) 
        {
            tmpText.text = clickToNext;
        }
        else if (choice == 2) 
        {
            tmpText.text = clickToClose;
        }
    }

    public void hideAllComponents() 
    {
        for (int i = 0; i < tutorialGameObjectsCanvas.Length; i++) 
        {
            tutorialGameObjectsCanvas[i].overrideSorting = false;
        }
    }

    private void showComponent(Canvas canvas, GameObject gameObject) 
    {
        gameObject.SetActive(true);
        canvas.overrideSorting = true;
        canvas.sortingOrder = 6;
    }

    public void disableAllGameObjects() 
    {
        for (int i = 0; i < tutorialGameObjects.Length; i++) 
        {
            tutorialGameObjects[i].SetActive(false);
        }

        backButton.SetActive(false);
    }
}