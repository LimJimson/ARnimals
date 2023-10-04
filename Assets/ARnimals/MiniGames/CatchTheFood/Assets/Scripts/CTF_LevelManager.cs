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

    private string selectedAnimal;
    private string selectedLevel;

    private string buttonCode;

    private void Start()
    {
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

        bool achievedImgPositionOut = transitionToOutImg.rectTransform.anchoredPosition.x <= -1070.5f && transitionToOutImg.rectTransform.anchoredPosition.x >= -1071.5f;
        bool achievedImgPositionIn = transitionToInImg.rectTransform.anchoredPosition.x <= -2790.5f && transitionToInImg.rectTransform.anchoredPosition.x >= -2791.5f;

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

    public void OnLevel1ButtonClick()
    {
        selectedAnimal = "Elephant";
        selectedLevel = "1";
        LoadNextScene();
    }

    public void OnLevel2ButtonClick()
    {
        selectedAnimal = "Pigeon";
        selectedLevel = "2";
        LoadNextScene();
    }

    public void OnLevel3ButtonClick()
    {
        selectedAnimal = "Koi";
        selectedLevel = "3";
        LoadNextScene();
    }

    public void OnLevel4ButtonClick()
    {
        selectedAnimal = "Camel";
        selectedLevel = "4";
        LoadNextScene();
    }

    public void OnLevel5ButtonClick()
    {
        selectedAnimal = "Crab";
        selectedLevel = "5";
        LoadNextScene();
    }

    public void GoBackToMiniGamesSelection() 
    {
        buttonCode = "backButton";
        transitionToOut.SetActive(true);
    }

    private void LoadNextScene()
    {
        // Pass the selected animal name to the next scene
        PlayerPrefs.SetString("CTF_SelectedAnimal", selectedAnimal);
        PlayerPrefs.SetString("CTF_SelectedLevel", selectedLevel);
        
        buttonCode = "levelButton";
        transitionToOut.SetActive(true);
    }
}
