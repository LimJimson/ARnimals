using System.Collections;
using System.Collections.Generic;
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

    private string SelectedLevel;
    AudioManager audioManager;

    public void Start()
    {
        checkIfLevelIsUnlocked();
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
        LoadNextLevel();
    }

    public void Level2isCLicked()
    {
        SelectedLevel = "2";
        LoadNextLevel();
    }

    public void Level3isCLicked()
    {
        SelectedLevel = "3";
        LoadNextLevel();
    }

    public void Level4isCLicked()
    {
        SelectedLevel = "4";
        LoadNextLevel();
    }

    public void Level5isCLicked()
    {
        SelectedLevel = "5";
        LoadNextLevel();
    }
    private void LoadNextLevel()
    {
        PlayerPrefs.SetString("FTA_SelectedLevel", SelectedLevel);
        SceneManager.LoadScene("FTA_Game");
        audioManager.musicSource.Stop();
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
}
