using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CTF_LevelManager : MonoBehaviour
{

    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;

    [SerializeField] private GameObject [] locks;

    [SerializeField] private GameObject [] buttonBlocks;

    [SerializeField] private Button backBtn;
    [SerializeField] private GameObject transitionToOut;
    [SerializeField] private Image transitionToOutImg;
    [SerializeField] private GameObject transitionToIn;
    [SerializeField] private Image transitionToInImg;

    [Header("Confirm Play")]

    [SerializeField] private Image starsImg;
    [SerializeField] private Sprite [] starsSprites;
    [SerializeField] private Image levelImg;
    [SerializeField] private Sprite[] levelSprites;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject checkGameObject;
    [SerializeField] private GameObject playConfirmGameObject;

    private string selectedAnimal;
    private string selectedLevel;

    private string buttonCode;

    private void Start()
    {		
		selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel", "1");
		
		checkStar();
		
        // Assign button click events
        level1Button.onClick.AddListener(OnLevel1ButtonClick);

        if (PlayerPrefs.GetInt("CTF_Lvl1", 0) == 1) 
        {
            locks[0].SetActive(false);
            level2Button.onClick.AddListener(OnLevel2ButtonClick);
            buttonBlocks[0].SetActive(false);
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl2", 0) == 1) 
        {
            locks[1].SetActive(false);
            level3Button.onClick.AddListener(OnLevel3ButtonClick);
            buttonBlocks[1].SetActive(false);
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl3", 0) == 1) 
        {
            locks[2].SetActive(false);
            level4Button.onClick.AddListener(OnLevel4ButtonClick);
            buttonBlocks[2].SetActive(false);
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl4", 0) == 1) 
        {
            locks[3].SetActive(false);
            level5Button.onClick.AddListener(OnLevel5ButtonClick);
            buttonBlocks[3].SetActive(false);
        }
        if  (PlayerPrefs.GetInt("CTF_Lvl5", 0) == 1) 
        {

        }

        backBtn.onClick.AddListener(GoBackToMiniGamesSelection);

        transitionToIn.SetActive(true);
		
    }

    private void Update() 
    {
        checkIfTransitionIsDone();
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
				checkGameObject.SetActive(true);
				break;
			case 3:
				starsImg.sprite = starsSprites[3];
				checkGameObject.SetActive(true);
				break;
		}
    }

    public void OnLevel1ButtonClick()
    {
        selectedAnimal = "Elephant";
        selectedLevel = "1";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel2ButtonClick()
    {
        selectedAnimal = "Pigeon";
        selectedLevel = "2";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel3ButtonClick()
    {
        selectedAnimal = "Koi";
        selectedLevel = "3";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel4ButtonClick()
    {
        selectedAnimal = "Camel";
        selectedLevel = "4";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void OnLevel5ButtonClick()
    {
        selectedAnimal = "Crab";
        selectedLevel = "5";
        checkStar();
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
        // Pass the selected animal name to the next scene
        PlayerPrefs.SetString("CTF_SelectedAnimal", selectedAnimal);
        PlayerPrefs.SetString("CTF_SelectedLevel", selectedLevel);
        
        buttonCode = "levelButton";
		playConfirmGameObject.SetActive(false);
        transitionToOut.SetActive(true);
    }
}
