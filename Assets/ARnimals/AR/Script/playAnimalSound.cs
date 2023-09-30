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



    private void Awake()
    {
        animalIndex = _arPlacementScript.getAnimalIndex();

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
    bool isSndTimerCounting = false;
    float countdownTime = 3.0f;
    public Button playSndBtn;

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
                playSndBtn.interactable = true;

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

    }
    private void UpdateTimerText()
    {
        timerSndTxt.text = Convert.ToInt16(countdownTime).ToString();
    }
}
