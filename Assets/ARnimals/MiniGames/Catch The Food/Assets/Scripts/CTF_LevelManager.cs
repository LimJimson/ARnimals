using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CTF_LevelManager : MonoBehaviour
{

    SaveObject so;

    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;

    [SerializeField] private GameObject [] locks;

    [SerializeField] private Button backBtn;

    [Header("Confirm Play")]

    [SerializeField] private Image starsImg;
    [SerializeField] private Sprite [] starsSprites;
    [SerializeField] private Image levelImg;
    [SerializeField] private Sprite[] levelSprites;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject checkGameObject;
    [SerializeField] private GameObject playConfirmGameObject;

    AudioManager audioManager;
	
	[Header("Try Animal")]
	
	[SerializeField] private TextMeshProUGUI animalToUnlockName;
	[SerializeField] private GameObject confirmationToARCanvas;
	[SerializeField] private Button tryAnimalBtn;
    [SerializeField] private GameObject tryAnimalTxt;
	
    [Header("Unlock Level")]

    [SerializeField] private GameObject checkImgForLvlToUnlock;
    [SerializeField] private GameObject starsToUnlockGO;
    [SerializeField] private GameObject allLevelsUnlockGO;
    [SerializeField] private Image lvlToUnlockImg;
    [SerializeField] private Sprite[] lvlToUnlockSprites;

    private string selectedAnimal;
    private string selectedLevel;

    private string guide_chosen;

    [SerializeField] private GameObject boyGuide;
    [SerializeField] private GameObject girlGuide;

    [SerializeField] private FadeSceneTransitions fadeScene;

    private int ARanimalIndex;
    [SerializeField] private TextMeshProUGUI highScoreListTxt;
    [SerializeField] private TextMeshProUGUI highScoreLvlTxt;
    [SerializeField] private GameObject highScoreCanvas;
    [SerializeField] private GameObject highScoreBtn;

    [SerializeField] private VerticalLayoutGroup buttonsLayout;

    private void Start()
    {		
        so = SaveManager.Load();
		selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel", "1");
		checkIfLevelIsUnlocked();
		checkStar();
		
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
    }

    private void Update() 
    {
        if (!tryAnimalBtn.interactable)
        {
            buttonsLayout.reverseArrangement = true;
        }
        else 
        {
            buttonsLayout.reverseArrangement = false;
        }
    }	
	private void checkIfLevelIsUnlocked() 
	{
		
		 // Assign button click events
        level1Button.onClick.AddListener(OnLevel1ButtonClick);
        backBtn.onClick.AddListener(GoBackToMiniGamesSelection);
		
		if (PlayerPrefs.GetInt("CTF_Lvl1", 0) == 1) 
        {
            locks[0].SetActive(false);
            level2Button.onClick.AddListener(OnLevel2ButtonClick);
            level2Button.interactable = true;
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl2", 0) == 1) 
        {
            locks[1].SetActive(false);
            level3Button.onClick.AddListener(OnLevel3ButtonClick);
            level3Button.interactable = true;
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl3", 0) == 1) 
        {
            locks[2].SetActive(false);
            level4Button.onClick.AddListener(OnLevel4ButtonClick);
            level4Button.interactable = true;
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl4", 0) == 1) 
        {
            locks[3].SetActive(false);
            level5Button.onClick.AddListener(OnLevel5ButtonClick);
            level5Button.interactable = true;
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl5", 0) == 1) 
        {

        }
	}
	
    public void checkStar() 
    { 

        animalImg.sprite = animalSprites[int.Parse(selectedLevel)];

        levelImg.sprite = levelSprites[int.Parse(selectedLevel)];

        int currentStar = PlayerPrefs.GetInt("CTF_Lvl" + selectedLevel + "StarsCount", 0);

        checkGameObject.SetActive(false);
		tryAnimalBtn.interactable = false;
        tryAnimalTxt.SetActive(false);
        checkImgForLvlToUnlock.SetActive(false);
        starsToUnlockGO.SetActive(true);
        lvlToUnlockImg.gameObject.SetActive(true);
        allLevelsUnlockGO.SetActive(false);
        highScoreBtn.SetActive(false);
		
		Debug.Log("Level: " + selectedLevel + "\n" + "currentStar: " + currentStar);
		
		switch(currentStar) 
		{
			case 0:
				starsImg.sprite = starsSprites[0];
				break;
			case 1:
				starsImg.sprite = starsSprites[1];
                highScoreBtn.SetActive(true);
				break;
			case 2:
				starsImg.sprite = starsSprites[2];
                checkImgForLvlToUnlock.SetActive(true);
                highScoreBtn.SetActive(true);
				break;
			case 3:
				starsImg.sprite = starsSprites[3];
                checkImgForLvlToUnlock.SetActive(true);
                highScoreBtn.SetActive(true);
				checkGameObject.SetActive(true);
				tryAnimalBtn.interactable = true;
                tryAnimalTxt.SetActive(true);
				break;
		}
    }

    public void UpdateHighScoreList()
    {
        string formattedScores = "";

        highScoreLvlTxt.text = "Level " + selectedLevel;

        List<SaveObject.CTF_HighScore> highScores = null;
        switch (selectedLevel)
        {
            case "1":
                highScores = so.ctf_HighScoresLvl1;
                break;
            case "2":
                highScores = so.ctf_HighScoresLvl2;
                break;
            case "3":
                highScores = so.ctf_HighScoresLvl3;
                break;
            case "4":
                highScores = so.ctf_HighScoresLvl4;
                break;
            case "5":
                highScores = so.ctf_HighScoresLvl5;
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

    public void OnLevel1ButtonClick()
    {
        selectedAnimal = "Elephant";
        selectedLevel = "1";
        UpdateHighScoreList();
        ARanimalIndex = 11;
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[0];
        animalToUnlockName.text = "Octopus";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel2ButtonClick()
    {
        selectedAnimal = "Pigeon";
        selectedLevel = "2";
        UpdateHighScoreList();
        ARanimalIndex = 5;
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[1];
        animalToUnlockName.text = "Deer";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel3ButtonClick()
    {
        selectedAnimal = "Koi";
        selectedLevel = "3";
        UpdateHighScoreList();
        ARanimalIndex = 15;
        animalToUnlockName.text = "Seagull";
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[2];
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel4ButtonClick()
    {
        selectedAnimal = "Camel";
        selectedLevel = "4";
        UpdateHighScoreList();
        ARanimalIndex = 16;
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[3];
        animalToUnlockName.text = "Shark";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel5ButtonClick()
    {
        selectedAnimal = "Crab";
        selectedLevel = "5";
        UpdateHighScoreList();
        ARanimalIndex = 6;
        checkStar();
        allLevelsUnlockGO.SetActive(true);
        starsToUnlockGO.SetActive(false);
        checkImgForLvlToUnlock.SetActive(false);
        lvlToUnlockImg.gameObject.SetActive(false);
        animalToUnlockName.text = "Duck";
        playConfirmGameObject.SetActive(true);
    }

    public void GoBackToMiniGamesSelection() 
    {
        StartCoroutine(fadeScene.FadeOut("MiniGamesSelect"));
    }

    public void closeButtonFunction() 
    {
        playConfirmGameObject.SetActive(false);
    }

    public void LoadLevel()
    {
		
		try 
		{
			audioManager.musicSource.Stop();
		} 
		catch 
		{
			Debug.Log("No AudioManager");
		}
        // Pass the selected animal name to the next scene
        PlayerPrefs.SetString("CTF_SelectedAnimal", selectedAnimal);
        PlayerPrefs.SetString("CTF_SelectedLevel", selectedLevel);
        
		playConfirmGameObject.SetActive(false);
        StartCoroutine(fadeScene.FadeOut("CTF_Game"));
    }
	
	public void TryAnimalBtnFunction() 
	{
        guide_chosen = so.guideChosen;

        switch(guide_chosen)
        {
            case "boy_guide":
                boyGuide.SetActive(true);
                girlGuide.SetActive(false);
                break;
            case "girl_guide":
                boyGuide.SetActive(false);
                girlGuide.SetActive(true);
                break;
        }

        playConfirmGameObject.SetActive(false);
		confirmationToARCanvas.SetActive(true);
	}
	public void ConfirmationToARYes() 
	{
        confirmationToARCanvas.SetActive(false);
        StateNameController.tryAnimalAnimalIndex = ARanimalIndex;
        StateNameController.isTryAnimalARClicked = true;
		StartCoroutine(fadeScene.FadeOut("Animal Selector AR"));
	}
	public void ConfirmationToARNo() 
	{
		confirmationToARCanvas.SetActive(false);
        playConfirmGameObject.SetActive(true);
	}

    public void openHighScoreCanvas() 
    {
        playConfirmGameObject.SetActive(false);
        highScoreCanvas.SetActive(true);
    }

    public void closeHighScoreCanvas() 
    {
        highScoreCanvas.SetActive(false);
        playConfirmGameObject.SetActive(true);
    }
}
