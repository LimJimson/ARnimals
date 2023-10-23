using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Linq;
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
    [SerializeField] private FadeSceneTransitions fadeSceneTransitions;

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
    [SerializeField] private TextMeshProUGUI highScoreLvlTxt;
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private TextMeshProUGUI playAgainTxt;
    [SerializeField] private GameObject checkImgForLvlToUnlock;
    [SerializeField] private GameObject allLevelsUnlockGO;
    [SerializeField] private GameObject starsToUnlockGO;
    [SerializeField] private Image lvlToUnlockImg;
    [SerializeField] private Sprite[] lvlToUnlockSprites;

    private int minimumScoreToWin = 10;

    [Header("PowerUps")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject points2X;
    [SerializeField] private GameObject luck;
    [SerializeField] private GameObject shieldContainer;
    [SerializeField] private GameObject points2XContainer;
    [SerializeField] private GameObject luckContainer;
    [SerializeField] private TextMeshProUGUI shieldDurationTxt;
    [SerializeField] private TextMeshProUGUI points2XDurationTxt;
    [SerializeField] private TextMeshProUGUI luckDurationTxt;
    [SerializeField] private GameObject [] animalShieldState;
    [SerializeField] private GameObject [] animalX2State;
    [SerializeField] private GameObject [] animalLuckState;
    [SerializeField] private Image [] animalIdleState;
    [SerializeField] private Image starHolder;
    [SerializeField] private Image previousStarImg;
    [SerializeField] private Sprite[] stars;
    [SerializeField] private TextMeshProUGUI levelCompletedTxt;
	
    private int finalScore;

    private int starsCount;
    
    private bool isGameOver = false;

    [SerializeField] private string selectedLevel;

    [SerializeField] private bool inX2PointsState = false;
    [SerializeField] private bool inShieldState = false;
    [SerializeField] private bool inLuckState = false;

    private float shieldDuration = 10f;
    private float points2XDuration = 10f;
    private float luckDuration = 10f;
	
	[Header("Try Animal")]
	[SerializeField] private TextMeshProUGUI animalToUnlockName;
	[SerializeField] private GameObject tryAnimalBtn;
	[SerializeField] private GameObject confirmationToAR;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject checkGameObject;

    [SerializeField] private TextMeshProUGUI triviaTxt;
    [SerializeField] private Sprite[] powerUpSprites;

    private int ARanimalIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() 
    {
		existingSo = SaveManager.Load();
        selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");

        showRandomTrivia();
		UpdateHighScoreList();
    }

    private void Update() 
    {
        ShieldDurationTimer();
        X2PointsDurationTimer();
        LuckDurationTimer();
        enablePowerUpState();
        removePowerUpState();
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

    public float LuckDuration 
    {
        get { return luckDuration; }
        set { luckDuration = value; }
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

    public bool InLuckState
    {
        get { return inLuckState; }
        set { inLuckState = value; }
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

    public IEnumerator DisableLuckAfterdelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        InLuckState = false;
        luck.SetActive(true);
    }
    private void ShieldDurationTimer() 
    {
        if (InShieldState) 
        {
            shieldContainer.SetActive(true);
            shieldDuration -= Time.deltaTime;

            if (!inLuckState && !inX2PointsState) 
            {
                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[0];
                    idleState.gameObject.SetActive(true);
                }
            }
            else 
            {
                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[0];
                    idleState.gameObject.SetActive(false);
                }
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

            if (!inLuckState && !inShieldState) 
            {

                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[1];
                    idleState.gameObject.SetActive(true);
                }
            }
            else 
            {
                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[1];
                    idleState.gameObject.SetActive(false);
                }
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

    private void LuckDurationTimer() 
    {
        if (InLuckState) 
        {	
            luckContainer.SetActive(true);
            luckDuration -= Time.deltaTime;

            if (!inShieldState && !inX2PointsState) 
            {
                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[2];
                    idleState.gameObject.SetActive(true);
                }
            }
            else 
            {
                foreach (var idleState in animalIdleState) 
                {
                    idleState.sprite = powerUpSprites[2];
                    idleState.gameObject.SetActive(false);
                }
            }

            if (luckDuration <= 0) 
            {
                luckContainer.SetActive(false);

                for(int i = 0; i < animalLuckState.Length ; i++) 
                {
                    animalLuckState[i].SetActive(false);
                }
            }
            else 
            {
                luckDurationTxt.text = luckDuration.ToString("F0");
            }
        }
        else 
        {
            luckContainer.SetActive(false);

            for(int i = 0; i < animalLuckState.Length ; i++) 
            {
                animalLuckState[i].SetActive(false);
            }
        }
    }

    private void enablePowerUpState() 
    {

        if (inShieldState && inX2PointsState) 
        {
            if (shieldDuration < points2XDuration) 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(true);
                    animalX2State[i].SetActive(true);
                    animalShieldState[i].transform.SetAsFirstSibling();
                    animalX2State[i].transform.SetAsLastSibling();
                }
            }
            else 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(true);
                    animalX2State[i].SetActive(true);
                    animalX2State[i].transform.SetAsFirstSibling();
                    animalShieldState[i].transform.SetAsLastSibling();
                }
            }
        }
        else if (inShieldState && inLuckState) 
        {
            if (shieldDuration < luckDuration) 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalShieldState[i].transform.SetAsLastSibling();
                    animalLuckState[i].transform.SetAsLastSibling();
                }
            }
            else 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalShieldState[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalLuckState[i].transform.SetAsFirstSibling();
                    animalShieldState[i].transform.SetAsLastSibling();
                }
            }
        }
        else if (inLuckState && inX2PointsState) 
        {
            if (luckDuration < points2XDuration) 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalX2State[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalLuckState[i].transform.SetSiblingIndex(0);
                    animalX2State[i].transform.SetSiblingIndex(1);
                }
            }
            else 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalX2State[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalX2State[i].transform.SetSiblingIndex(0);
                    animalLuckState[i].transform.SetSiblingIndex(1);
                }
            }
        }
        else if (inLuckState && inX2PointsState && inShieldState) 
        {

            float highest = Mathf.Max(luckDuration, Mathf.Max(shieldDuration, points2XDuration));

            if (highest == luckDuration) 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalX2State[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalShieldState[i].SetActive(true);
                    animalLuckState[i].transform.SetAsFirstSibling();
                    animalShieldState[i].transform.SetAsLastSibling();
                    animalX2State[i].transform.SetAsLastSibling();
                }
            }
            else if (highest == shieldDuration)
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalX2State[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalShieldState[i].SetActive(true);
                    animalShieldState[i].transform.SetAsFirstSibling();
                    animalX2State[i].transform.SetAsLastSibling();
                    animalLuckState[i].transform.SetAsLastSibling();
                }
            }
            else if (highest == points2XDuration) 
            {
                for(int i = 0; i < animalShieldState.Length ; i++) 
                {
                    animalX2State[i].SetActive(true);
                    animalLuckState[i].SetActive(true);
                    animalShieldState[i].SetActive(true);
                    animalX2State[i].transform.SetAsFirstSibling();
                    animalLuckState[i].transform.SetAsLastSibling();
                    animalShieldState[i].transform.SetAsLastSibling();
                }
            }
        }
    }
    private void removePowerUpState() 
    {
        if (!inLuckState && !inShieldState && !inX2PointsState) 
        {
            foreach (var idleState in animalIdleState) 
            {
                idleState.gameObject.SetActive(false);
            }
        }
    }

    private void UnlockedNextLevel() 
    {
        PlayerPrefs.SetInt("CTF_Lvl" + selectedLevel, 1);

        if (selectedLevel == "5") 
        {
            nextLevelBtn.gameObject.SetActive(false);
        }
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
            "<color=green>Did you know?</color> <color=yellow>Pigeons</color> have <color=#F86768>'super'</color> vision. They see ultraviolet light, which we can't, helping them navigate and spot hidden things.",
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

        highScoreLvlTxt.text = "Level " + selectedLevel;

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
                    if (highScores[i].score >= 100) 
                    {
                        formattedScores += $"{rank}.    {highScores[i].score}    -     {highScores[i].dateAchieved}\n";
                    }
                    else 
                    {
                        formattedScores += $"{rank}.    {highScores[i].score}     -     {highScores[i].dateAchieved}\n";
                    } 
                }
                else 
                {
                    if (highScores[i].score >= 100) 
                    {
                        formattedScores += $"{rank}.     {highScores[i].score}    -     {highScores[i].dateAchieved}\n";
                    }
                    else 
                    {
                        formattedScores += $"{rank}.     {highScores[i].score}     -     {highScores[i].dateAchieved}\n";
                    }
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

        //Set previous star 

        switch(currentMaxStarsCount) 
        {
            case 0:
                previousStarImg.sprite = stars[0];
                break;
            case 1:
                previousStarImg.sprite = stars[1];
                break;
            case 2:
                previousStarImg.sprite = stars[2];
                break;
            case 3:
                previousStarImg.sprite = stars[3];
                break;
        }

        int newStarsCount = starsCount;

        if (newStarsCount > currentMaxStarsCount) 
        {
            PlayerPrefs.SetInt("CTF_Lvl" + selectedLevel + "StarsCount", newStarsCount);
        }

        unlockRewards();
    }

    private void unlockRewards() 
    {
        checkGameObject.SetActive(false);
		tryAnimalBtn.SetActive(false);

        checkImgForLvlToUnlock.SetActive(false);
        allLevelsUnlockGO.SetActive(false);
        starsToUnlockGO.SetActive(false);

        switch(PlayerPrefs.GetInt("CTF_Lvl" + selectedLevel + "StarsCount", 0)) 
        {
            case 1:
                playAgainTxt.text = "Do you want to keep playing in order to unlock the <color=yellow>next level</color> and the animal for <color=yellow>AR</color>?";
                nextLevelBtn.interactable = false;
                starsToUnlockGO.SetActive(true);
                checkImgForLvlToUnlock.SetActive(false);
                break;
            case 2:
                playAgainTxt.text = "Are you sure you want to <color=yellow>RE-PLAY</color> this level again instead of going to the <color=yellow>next level</color>?";
                UnlockedNextLevel();
                nextLevelBtn.interactable = true;
                starsToUnlockGO.SetActive(true);
                checkImgForLvlToUnlock.SetActive(true);
                break;
            case 3:
                playAgainTxt.text = "Are you sure you want to <color=yellow>RE-PLAY</color> this level again instead of going to the <color=yellow>next level</color>?";
                UnlockedNextLevel();
                checkGameObject.SetActive(true);
                tryAnimalBtn.SetActive(true);
                starsToUnlockGO.SetActive(true);
                checkImgForLvlToUnlock.SetActive(true);

                switch(selectedLevel) 
                {
                    case "1":
                        existingSo.isOctopusUnlock = true;
                        animalToUnlockName.text = "Octopus";
                        ARanimalIndex = 11;
                        break;
                    case "2":
                        existingSo.isDeerUnlock = true;
                        animalToUnlockName.text = "Deer";
                        ARanimalIndex = 5;
                        break;
                    case "3":
                        existingSo.isSeagullUnlock = true;
                        animalToUnlockName.text = "Seagull";
                        ARanimalIndex = 15;
                        break;
                    case "4":
                        existingSo.isSharkUnlock = true;
                        animalToUnlockName.text = "Shark";
                        ARanimalIndex = 16;
                        break;
                    case "5":
                        existingSo.isDuckUnlock = true;
                        animalToUnlockName.text = "Duck";
                        ARanimalIndex = 6;
                        playAgainTxt.text = "Are you sure you want to <color=yellow>RE-PLAY</color> this level again? There will be no rewards from now on";
                        break;
                }

                break;
        }

        switch(selectedLevel) 
        {
            case "1":
                lvlToUnlockImg.sprite = lvlToUnlockSprites[0];
                break;
            case "2":
                lvlToUnlockImg.sprite = lvlToUnlockSprites[1];
                break;
            case "3":
                lvlToUnlockImg.sprite = lvlToUnlockSprites[2];
                break;
            case "4":
                lvlToUnlockImg.sprite = lvlToUnlockSprites[3];
                break;
            case "5":
                allLevelsUnlockGO.SetActive(true);
                starsToUnlockGO.SetActive(false);
                lvlToUnlockImg.gameObject.SetActive(false);
                checkImgForLvlToUnlock.SetActive(false);
                break;
        }

        animalImg.sprite = animalSprites[int.Parse(selectedLevel)];
    }

    public void addStar(int score) 
    {
        if (score >= 10 && score < 20) 
        {
            starHolder.sprite = stars[1];
            starsCount = 1;
        }
        else if (score >= 20 && score < 30) 
        {
            starHolder.sprite = stars[2];
            starsCount = 2;
        }
        else if (score >= 30) 
        {
            starHolder.sprite = stars[3];
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
        confirmationQuitCanvas.SetActive(false);
        audioManager.stopBGMusic();
        StartCoroutine(fadeSceneTransitions.FadeOut("CTF_LevelSelector"));
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
                break;
            case "2":
                PlayerPrefs.SetString("CTF_SelectedLevel", "3");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Koi");
                break;
            case "3":
                PlayerPrefs.SetString("CTF_SelectedLevel", "4");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Camel");
                break;
            case "4":
                PlayerPrefs.SetString("CTF_SelectedLevel", "5");
                PlayerPrefs.SetString("CTF_SelectedAnimal", "Crab");
                break;
            case "5":
                ConfirmQuit();
                break;
        }
        audioManager.stopBGMusic();
        StartCoroutine(fadeSceneTransitions.FadeOut("CTF_Game"));
    }

    public void ConfirmPlayAgain() 
    {
        confirmationRetryCanvas.SetActive(false);
        confirmationPlayAgainCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
        audioManager.stopBGMusic();
        StartCoroutine(fadeSceneTransitions.FadeOut("CTF_Game"));
    }

    public void ConfirmQuit() 
    {
        confirmationQuitCanvas.SetActive(false);
        confirmationPlayAgainCanvas.SetActive(false);
        levelCompleteCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
        audioManager.stopBGMusic();
        StartCoroutine(fadeSceneTransitions.FadeOut("CTF_LevelSelector"));
    }
	
	public void ConfirmationPlayAgainNo() 
	{
		confirmationPlayAgainCanvas.SetActive(false);
		levelCompleteCanvas.SetActive(true);
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
        StateNameController.tryAnimalAnimalIndex = ARanimalIndex;
        StateNameController.isTryAnimalARClicked = true;
        audioManager.stopBGMusic();
		StartCoroutine(fadeSceneTransitions.FadeOut("Animal Selector AR"));
	}
	
	public void ConfirmationToARNo() 
	{
		confirmationToAR.SetActive(false);
	}
}