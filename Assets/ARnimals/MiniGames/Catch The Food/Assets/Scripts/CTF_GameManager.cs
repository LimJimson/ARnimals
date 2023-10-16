using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Linq;
using static SaveObject.CTF_HighScore;
using Unity.VisualScripting;
using System.Collections.Generic;

public class CTF_GameManager : MonoBehaviour
{
    public static CTF_GameManager Instance { get; private set; }

    [Header("Scripts Needed")]

    SaveObject existingSo;

    [SerializeField] private CTF_ScoreManager scoreManager;
    [SerializeField] private CTF_HealthManager healthManager;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private CTF_TutorialManager tutorialManager;
    [SerializeField] private CTF_HighScoreManager highScoreManager;
    [SerializeField] private CTF_AudioManager audioManager;

    [Header("Game Objects Needed")]

    [SerializeField] private GameObject gameResumeTimerManager;
    [SerializeField] private GameObject pauseAndHPCanvas;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject optionsUICanvas;
    [SerializeField] private GameObject confirmationQuitCanvas;
    [SerializeField] private GameObject confirmationRetryCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject confirmationPlayAgainCanvas;
	[SerializeField] private GameObject highScoreCanvas;

    [Header("UIs Needed")]

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreListTxt;
    private int minimumScoreToWin = 10;

    [Header("PowerUps")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject points2X;
    [SerializeField] private GameObject shieldImg;
    [SerializeField] private GameObject points2XImg;
    [SerializeField] private GameObject shieldContainer;
    [SerializeField] private GameObject points2XContainer;
    [SerializeField] private GameObject shieldDurationGameObject;
    [SerializeField] private GameObject points2XDurationGameObject;
    [SerializeField] private TextMeshProUGUI shieldDurationTxt;
    [SerializeField] private TextMeshProUGUI points2XDurationTxt;
    [SerializeField] private GameObject [] animalShieldState;
    [SerializeField] private GameObject [] animalX2State;
    [SerializeField] private Animator [] powerUpFadeAnimator;
    [SerializeField] private Image starHolder;
    [SerializeField] private Sprite[] stars;
    [SerializeField] private TextMeshProUGUI levelCompletedTxt;
    [SerializeField] private RectTransform[] x2Orders;
    [SerializeField] private RectTransform[] shieldsOrders;
	
    private int finalScore;

    private int starsCount;
    
    private bool isGameOver = false;

    [SerializeField] private string selectedLevel;

    [SerializeField] private bool inX2PointsState = false;
    [SerializeField] private bool inShieldState = false;

    private float shieldDuration = 10f;
    private float points2XDuration = 10f;
	
	[Header("Try Animal")]
	[SerializeField] private TextMeshProUGUI animalToUnlockName;
	[SerializeField] private GameObject tryAnimalBtn;
	[SerializeField] private GameObject confirmationToAR;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject checkGameObject;

    [SerializeField] private TextMeshProUGUI triviaTxt;
	[SerializeField] private GameObject transitionToOut;
    [SerializeField] private Image transitionToOutImg;
    [SerializeField] private GameObject transitionToIn;
    [SerializeField] private Image transitionToInImg;
    [SerializeField] private GameObject plainBlackPanel;

    private string buttonCode;
	
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        plainBlackPanel.SetActive(true);
    }

    private void Start() 
    {
		existingSo = SaveManager.Load();
        selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");
        showRandomTrivia();
        StartCoroutine(showTransitionAfterDelay());
		UpdateHighScoreList();
    }

    private void Update() 
    {
        ShieldDurationTimer();
        X2PointsDurationTimer();
        UpdatePowerUpsUI();
        checkIfTransitionIsDone();
    }

    private IEnumerator showTransitionAfterDelay() 
    {
        yield return new WaitForSeconds(0.1f);
        plainBlackPanel.SetActive(false);
        transitionToIn.SetActive(true);
    }

    public float ShieldDuration 
    {
        get { return shieldDuration; }
        set { shieldDuration = value; }
    }

    public float Points2XDuration 
    {
        get { return points2XDuration; }
        set { points2XDuration = value; }
    }

    public bool InShieldState
    {
        get { return inShieldState; } 
        set { inShieldState = value; }
    }

    public bool InX2PointsState 
    {
        get { return inX2PointsState; }
        set { inX2PointsState = value; } 
    }

