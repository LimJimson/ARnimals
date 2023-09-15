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
    [SerializeField] private Button backBtn;

    private string selectedAnimal;
    private string selectedLevel;

    private void Start()
    {
        // Assign button click events
        level1Button.onClick.AddListener(OnLevel1ButtonClick);
        level2Button.onClick.AddListener(OnLevel2ButtonClick);
        level3Button.onClick.AddListener(OnLevel3ButtonClick);
        level4Button.onClick.AddListener(OnLevel4ButtonClick);
        level5Button.onClick.AddListener(OnLevel5ButtonClick);
        backBtn.onClick.AddListener(GoBackToMiniGamesSelection);
    }

    public void OnLevel1ButtonClick()
    {
        selectedAnimal = "Elephant";
        selectedLevel = "Level 1";
        LoadNextScene();
    }

    public void OnLevel2ButtonClick()
    {
        selectedAnimal = "Pigeon";
        selectedLevel = "Level 2";
        LoadNextScene();
    }

    public void OnLevel3ButtonClick()
    {
        selectedAnimal = "Koi";
        selectedLevel = "Level 3";
        LoadNextScene();
    }

    public void OnLevel4ButtonClick()
    {
        selectedAnimal = "Camel";
        selectedLevel = "Level 4";
        LoadNextScene();
    }

    public void OnLevel5ButtonClick()
    {
        selectedAnimal = "Crab";
        selectedLevel = "Level 5";
        LoadNextScene();
    }

    public void GoBackToMiniGamesSelection() 
    {
        SceneManager.LoadScene("MiniGamesSelect");
    }

    private void LoadNextScene()
    {
        // Pass the selected animal name to the next scene
        PlayerPrefs.SetString("SelectedAnimal", selectedAnimal);
        PlayerPrefs.SetString("SelectedLevel", selectedLevel);

        // Load the next scene
        SceneManager.LoadScene("CTF_Game");
    }
}
