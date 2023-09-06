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

    private string guideChosen;

    [SerializeField] private Image guide;

    [SerializeField] private Image dialogBox;

    [SerializeField] private TextMeshProUGUI dialogText;

    [SerializeField] private GameObject tutorial;

    [SerializeField] private Sprite[] spriteForGuide;
    [SerializeField] private TextMeshProUGUI pageNumTxt;
    [SerializeField] private Sprite[] spriteForDialogBox;

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

        PlayerPrefs.SetInt("IsTutorialDone", 0);

        bool isTutorialDone = PlayerPrefs.GetInt("IsTutorialDone", 0) == 1;
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

    private void checkGuide() 
    {
        guideChosen = StateNameController.guide_chosen;

        if(string.IsNullOrEmpty(guideChosen)) 
        {
            guideChosen = "boy_guide";
        }

        if (guideChosen == "boy_guide") 
        {
            guide.sprite = spriteForGuide[0];
            dialogBox.sprite = spriteForDialogBox[0];
            guide_name = "Lorem";
        }
        else if (guideChosen == "girl_guide") 
        {
            guide.sprite = spriteForGuide[1];
            dialogBox.sprite = spriteForDialogBox[1];
            guide_name = "Ipsum";
        }
    }

    public void backBtnFunction() 
    {
        hideAllComponents();
        
        if (pageNum > 1)
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

        if (PlayerPrefs.GetInt("IsTutorialDone", 0) == 0) {
            gameResumeTimerManager.SetActive(false);
        }
        else {
            gameResumeTimerManager.SetActive(true);
        }

        if (gameStartManager.GetGameStarted() == true) 
        {
            startGamePanel.SetActive(false);
        }

        PlayerPrefs.SetInt("IsTutorialDone", 1);
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

            if (PlayerPrefs.GetInt("IsTutorialDone", 0) == 0) {
            gameResumeTimerManager.SetActive(false);
            }
            else {
                gameResumeTimerManager.SetActive(true);
            }

            if (gameStartManager.GetGameStarted() == true) 
            {
                startGamePanel.SetActive(false);
            }

            PlayerPrefs.SetInt("IsTutorialDone", 1);
        }

        if (pageNum > 1) 
        {
            backButton.SetActive(true);
        }
        pageNumTxt.text = pageNum.ToString() + "/7";
    }

    public void pagesContents() 
    {
        if(pageNum == 0) 
        {
            hideAllComponents();
            pageNumTxt.text = "";
            dialogText.fontSize = 41.8f;
            dialogText.text = "Hello there! I'm <color=yellow>" + guide_name + "</color>, your trusty guide who will help you learn and navigate this game. Get ready for an exciting learning experience!";
            
            tutorial.transform.localPosition = (new Vector3(50.49997f, -160.5615f, 0f));

            dialogBox.transform.localPosition = new Vector3(-238.421f, 199f, 0f);
            dialogBox.transform.localScale = new Vector3(1f, 1.4f, 1f);

            dialogText.transform.localPosition = new Vector3(-248.31f, 235f, 0f);
        }
        else if (pageNum == 1) 
        {
            dialogText.fontSize = 39f;
            dialogText.text = "Introducing your <color=yellow>animal character</color>! You can help this special animal move left and right to catch the yummy food falling from above.";

            tutorial.transform.localPosition = (new Vector3(0f, -160.0615f, 0f));

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

            showComponent(helpButton, helpButtonGameObject);
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