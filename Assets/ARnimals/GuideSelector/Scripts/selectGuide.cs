using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectGuide : MonoBehaviour
{
    SaveObject soScript;

    bool boy_guide = false;
    bool girl_guide = false;


    AudioManager audioManager;
    void Start()
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
        Screen.orientation = ScreenOrientation.LandscapeLeft;
       
    }

    public void selectBoy()
    {
        boy_guide = true;
        selectedGuide();
    }
    public void selectGirl()
    {
        girl_guide = true;
        selectedGuide();
    }
    public void selectedGuide()
    {
        SaveObject existingSO = SaveManager.Load();
        if (boy_guide)
        {
            StateNameController.guide_chosen = "boy_guide";
            existingSO.setGuide("boy_guide");
            SaveManager.Save(existingSO);
            SceneManager.LoadScene("MainMenu");
        }

        if (girl_guide)
        {
            StateNameController.guide_chosen = "girl_guide";
            existingSO.setGuide("girl_guide");
            SaveManager.Save(existingSO);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
