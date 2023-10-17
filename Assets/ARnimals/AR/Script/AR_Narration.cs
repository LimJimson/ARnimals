using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AR_Narration : MonoBehaviour
{
    int animalIndex;
    public ARPlacement _arPlacementScript;
    SaveObject loaddata;
    string guide_chosen;

    AudioManager audiomanager;
    public GameObject NarrateCanvas;
    public GameObject[] GameObjectsToHideARNarration;

    bool isNarrationActive;
    bool isNarrationPaused;

    public Button play_pauseBtn;
    public Sprite[] play_pauseSprite;


    bool hideNarrateCanvas;
    void Start()
    {
        loaddata = SaveManager.Load();
        isNarrationActive = false;
        isNarrationPaused = false;
        guide_chosen = loaddata.guideChosen;
        try { audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); } catch { }
        
    }

    void Update()
    {
        if (audiomanager.guideSource.isPlaying && isNarrationActive)
        {
            NarrateCanvas.SetActive(true);
            

            foreach (GameObject items in GameObjectsToHideARNarration)
            {
                items.SetActive(false);
            }
        }
        else if (!audiomanager.guideSource.isPlaying && !isNarrationActive && hideNarrateCanvas)
        {
            NarrateCanvas.SetActive(false);
            foreach (GameObject items in GameObjectsToHideARNarration)
            {
                items.SetActive(true);
            }
        }

        if(!audiomanager.guideSource.isPlaying && isNarrationActive && !isNarrationPaused)
        {
            isNarrationActive = false;
        }

    }
    public void play_pauseNarration()
    {
        if (audiomanager.guideSource.isPlaying)
        {
            try { audiomanager.guideSource.Pause(); } catch { }
            play_pauseBtn.image.sprite = play_pauseSprite[1];
            isNarrationPaused = true;
        }
        else
        {
            try { audiomanager.guideSource.UnPause(); }catch { }
            play_pauseBtn.image.sprite = play_pauseSprite[0];
            isNarrationPaused = false;
        }
    }
    public void NarrateBtn()
    {
        if(isNarrationActive)
        {
            isNarrationActive = false;
            hideNarrateCanvas = true;
            try { audiomanager.guideSource.Stop(); } catch { }
        }
        else
        {
            animalIndex = _arPlacementScript.getAnimalIndex();
            isNarrationActive = true;
            hideNarrateCanvas = false;

            if (guide_chosen == "boy_guide")
            {
                try { audiomanager.PlayGuide(audiomanager.AR_Narration_Patrick[animalIndex]);  } catch { }

               
            }
            else if (guide_chosen == "girl_guide")
            {
                try { audiomanager.PlayGuide(audiomanager.AR_Narration_Sandy[animalIndex]); } catch { }
                
            }
            
        }

    }



}
