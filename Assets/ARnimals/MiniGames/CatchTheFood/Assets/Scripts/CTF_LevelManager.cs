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

    private string selectedAnimal;
    private string selectedLevel;

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
        SceneManager.LoadScene("MiniGamesSelect");
    }

    private void LoadNextScene()
    {
        // Pass the selected animal name to the next scene
        PlayerPrefs.SetString("CTF_SelectedAnimal", selectedAnimal);
        PlayerPrefs.SetString("CTF_SelectedLevel", selectedLevel);

        // Load the next scene
        SceneManager.LoadScene("CTF_Game");
    }
}