    public IEnumerator DisableShieldAfterdelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        InShieldState = false;
        shield.SetActive(true);
    }

    public IEnumerator DisableX2PointsAfterdelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        InX2PointsState = false;
        points2X.SetActive(true);
    }

    private void ShieldDurationTimer() 
    {
        if (InShieldState) 
        {
			
			
            shieldContainer.SetActive(true);
            shieldDuration -= Time.deltaTime;

            for(int i = 0; i < animalShieldState.Length ; i++) 
            {
                animalShieldState[i].SetActive(true);
            }

            if (shieldDuration <= 0) 
            {
                shieldContainer.SetActive(false);

                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(false);
                }
            }
            else 
            {
                shieldDurationTxt.text = shieldDuration.ToString("F0");
            }
        }
        else 
        {
            shieldContainer.SetActive(false);

            for(int i = 0; i < animalShieldState.Length ; i++) 
            {
                animalShieldState[i].SetActive(false);
            }
        }
    }

    private void X2PointsDurationTimer() 
    {
        if (InX2PointsState) 
        {
			
			
            points2XContainer.SetActive(true);
            points2XDuration -= Time.deltaTime;

            for(int i = 0; i < animalX2State.Length ; i++) 
            {
                animalX2State[i].SetActive(true);
            }

            if (points2XDuration <= 0) 
            {
                points2XContainer.SetActive(false);

                for(int i = 0; i < animalX2State.Length ; i++) 
                {
                    animalX2State[i].SetActive(false);
                }
            }
            else 
            {
                points2XDurationTxt.text = points2XDuration.ToString("F0");
            }
        }
        else 
        {
            points2XContainer.SetActive(false);

            for(int i = 0; i < animalX2State.Length ; i++) 
            {
                animalX2State[i].SetActive(false);
            }
        }
    }

    private void PowerUpsUIPosition(GameObject firstPowerUp, GameObject firstText, GameObject secondPowerUp, GameObject secondText) 
    {
        Vector3 firstPositionForIcon = new Vector3(-416f, 457f, 0f);
        Vector3 secondPositionForIcon = new Vector3(-246.5f, 458.5f, 0f);

        Vector3 firstPositionForText = new Vector3(-332.3f, 459.1f, 0f);
        Vector3 secondPositionForText = new Vector3(-162.6f, 460.9f, 0f);

        firstPowerUp.transform.localPosition = firstPositionForIcon;
        firstText.transform.localPosition = firstPositionForText;

        secondPowerUp.transform.localPosition = secondPositionForIcon;
        secondText.transform.localPosition = secondPositionForText;
    }

    private void UpdatePowerUpsUI() 
    {

        if (points2XContainer.activeSelf == true && shieldContainer.activeSelf == false) 
        {
            PowerUpsUIPosition(points2XImg, points2XDurationGameObject, shieldImg, shieldDurationGameObject);

        }
        else if (shieldContainer.activeSelf == true && points2XContainer.activeSelf == false) 
        {
            PowerUpsUIPosition(shieldImg, shieldDurationGameObject, points2XImg, points2XDurationGameObject);

        }
        else if (shieldContainer.activeSelf == true && points2XContainer.activeSelf == true) 
        {
            if (shieldDuration < points2XDuration) 
            {
                PowerUpsUIPosition(shieldImg, shieldDurationGameObject, points2XImg, points2XDurationGameObject);

                for (int i = 0; i < powerUpFadeAnimator.Length ; i++) 
                {
                    shieldsOrders[i].SetAsFirstSibling();
                    x2Orders[i].SetAsLastSibling();

                    if (powerUpFadeAnimator[i].isActiveAndEnabled) 
                    {
                        powerUpFadeAnimator[i].SetTrigger("X2FadeFirst");
                    }
                }
            }
            else 
            {
                PowerUpsUIPosition(points2XImg, points2XDurationGameObject, shieldImg, shieldDurationGameObject);

                for (int i = 0; i < powerUpFadeAnimator.Length ; i++) 
                {
                    x2Orders[i].SetAsFirstSibling();
                    shieldsOrders[i].SetAsLastSibling();

                    if (powerUpFadeAnimator[i].isActiveAndEnabled) 
                    {
                        powerUpFadeAnimator[i].SetTrigger("ShieldFadeFirst");
                    }
                }
            }
        }
    }

    private void UnlockedNextLevel() 
    {
        PlayerPrefs.SetInt("CTF_Lvl" + selectedLevel, 1);
    }

    public void IncreaseScore(int amount)
    {
        if (!isGameOver)
        {
            scoreManager.IncreaseScore(amount);
        }
    }
    public void ReduceHealth(int amount)
    {

        if (!isGameOver)
        {
            healthManager.ReduceHealth(amount);

            if (healthManager.GetHealth() <= 0)
            {
                pauseManager.PauseGame();
                gameOverCanvas.SetActive(true);
				audioManager.pauseBGMusic();
				audioManager.playGameOverSFX();
				Debug.Log("Gameover PlayMusic");
            }
        }
    }

    private void showRandomTrivia() 
    {

        string [] elephantTrivia = 
        {
            "<color=green>Did you know?</color> <color=yellow>Elephants</color> are the biggest land animals on Earth. They're even bigger than a school bus!",
            "<color=green>Did you know?</color> <color=yellow>Elephants</color> have a super memory. They can remember things for a very long time, even if they met you years ago.",
            "<color=green>Did you know?</color> <color=yellow>Elephants</color> love taking mud baths. They roll in the mud to cool down and protect their skin from the sun.",
            "<color=green>Did you know?</color> <color=yellow>Baby elephants</color> are called calves. When they're born, they already weigh as much as a small car!",
            "<color=green>Did you know?</color> An <color=yellow>elephant's</color> trunk has about 150,000 muscles, more than a whole human body! It can pick up tiny things and spray water."
        };
        string [] pigeonTrivia = 
        {
            "<color=green>Did you know?</color> <color=yellow>Pigeons</color> can do math! Researchers found that pigeons can learn abstract math rules and even understand concepts like zero.",
            "<color=green>Did you know?</color> <color=yellow>Pigeons</color> have <color=#F86768>'super'</color> vision. They see ultra#FF0046 light, which we can't, helping them navigate and spot hidden things.",
            "<color=green>Did you know?</color> <color=yellow>Pigeons</color> can recognize all 26 letters of the alphabet. They've even learned to tell them apart and spell simple words in studies!",
            "<color=green>Did you know?</color> In some cultures, <color=yellow>pigeons</color> are considered symbols of love and peace. They've even been used in weddings to carry love notes.",
            "<color=green>Did you know?</color> <color=yellow>Pigeons</color> show love with a cute dance called <color=#FF0046>'pigeon courtship'</color> to their feathered friend."
        };
        string [] koiTrivia = 
        {
            "<color=green>Did you know?</color> <color=yellow>Koi fish</color> can live for a very long time, sometimes more than 50 years! That's longer than most pets.",
            "<color=green>Did you know?</color> <color=yellow>Koi fish</color> are like swimming rainbows! They come in lots of colors, including red, orange, yellow, and even sparkly metallic shades.",
            "<color=green>Did you know?</color> <color=yellow>Koi fish</color> are excellent swimmers and can jump out of the water to catch bugs and nibble on leaves.",
            "<color=green>Did you know?</color> <color=yellow>Koi fish</color> are very peaceful and social. They like to swim together in groups, making them wonderful pond companions.",
            "<color=green>Did you know?</color> <color=yellow>Koi fish</color> have a special whisker on their lips called <color=#FF0046>'barbels'</color>. They use them to help sense food in the water."
        };
        string [] camelTrivia = 
        {
            "<color=green>Did you know?</color> <color=yellow>Camels</color> are often called the <color=#FF0046>'ships of the desert'</color> because they're great at carrying heavy loads, just like a ship carries cargo on the sea.",
            "<color=green>Did you know?</color> <color=yellow>Camels</color> have humps, not filled with water, but with fat that provides energy when they can't find food.",
            "<color=green>Did you know?</color> <color=yellow>Camels</color> make funny noises, like grunts and moans, to communicate with each other. It's their way of talking!",
            "<color=green>Did you know?</color> <color=yellow>Camels</color> can close their nostrils during sandstorms to protect themselves from the blowing sand.",
            "<color=green>Did you know?</color> <color=yellow>Camels</color> can go a long time without drinking water. They can survive up to two weeks without a sip!"
        };
        string [] crabTrivia = 
        {
            "<color=green>Did you know?</color> <color=yellow>Crabs</color> have a superpower - they can regenerate lost limbs! If they lose a claw or leg, they can grow it back over time.",
            "<color=green>Did you know?</color> Some <color=yellow>crabs</color> are amazing architects, crafting intricate underwater homes from sand, shells, and more.",
            "<color=green>Did you know?</color> Some <color=yellow>Crabs</color> wear tiny hats! Well, not real hats, but they put small things like shells or sponges on their heads to hide from predators.",
            "<color=green>Did you know?</color> <color=yellow>Crabs</color> are skilled swimmers and masters at sideways walking, which helps them move swiftly and evade danger.",
            "<color=green>Did you know?</color> <color=yellow>Crabs</color> have a special trick called <color=#FF0046>molting</color>. They shed their old shells and grow new, bigger ones when they get too tight."
        };

        int randomIndex = Random.Range(0, 5);


        switch(selectedLevel)
        {   
            case "1":
                triviaTxt.text = elephantTrivia[randomIndex];
                break;
            case "2":
                triviaTxt.text = pigeonTrivia[randomIndex];
                break;
            case "3":
                triviaTxt.text = koiTrivia[randomIndex];
                break;
            case "4":
                triviaTxt.text = camelTrivia[randomIndex];
                break;
            case "5":
                triviaTxt.text = crabTrivia[randomIndex];
                break;
        }
    }

    public void TimeUp()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            if (scoreManager.GetScore() >= minimumScoreToWin)
            {
                pauseManager.PauseGame();
                finalScore = scoreManager.GetScore();
				audioManager.stopBGMusic();
				audioManager.playLvlCompletedSFX();
				Debug.Log("Level Complete PlayMusic");

                addStar(finalScore);
                SetMaxStars();
                UnlockedNextLevel();
                finalScoreText.text = finalScore.ToString();
                highScoreManager.SaveHighScore(scoreManager.GetScore());
                addHighScores(finalScore);
				SaveManager.Save(existingSo);
                levelCompletedTxt.text = "LEVEL <color=yellow><b>"+ selectedLevel +"</b></color> COMPLETED!";
                levelCompleteCanvas.SetActive(true);
            }
            else
            {
                starsCount = 0;
                SetMaxStars();
				audioManager.stopBGMusic();
				audioManager.playGameOverSFX();
                pauseManager.PauseGame();
                gameOverCanvas.SetActive(true);
            }
        }
    }

    public void addHighScores(int score) 
    {

        switch(selectedLevel) 
        {
            case "1":
                existingSo.ctf_HighScoresLvl1.Add(new SaveObject.CTF_HighScore { score = score, dateAchieved = System.DateTime.Now.ToString("MM/dd/yy") });
                existingSo.ctf_HighScoresLvl1.Sort((a, b) => b.score.CompareTo(a.score)); // Sort by descending score
                existingSo.ctf_HighScoresLvl1 = existingSo.ctf_HighScoresLvl1.Take(10).ToList(); // Keep only the top 10 scores
                break;
            case "2":
                existingSo.ctf_HighScoresLvl2.Add(new SaveObject.CTF_HighScore { score = score, dateAchieved = System.DateTime.Now.ToString("MM/dd/yy") });
                existingSo.ctf_HighScoresLvl2.Sort((a, b) => b.score.CompareTo(a.score)); // Sort by descending score
                existingSo.ctf_HighScoresLvl2 = existingSo.ctf_HighScoresLvl2.Take(10).ToList(); // Keep only the top 10 scores
                break;
            case "3":
                existingSo.ctf_HighScoresLvl3.Add(new SaveObject.CTF_HighScore { score = score, dateAchieved = System.DateTime.Now.ToString("MM/dd/yy") });
                existingSo.ctf_HighScoresLvl3.Sort((a, b) => b.score.CompareTo(a.score)); // Sort by descending score
                existingSo.ctf_HighScoresLvl3 = existingSo.ctf_HighScoresLvl3.Take(10).ToList(); // Keep only the top 10 scores
                break;
            case "4":
                existingSo.ctf_HighScoresLvl4.Add(new SaveObject.CTF_HighScore { score = score, dateAchieved = System.DateTime.Now.ToString("MM/dd/yy") });
                existingSo.ctf_HighScoresLvl4.Sort((a, b) => b.score.CompareTo(a.score)); // Sort by descending score
                existingSo.ctf_HighScoresLvl4 = existingSo.ctf_HighScoresLvl4.Take(10).ToList(); // Keep only the top 10 scores
                break;
            case "5":
                existingSo.ctf_HighScoresLvl5.Add(new SaveObject.CTF_HighScore { score = score, dateAchieved = System.DateTime.Now.ToString("MM/dd/yy") });
                existingSo.ctf_HighScoresLvl5.Sort((a, b) => b.score.CompareTo(a.score)); // Sort by descending score
                existingSo.ctf_HighScoresLvl5 = existingSo.ctf_HighScoresLvl5.Take(10).ToList(); // Keep only the top 10 scores
                break;
        }
		SaveManager.Save(existingSo);
        UpdateHighScoreList();
    }

    public void UpdateHighScoreList()
{
    string formattedScores = "";

    List<SaveObject.CTF_HighScore> highScores = null;
    switch (selectedLevel)
    {
        case "1":
            highScores = existingSo.ctf_HighScoresLvl1;
            break;
        case "2":
            highScores = existingSo.ctf_HighScoresLvl2;
            break;
        case "3":
            highScores = existingSo.ctf_HighScoresLvl3;
            break;
        case "4":
            highScores = existingSo.ctf_HighScoresLvl4;
            break;
        case "5":
            highScores = existingSo.ctf_HighScoresLvl5;
            break;
    }

    if (highScores != null)
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            string rank = (i == 9) ? "10" : (i + 1).ToString();

            if (rank == "10") 
            {
                formattedScores += $"{rank}.    {highScores[i].score}     -     {highScores[i].dateAchieved}\n";
            }
            else 
            {
                formattedScores += $"{rank}.     {highScores[i].score}     -     {highScores[i].dateAchieved}\n";
            }
        }
    }

    // Set the formatted scores in the UI Text element
    highScoreListTxt.text = formattedScores;
    Debug.Log("High Score List: " + formattedScores);
}


    private void SetMaxStars() 
    {
        int currentMaxStarsCount = PlayerPrefs.GetInt("CTF_Lvl" + selectedLevel + "StarsCount", 0);
        int newStarsCount = starsCount;

        checkGameObject.SetActive(false);
		tryAnimalBtn.SetActive(false);

        if (newStarsCount > currentMaxStarsCount) 
        {
            PlayerPrefs.SetInt("CTF_Lvl" + selectedLevel + "StarsCount", newStarsCount);
        }

        if (PlayerPrefs.GetInt("CTF_Lvl" + selectedLevel + "StarsCount") >= 2) 
        {
            checkGameObject.SetActive(true);
			tryAnimalBtn.SetActive(true);

            switch(selectedLevel) 
            {
                case "1":
                    existingSo.isOctopusUnlock = true;
					animalToUnlockName.text = "Octopus";
                    break;
                case "2":
                    existingSo.isDeerUnlock = true;
					animalToUnlockName.text = "Deer";
                    break;
                case "3":
                    existingSo.isSeagullUnlock = true;
					animalToUnlockName.text = "Seagull";
                    break;
                case "4":
                    existingSo.isSharkUnlock = true;
					animalToUnlockName.text = "Shark";
                    break;
                case "5":
                    existingSo.isDuckUnlock = true;
					animalToUnlockName.text = "Duck";
                    break;
            }
        }

        animalImg.sprite = animalSprites[int.Parse(selectedLevel)];
    }

    public void addStar(int score) 
    {
        if (score >= 10 && score < 20) 
        {
            starHolder.sprite = stars[0];
            starsCount = 1;
        }
        else if (score >= 20 && score < 30) 
        {
            starHolder.sprite = stars[1];
            starsCount = 2;
        }
        else if (score >= 30) 
        {
            starHolder.sprite = stars[2];
            starsCount = 3;
        }
    }

    //Button's functions
	
	private string confirmQuitCode;

    public void QuitButtonFunction()
    {
		if (optionsUICanvas.activeSelf) 
		{
			optionsUICanvas.SetActive(false);
			confirmQuitCode = "OptionsUI";
		}
		
		if (gameOverCanvas.activeSelf) 
		{
			gameOverCanvas.SetActive(false);
			confirmQuitCode = "GameOverUI";
		}
		
		if (levelCompleteCanvas.activeSelf) 
		{
			levelCompleteCanvas.SetActive(false);
			confirmQuitCode = "LevelCompleteUI";
		}
		
        confirmationQuitCanvas.SetActive(true);
    }

    public void RestartButtonFunction()
    {
        confirmationRetryCanvas.SetActive(true);
        optionsUICanvas.SetActive(false);
    }

    public void CloseOptionsUIButtonFunction()
    {
        optionsUICanvas.SetActive(false);
        gameResumeTimerManager.SetActive(true);
    }

    public void SettingsButtonFunction()
    {
        optionsUICanvas.SetActive(true);
        pauseManager.PauseGame();
    }

    public void confirmQuitYesButtonFunction()
    {
        buttonCode = "quitButton";
        confirmationQuitCanvas.SetActive(false);
        transitionToOut.SetActive(true);
    }

    public void confirmQuitNoButtonFunction()
    {
		switch(confirmQuitCode)
		{
			case "OptionsUI":
                optionsUICanvas.SetActive(true);
                break;
            case "GameOverUI":
                gameOverCanvas.SetActive(true);
                break;
			case "LevelCompleteUI":
				levelCompleteCanvas.SetActive(true);
				break;
		}	
        confirmationQuitCanvas.SetActive(false);
    }

    public void confirmRetryNoButtonFunction()
    {
        confirmationRetryCanvas.SetActive(false);
        optionsUICanvas.SetActive(true);
    }

    public void LevelCompletePlayAgainButtonFunction()
    {
        confirmationPlayAgainCanvas.SetActive(true);
        levelCompleteCanvas.SetActive(false);
    }

    public void LevelCompleteResumeButtonFunction()
    {
        levelCompleteCanvas.SetActive(false);

        switch(selectedLevel)
        {
            case "1":
                PlayerPrefs.SetString("CTF_SelectedLevel", "2");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Pigeon");
                buttonCode = "restartButton";
                transitionToOut.SetActive(true);
                break;
            case "2":
                PlayerPrefs.SetString("CTF_SelectedLevel", "3");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Koi");
                buttonCode = "restartButton";
                transitionToOut.SetActive(true);
                break;
            case "3":
                PlayerPrefs.SetString("CTF_SelectedLevel", "4");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Camel");
                buttonCode = "restartButton";
                transitionToOut.SetActive(true);
                break;
            case "4":
                PlayerPrefs.SetString("CTF_SelectedLevel", "5");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Crab");
                buttonCode = "restartButton";
                transitionToOut.SetActive(true);
                break;
            case "5":
                ConfirmQuit();
                break;
        }
    }

    public void ConfirmPlayAgain() 
    {
        buttonCode = "restartButton";
        confirmationRetryCanvas.SetActive(false);
        confirmationPlayAgainCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
        transitionToOut.SetActive(true);
    }

    public void ConfirmQuit() 
    {
        buttonCode = "quitButton";
        confirmationQuitCanvas.SetActive(false);
        confirmationPlayAgainCanvas.SetActive(false);
        levelCompleteCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
		transitionToOut.SetActive(true);
        
    }
	
	public void ConfirmationPlayAgainNo() 
	{
		confirmationPlayAgainCanvas.SetActive(false);
		levelCompleteCanvas.SetActive(true);
	}

    private void checkIfTransitionIsDone() 
    {

        bool achievedImgPositionOut = transitionToOutImg.color.a >= 0.9999 && transitionToOutImg.color.a <= 1.0001;
        bool achievedImgPositionIn = transitionToInImg.color.a >= -0.0001 && transitionToInImg.color.a <= 0.0001;

        if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "quitButton") 
        {
            quitTo("CTF_LevelSelector");
        }
        else if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "restartButton")
        {
            quitTo("CTF_Game");
        }
		else if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "tryAnimalButton")
        {
            quitTo("Animal Selector AR");
        }

        if (transitionToIn.activeSelf && achievedImgPositionIn) 
        {
            transitionToIn.SetActive(false);
        }
    }
    private void quitTo(string sceneName) 
    {
        audioManager.stopBGMusic();
        pauseManager.ResumeGame();
        SceneManager.LoadScene(sceneName);
    }

    public void helpButtonFunction() 
    {
		audioManager.pauseBGMusic();
        pauseAndHPCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
        int pageNum = tutorialManager.PageNum = 0;
        tutorialManager.PageNumTxt.text = pageNum.ToString() + "/10";
        tutorialManager.pagesContents();
        tutorialManager.disableAllGameObjects();
        pauseManager.PauseGame();
    }
	
	public void highScoreButtonFunction() 
	{
		highScoreCanvas.SetActive(true);
		pauseManager.PauseGame();
	}
	
	public void highScoreXButtonFunction() 
	{
		highScoreCanvas.SetActive(false);
		gameResumeTimerManager.SetActive(true);
	}
	
	public void TryAnimalBtnFunction() 
	{
		confirmationToAR.SetActive(true);
	}
	
	public void ConfirmationToARYes() 
	{
		buttonCode = "tryAnimalButton";
		transitionToOut.SetActive(true);
	}
	
	public void ConfirmationToARNo() 
	{
		confirmationToAR.SetActive(false);
	}
}