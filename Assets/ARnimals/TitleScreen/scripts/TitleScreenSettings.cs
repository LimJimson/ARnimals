using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenSettings : MonoBehaviour
{
    AudioManager audioManager;
    SaveObject loaddata;
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioSource birdTweetSrc;

    public TMP_Text musicPercent;
    public TMP_Text sfxPercent;
    void Start()
    {
        try { 
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            audioManager.loadVolumeSettings();
        } catch { }

        loaddata = SaveManager.Load();

        musicSlider.onValueChanged.AddListener(ChangeVolumeMusic);
        sfxSlider.onValueChanged.AddListener(ChangeVolumeSFX);
        if (!StateNameController.successfullDataFetch)
        {
            birdTweetSrc.volume = 0.5f;
            musicSlider.value = 0.5f*100;

            audioManager.sfxSource.volume = 0.5f;
            sfxSlider.value = 0.5f * 100;
            UpdateVolumeMusicText();
        }
        else
        {
            birdTweetSrc.volume = loaddata.MusicVolume;
            musicSlider.value = loaddata.MusicVolume * 100;

            audioManager.sfxSource.volume = loaddata.SFXVolume;
            sfxSlider.value = loaddata.SFXVolume * 100;
            UpdateVolumeMusicText();
        }
        
        
    }

    public void saveSettings()
    {
        loaddata.MusicVolume = birdTweetSrc.volume;
        loaddata.SFXVolume = audioManager.sfxSource.volume;
        SaveManager.Save(loaddata);
    }
    private void ChangeVolumeMusic(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;

        // Update the audio source volume
        birdTweetSrc.volume = volumeLevel;

        // Update the volume text
        UpdateVolumeMusicText();
    }

    private void UpdateVolumeMusicText()
    {
        // Update the volume text to display the percentage
        musicPercent.text = musicSlider.value.ToString("0") + "%";
    }


    private void ChangeVolumeSFX(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;

        // Update the audio source volume
        audioManager.sfxSource.volume = volumeLevel;

        // Update the volume text
        UpdateVolumeSFXText();
    }

    private void UpdateVolumeSFXText()
    {
        // Update the volume text to display the percentage
        sfxPercent.text = sfxSlider.value.ToString("0") + "%";
    }
}
