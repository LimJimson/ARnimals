using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectGuide : MonoBehaviour
{
    public GameObject blackPanel;
    public TMP_Text selectText;
    public Button boyBtn;
    public Button girlBtn;
    public SaveObject soScript;
    public Animator animatorBlackPanel;

    public Button boyBtnHighlight;
    public Button girlBtnHighlight;

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
        animatorBlackPanel.SetBool("panelFadeOut", false);
    }
    
    public void FixedUpdate()
    {
        if (selectText.color.a != 1)
        {
            boyBtnHighlight.gameObject.SetActive(true);
            girlBtnHighlight.gameObject.SetActive(true);
            boyBtn.interactable = false;
            girlBtn.interactable = false;
            blackPanel.SetActive(true);
            animatorBlackPanel.SetBool("panelFadeOut", false);
        }
        else if (selectText.color.a == 1)
        {
            StartCoroutine(delay(animatorBlackPanel.GetCurrentAnimatorStateInfo(0).length));
            animatorBlackPanel.SetBool("panelFadeOut", true);
            boyBtnHighlight.gameObject.SetActive(false);
            girlBtnHighlight.gameObject.SetActive(false);
            boyBtn.interactable = true;
            girlBtn.interactable = true;
            
        }

    }
    IEnumerator delay(float delayFadeOut = 0)
    {
        yield return new WaitForSeconds(delayFadeOut);
        blackPanel.SetActive(false);
    }
    public void tempBTN(){
        SceneManager.LoadScene("MainMenu");
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
