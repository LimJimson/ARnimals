using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;	

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
    [SerializeField] private GameObject transitionToOut;
    [SerializeField] private Image transitionToOutImg;
    [SerializeField] private GameObject transitionToIn;
    [SerializeField] private Image transitionToInImg;
	[SerializeField] private GameObject plainBlackPanel;

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
	[SerializeField] private GameObject tryAnimalBtn;
	
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

    private string buttonCode;

    private void Start()
    {		
        so = SaveManager.Load();
		selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel", "1");
		checkIfLevelIsUnlocked();
		checkStar();
		plainBlackPanel.SetActive(true);
        StartCoroutine(showTransitionAfterDelay());
		
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
        checkIfTransitionIsDone();
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
	
	private IEnumerator showTransitionAfterDelay() 
	{
		yield return new WaitForSeconds(0.05f);
		plainBlackPanel.SetActive(false);
		transitionToIn.SetActive(true);
	}

    private void checkIfTransitionIsDone() 
    {

        bool achievedImgPositionOut = transitionToOutImg.color.a >= 0.9999 && transitionToOutImg.color.a <= 1.0001;
        bool achievedImgPositionIn = transitionToInImg.color.a >= -0.0001 && transitionToInImg.color.a <= 0.0001;

        if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "levelButton") 
        {
            SceneManager.LoadScene("CTF_Game");
        }
        else if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "backButton")
        {
            Debug.Log("Back animation");
            SceneManager.LoadScene("MiniGamesSelect");
        }
		else if (transitionToOut.activeSelf && achievedImgPositionOut && buttonCode == "tryAnimalButton")
        {
            Debug.Log("Back animation");
            SceneManager.LoadScene("Animal Selector AR");
        }

        if (transitionToIn.activeSelf && achievedImgPositionIn) 
        {
            transitionToIn.SetActive(false);
        }
    }

    public void checkStar() 
    { 

        animalImg.sprite = animalSprites[int.Parse(selectedLevel)];

        levelImg.sprite = levelSprites[int.Parse(selectedLevel)];

        int currentStar = PlayerPrefs.GetInt("CTF_Lvl" + selectedLevel + "StarsCount", 0);

        checkGameObject.SetActive(false);
		tryAnimalBtn.SetActive(false);
        checkImgForLvlToUnlock.SetActive(false);
        starsToUnlockGO.SetActive(true);
        lvlToUnlockImg.gameObject.SetActive(true);
        allLevelsUnlockGO.SetActive(false);
		
		Debug.Log("Level: " + selectedLevel + "\n" + "currentStar: " + currentStar);
		
		switch(currentStar) 
		{
			case 0:
				starsImg.sprite = starsSprites[0];
				break;
			case 1:
				starsImg.sprite = starsSprites[1];
				break;
			case 2:
				starsImg.sprite = starsSprites[2];
                checkImgForLvlToUnlock.SetActive(true);
				break;
			case 3:
				starsImg.sprite = starsSprites[3];
                checkImgForLvlToUnlock.SetActive(true);
				checkGameObject.SetActive(true);
				tryAnimalBtn.SetActive(true);
				break;
		}
    }

    public void OnLevel1ButtonClick()
    {
        selectedAnimal = "Elephant";
        selectedLevel = "1";
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[0];
        animalToUnlockName.text = "Octopus";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel2ButtonClick()
    {
        selectedAnimal = "Pigeon";
        selectedLevel = "2";
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[1];
        animalToUnlockName.text = "Deer";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel3ButtonClick()
    {
        selectedAnimal = "Koi";
        selectedLevel = "3";
        animalToUnlockName.text = "Seagull";
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[2];
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel4ButtonClick()
    {
        selectedAnimal = "Camel";
        selectedLevel = "4";
        checkStar();
        lvlToUnlockImg.sprite = lvlToUnlockSprites[3];
        animalToUnlockName.text = "Shark";
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel5ButtonClick()
    {
        selectedAnimal = "Crab";
        selectedLevel = "5";
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
        buttonCode = "backButton";
        transitionToOut.SetActive(true);
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
        
        buttonCode = "levelButton";
		playConfirmGameObject.SetActive(false);
        transitionToOut.SetActive(true);
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

		confirmationToARCanvas.SetActive(true);
	}
	public void ConfirmationToARYes() 
	{
		buttonCode = "tryAnimalButton";
		transitionToOut.SetActive(true);
	}
	public void ConfirmationToARNo() 
	{
		confirmationToARCanvas.SetActive(false);
	}
}
