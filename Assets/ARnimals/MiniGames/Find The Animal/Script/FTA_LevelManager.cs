using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FTA_LevelManager : MonoBehaviour
{
    private string SelectedLevel;
    AudioManager audioManager;

    public void Start()
    {
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
}
