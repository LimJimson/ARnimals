using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AR_Narration : MonoBehaviour
{
    int animalIndex;
    public ARPlacement _arPlacementScript;
    public AR_NarrateSubtitles narrateSubtitlesScript;
    SaveObject loaddata;
    string guide_chosen;

    AudioManager audiomanager;
    public GameObject NarrateCanvas;
    public GameObject[] GameObjectsToHideARNarration;

    public bool isNarrationActive;

    public TMP_Text totalAudioTime;
    public TMP_Text currentAudioTime;


    bool hideNarrateCanvas;
    void Start()
    {
        loaddata = SaveManager.Load();
        isNarrationActive = false;
        guide_chosen = loaddata.guideChosen;
        try { audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); } catch { }
        
    }
    public void getTotalTime()
    {

        if (guide_chosen == "boy_guide")
        {
            float clipLengthInSeconds = audiomanager.AR_Narration_Patrick[animalIndex].length;
            string formattedTime = FormatTime(clipLengthInSeconds);
            totalAudioTime.text = formattedTime;
        } else if (guide_chosen == "girl_guide")
        {
            float clipLengthInSeconds = audiomanager.AR_Narration_Sandy[animalIndex].length;
            string formattedTime = FormatTime(clipLengthInSeconds);
            totalAudioTime.text = formattedTime;

        }


    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {

        try
        {
            if (audiomanager.guideSource.isPlaying && isNarrationActive)
            {

                float currentTime = audiomanager.guideSource.time;
                string formattedTime = FormatTime(currentTime);
                currentAudioTime.text = formattedTime;

                NarrateCanvas.SetActive(true);
                audiomanager.musicSource.Pause();

                foreach (GameObject items in GameObjectsToHideARNarration)
                {
                    items.SetActive(false);
                }
            }

            if (!audiomanager.guideSource.isPlaying && isNarrationActive)
            {
                isNarrationActive = false;
                audiomanager.musicSource.UnPause();

                NarrateCanvas.SetActive(false);
                foreach (GameObject items in GameObjectsToHideARNarration)
                {
                    items.SetActive(true);
                }

            }
        }
        catch{}
    }
    public void NarrateBtn()
    {
        StopAllCoroutines();
        animalIndex = _arPlacementScript.getAnimalIndex();
        isNarrationActive = true;
        if (guide_chosen == "boy_guide")
        {
            try { audiomanager.PlayGuide(audiomanager.AR_Narration_Patrick[animalIndex]);  } catch { }
            narrateSubtitlesScript.animalSub();

        }
        else if (guide_chosen == "girl_guide")
        {
            try { audiomanager.PlayGuide(audiomanager.AR_Narration_Sandy[animalIndex]); } catch { }
            narrateSubtitlesScript.animalSub();

        }
            

    }

    private void OnApplicationFocus(bool focus)
    {
        exitNarration();
    }

    public void exitNarration()
    {
        if (isNarrationActive) {
            isNarrationActive = false;
            audiomanager.musicSource.UnPause();

            try { audiomanager.guideSource.Stop(); } catch { }

            NarrateCanvas.SetActive(false);
            foreach (GameObject items in GameObjectsToHideARNarration)
            {
                items.SetActive(true);
            }
        }

    }



}
