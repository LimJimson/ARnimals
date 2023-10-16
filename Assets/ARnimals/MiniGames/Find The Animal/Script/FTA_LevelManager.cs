using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FTA_LevelManager : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;

    [SerializeField] private GameObject[] locks;

    [SerializeField] private TextMeshProUGUI animalToUnlockName;
    private string SelectedLevel;

    AudioManager audioManager;

    public void Start()
    {
        checkIfLevelIsUnlocked();
        SelectedLevel = PlayerPrefs.GetString("FTA_SelectedLevel", "1");
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
    public void Level1isCLicked()
    {
        SelectedLevel = "1";
        animalToUnlockName.text = "Leopard";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void Level2isCLicked()
    {
        SelectedLevel = "2";
        animalToUnlockName.text = "Pigeon";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void Level3isCLicked()
    {
        SelectedLevel = "3";
        animalToUnlockName.text = "Piranha";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void Level4isCLicked()
    {
        SelectedLevel = "4";
        animalToUnlockName.text = "Bear";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }

    public void Level5isCLicked()
    {
        SelectedLevel = "5";
        animalToUnlockName.text = "Owl";
        checkStar();
        playConfirmGameObject.SetActive(true);
    }
    public void LoadNextLevel()
    {
        PlayerPrefs.SetString("FTA_SelectedLevel", SelectedLevel);
        SceneManager.LoadScene("FTA_Game");
        audioManager.musicSource.Stop();
        playConfirmGameObject.SetActive(false);
    }

    private void checkIfLevelIsUnlocked()
    {
        if (PlayerPrefs.GetInt("FTA_Lvl1", 0) == 1)
        {
            locks[0].SetActive(false);
            level2Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl2", 0) == 1)
        {
            locks[1].SetActive(false);
            level3Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl3", 0) == 1)
        {
            locks[2].SetActive(false);
            level4Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl4", 0) == 1)
        {
            locks[3].SetActive(false);
            level5Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl5", 0) == 1)
        {

        }
    }
    [SerializeField] private Image starsImg;
    [SerializeField] private Sprite[] starsSprites;
    [SerializeField] private Image levelImg;
    [SerializeField] private Sprite[] levelSprites;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject playConfirmGameObject;

    [SerializeField] private GameObject checkGameObject;
    [SerializeField] private GameObject tryAnimalBtn;
    [SerializeField] private GameObject confirmationToARCanvas;

    public void checkStar()
    {

        animalImg.sprite = animalSprites[int.Parse(SelectedLevel)];

        levelImg.sprite = levelSprites[int.Parse(SelectedLevel)];

        int currentStar = PlayerPrefs.GetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 0);

        checkGameObject.SetActive(false);
        tryAnimalBtn.SetActive(false);

        Debug.Log("Level: " + SelectedLevel + "\n" + "currentStar: " + currentStar);

        switch (currentStar)
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
                tryAnimalBtn.SetActive(true);
                break;
            case 3:
                starsImg.sprite = starsSprites[3];
                checkGameObject.SetActive(true);
                tryAnimalBtn.SetActive(true);
                break;
        }
    }
    public void closeButtonFunction()
    {
        playConfirmGameObject.SetActive(false);
    }
    public void backButtonFTA()
    {
        SceneManager.LoadScene("MiniGamesSelect");
    }
    public void TryAnimalARButton()
    {
        confirmationToARCanvas.SetActive(true);
    }
    public void ConfirmYesTryAnimalARButton()
    {
        SceneManager.LoadScene("Animal Selector AR");
    }
    public void ConfirmNoTryAnimalARButton()
    {
        confirmationToARCanvas.SetActive(false);
    }
}
