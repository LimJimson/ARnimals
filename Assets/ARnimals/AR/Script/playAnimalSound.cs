using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playAnimalSound : MonoBehaviour
{
    public int animalIndex;
    public ARPlacement _arPlacementScript;
    public AudioSource audioSrc;
    public AudioClip[] clip;

    public GameObject animalSndBtn;
    AudioManager audioManager;



    private void Awake()
    {
        animalIndex = _arPlacementScript.getAnimalIndex();
        try { audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); } catch { }
    }

    private void Start()
    {

    }

    public void showSpeaker()
    {
        if (clip[animalIndex] == null)
        {
            animalSndBtn.SetActive(false);
        }
        else
        {
            animalSndBtn.SetActive(true);
        }
    }
    private void Update()
    {
        countdownSnd();
    }
    public void playSound()
    {

        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(clip[animalIndex]);
            audioManager.guideSource.UnPause();
            audioManager.musicSource.UnPause();
        }
    }

    public void stopSound()
    {
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }

    }
    public TMP_Text timerSndTxt;
    public TMP_Text timerSndTxt2;
    bool isSndTimerCounting = false;
    float countdownTime = 3.0f;
    public Button playSndBtn;
    public Button playSndBtn2;
    void countdownSnd()
    {
        if (isSndTimerCounting)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 3.0f;
                isSndTimerCounting = false;
                timerSndTxt.gameObject.SetActive(false);
                timerSndTxt2.gameObject.SetActive(false);
                playSndBtn.interactable = true;
                playSndBtn2.interactable = true;
}

            UpdateTimerText();
        }
    }

    public void StartCountdown()
    {
        isSndTimerCounting = true;
        countdownSnd();
        timerSndTxt.gameObject.SetActive(true);
        playSndBtn.interactable = false;
        timerSndTxt2.gameObject.SetActive(true);
        playSndBtn2.interactable = false;

    }
    private void UpdateTimerText()
    {
        timerSndTxt.text = Convert.ToInt16(countdownTime).ToString();
        timerSndTxt2.text = Convert.ToInt16(countdownTime).ToString();
    }
}
