using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimalInfoSettings : MonoBehaviour
{
    AudioManager audioManager;
    SaveObject loaddata;

    public VideoPlayer animalVidPlayer;
    public AudioSource animalSnd;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider AnimalVolSlider;
    public Slider guideSlider;
    public Slider videoSlider;

    public TMP_Text musicPercent;
    public TMP_Text sfxPercent;
    public TMP_Text AnimalSndPercent;
    public TMP_Text guidePercent;
    public TMP_Text videoPercent;

    void Start()
    {
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            loaddata = SaveManager.Load();

            musicSlider.onValueChanged.AddListener(ChangeVolumeMusic);
            sfxSlider.onValueChanged.AddListener(ChangeVolumeSFX);
            AnimalVolSlider.onValueChanged.AddListener(ChangeVolumeAnimalSnd);
            guideSlider.onValueChanged.AddListener(ChangeVolumeGuide);
            videoSlider.onValueChanged.AddListener(ChangeVolumeVideoSnd);

            LoadSettings();
        }
        catch { }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSettings()
    {

        audioManager.musicVol = loaddata.MusicVolume;

        audioManager.musicSource.volume = audioManager.musicVol;
        musicSlider.value = loaddata.MusicVolume * 100;

        audioManager.sfxSource.volume = loaddata.SFXVolume;
        sfxSlider.value = loaddata.SFXVolume * 100;

        audioManager.animalSndVol = loaddata.AnimalSndVolume;
        AnimalVolSlider.value = loaddata.AnimalSndVolume * 100;

        audioManager.guideSource.volume = loaddata.GuideVolume;
        guideSlider.value = loaddata.GuideVolume * 100;

        audioManager.vidVol = loaddata.VideoSndVolume;
        videoSlider.value = loaddata.VideoSndVolume * 100;


        UpdateVolumeMusicText();
        UpdateVolumeMusicText();
        UpdateVolumeSFXText();
        UpdateVolumeAnimalSndText();
        UpdateVolumeGuideText();
        UpdateVolumeVideoSndText();
    }
    public void saveSettings()
    {
        loaddata.MusicVolume = audioManager.musicSource.volume;
        loaddata.SFXVolume = audioManager.sfxSource.volume;
        loaddata.AnimalSndVolume = AnimalVolSlider.value / 100f;
        loaddata.VideoSndVolume = videoSlider.value / 100f;
        loaddata.GuideVolume = audioManager.guideSource.volume;
        SaveManager.Save(loaddata);

        LoadSettings();
    }
    private void ChangeVolumeMusic(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;

        // Update the audio source volume
        audioManager.musicVol = volumeLevel;


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

    private void ChangeVolumeAnimalSnd(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;


        audioManager.animalSndVol = volumeLevel;
        animalSnd.volume = volumeLevel;

        // Update the volume text
        UpdateVolumeAnimalSndText();
    }

    private void UpdateVolumeAnimalSndText()
    {
        // Update the volume text to display the percentage
        AnimalSndPercent.text = AnimalVolSlider.value.ToString("0") + "%";
    }
    private void ChangeVolumeVideoSnd(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;


        audioManager.vidVol = volumeLevel;
        animalVidPlayer.SetDirectAudioVolume(0, volumeLevel);

        // Update the volume text
        UpdateVolumeVideoSndText();
    }

    private void UpdateVolumeVideoSndText()
    {
        // Update the volume text to display the percentage
        videoPercent.text = videoSlider.value.ToString("0") + "%";
    }
    private void ChangeVolumeGuide(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;

        // Update the audio source volume
        audioManager.guideSource.volume = volumeLevel;

        // Update the volume text
        UpdateVolumeGuideText();
    }

    private void UpdateVolumeGuideText()
    {
        // Update the volume text to display the percentage
        guidePercent.text = guideSlider.value.ToString("0") + "%";
    }
}
