using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CTF_TutorialManager : MonoBehaviour
{

    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject pauseAndHpCanvas;

    [SerializeField] private CTF_GameStartManager gameStartManager;

    [Header("Game Objects")]

    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private GameObject timerGameObject;
    [SerializeField] private GameObject helpButtonGameObject;
    [SerializeField] private GameObject animalGameObject;
    [SerializeField] private GameObject pauseButtonGameObject;
    [SerializeField] private GameObject hpGameObject;
    [SerializeField] private GameObject foodsGameObject;
    [SerializeField] private GameObject gameResumeTimerManager;

    [Header("Game Buttons and Components")]
    [SerializeField] private Canvas score;
    [SerializeField] private Canvas timer;
    [SerializeField] private Canvas helpButton;
    [SerializeField] private Canvas animal;
    [SerializeField] private Canvas pauseButton;
    [SerializeField] private Canvas hp;
    [SerializeField] private Canvas foods;

    [Header("TutorialComponents")]
    [SerializeField] private GameObject skipButton;
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
    [SerializeField] private GameObject click2NxtPanelForTrivia;
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
        checkGuide();
        pagesContents();
        disableAllGameObjects();
        backButton.SetActive(false);
        tutorialCanvas.SetActive(true);
        startGamePanel.SetActive(false);
        pauseAndHpCanvas.SetActive(false);
        
        bool isTutorialDone = PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 1;
        if (isTutorialDone) {
            tutorialCanvas.SetActive(false);
            startGamePanel.SetActive(true);
            pauseAndHpCanvas.SetActive(true);
        }
    }

    private void Update() 
    {
        pagesContents();
    }

    private void showGuide(int guideSprite, int dialogBoxSprite, string name, GameObject[] guideForMenus)
    {
        guide.sprite = spriteForGuide[guideSprite];
        dialogBox.sprite = spriteForDialogBox[dialogBoxSprite];
        guide_name = name;
        guideForMenus[0].SetActive(true);
        guideForMenus[1].SetActive(true);
        guideForMenus[2].SetActive(true);
    } 

    private void checkGuide() 
    {
        guideChosen = StateNameController.guide_chosen;

        if(string.IsNullOrEmpty(guideChosen)) 
        {
            guideChosen = "boy_guide";
        }

        boyGuideForMenus[0].SetActive(false);
        boyGuideForMenus[1].SetActive(false);
        boyGuideForMenus[2].SetActive(false);
        girlGuideForMenus[0].SetActive(false);
        girlGuideForMenus[1].SetActive(false);
        girlGuideForMenus[2].SetActive(false);

        if (guideChosen == "boy_guide") 
        {
            showGuide(0, 0, "Lorem", boyGuideForMenus);
        }
        else if (guideChosen == "girl_guide") 
        {
            showGuide(1, 1, "Ipsum", girlGuideForMenus);
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
        if (pageNum == 1) 
        {
            backButton.SetActive(false);
        }

        pageNumTxt.text = pageNum.ToString() + "/7";
    }
    
    public void skipBtnFunction() 
    {
        tutorialCanvas.SetActive(false);
        startGamePanel.SetActive(true);
        pauseAndHpCanvas.SetActive(true);

        if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 0) {
            gameResumeTimerManager.SetActive(false);
        }
        else {
            gameResumeTimerManager.SetActive(true);
        }

        if (gameStartManager.GetGameStarted() == true) 
        {
            startGamePanel.SetActive(false);
        }

        PlayerPrefs.SetInt("CTF_IsTutorialDone", 1);
    }

    public void clickToNext()
    {
        hideAllComponents();

        if (pageNum < 7)
        {
            pageNum++;
            pagesContents();
        }
        else 
        {
            tutorialCanvas.SetActive(false);
            startGamePanel.SetActive(true);
            pauseAndHpCanvas.SetActive(true);

            if (PlayerPrefs.GetInt("CTF_IsTutorialDone", 0) == 0) {
            gameResumeTimerManager.SetActive(false);
            }
            else {
                gameResumeTimerManager.SetActive(true);
            }

            if (gameStartManager.GetGameStarted() == true) 
            {
                startGamePanel.SetActive(false);
            }

            PlayerPrefs.SetInt("CTF_IsTutorialDone", 1);
        }

        if (pageNum > 1) 
        {
            backButton.SetActive(true);
        }
        pageNumTxt.text = pageNum.ToString() + "/7";
    }

    private void tutorialIntro() 
    {
            hideAllComponents();
            pageNumTxt.text = "";
            dialogText.fontSize = 41.8f;
            dialogText.text = "Hello there! I'm <color=yellow>" + guide_name + "</color>, your trusty guide who will help you learn and navigate this game. Get ready for an exciting learning experience!";            
            tutorial.transform.localPosition = (new Vector3(50.49997f, -160.5615f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 199f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 235f, 0f);
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
                click2NxtPanelForTrivia.SetActive(true);
                panelForTrivia.SetActive(true);            
                hideAllComponents();
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
            click2NxtPanelForTrivia.SetActive(false);
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

            showComponent(animal, animalGameObject);

        }
        else if (pageNum == 2) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "Here are the <color=yellow>foods</color> for your animal character! Your job is to <color=green>catch the right foods</color> and <color=red>avoid the wrong ones</color> as they fall down.";

            tutorial.transform.localPosition = (new Vector3(-81f, -272.1f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 228f, 0f);

            showComponent(foods, foodsGameObject);
        }
        else if (pageNum == 3) 
        {
            dialogText.fontSize = 44f;
            dialogText.text = "Here's your <color=yellow>animal's score</color>! Each correct food caught will earn you one point. Aim for a high score!";
            tutorial.transform.localPosition = (new Vector3(576f, -39f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogText.transform.localPosition = new Vector3(-248.31f, 220f, 0f);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 186f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.2f, 1f);

            showComponent(score, scoreGameObject);
        }
        else if (pageNum == 4) 
        {
            dialogText.fontSize = 37f;
            dialogText.text = "Watch out for your <color=yellow>animal's health</color>! If you catch the wrong food, you'll lose a heart. Remember, your animal only has three hearts, so be careful!";

            tutorial.transform.localPosition = (new Vector3(502f, -72f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 200f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 239f, 0f);

            showComponent(hp, hpGameObject);
        }
        else if (pageNum == 5) 
        {
            dialogText.fontSize = 36.5f;
            dialogText.text = "Introducing the <color=yellow>game's timer</color>! You have 60 seconds to catch the falling foods. To earn a reward, aim to score 20 or more without losing all your hearts before time runs out. Good luck!";

            tutorial.transform.localPosition = (new Vector3(371f, -110f, 0f));

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 1);

            dialogBox.transform.localPosition = new Vector3(-238.421f, 207f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.5f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 241f, 0f);

            showComponent(timer, timerGameObject);
        }
        else if (pageNum == 6) 
        {
            dialogText.fontSize = 37f;
            dialogText.text = "Introducing the <color=yellow>settings button</color>! If you want to adjust the volume, restart, or quit the game, simply click on this button. It gives you control over the game settings. Have fun!";

            tutorial.transform.localPosition = (new Vector3(52f, -84f, 0f));

            showClickToNextTxt(click2NextTxtRightGameObject, click2NextTxtRight, 1);
            
            dialogBox.transform.localPosition = new Vector3(-238.421f, 216f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.5f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 260f, 0f);

            showComponent(pauseButton, pauseButtonGameObject);
        }
        else if (pageNum == 7) 
        {
            dialogText.fontSize = 38f;
            dialogText.text = "Introducing the <color=yellow>help button</color>! If you need assistance, simply press this button and I'll be there to help you. Don't hesitate to call me whenever you need assistance.";

            tutorial.transform.localPosition = (new Vector3(573f, -61f, 0f)); 

            showClickToNextTxt(click2NextTxtLeftGameObject, click2NextTxtLeft, 2);

            showComponent(helpButton, helpButtonGameObject);
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
        animal.overrideSorting = false;
        score.overrideSorting = false;
        timer.overrideSorting = false;
        pauseButton.overrideSorting = false;
        hp.overrideSorting = false;
        helpButton.overrideSorting = false;
        foods.overrideSorting = false;
    }

    private void showComponent(Canvas canvas, GameObject gameObject) 
    {
        gameObject.SetActive(true);
        canvas.overrideSorting = true;
        canvas.sortingOrder = 5;
    }

    public void disableAllGameObjects() 
    {
        animalGameObject.SetActive(false);
        scoreGameObject.SetActive(false);
        timerGameObject.SetActive(false);
        pauseButtonGameObject.SetActive(false);
        hpGameObject.SetActive(false);
        helpButtonGameObject.SetActive(false);
        foodsGameObject.SetActive(false);

        backButton.SetActive(false);
    }
}