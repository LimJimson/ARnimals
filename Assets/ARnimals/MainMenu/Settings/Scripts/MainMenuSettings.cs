using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MainMenuSettings : MonoBehaviour
{
    AudioManager audioManager;
    SaveObject loaddata;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider AnimalVolSlider;
    public Slider guideSlider;

    public TMP_Text musicPercent;
    public TMP_Text sfxPercent;
    public TMP_Text AnimalSndPercent;
    public TMP_Text guidePercent;

    public Slider musicSliderGuide;
    public Slider sfxSliderGuide;
    public Slider AnimalVolSliderGuide;
    public Slider guideSliderGuide;

    public TMP_Text musicPercentGuide;
    public TMP_Text sfxPercentGuide;
    public TMP_Text AnimalSndPercentGuide;
    public TMP_Text guidePercentGuide;


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

            
        } catch { }

        LoadSettings();

    }


    public void LoadSettings()
    {
        try
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


            musicSliderGuide.value = musicSlider.value;
            sfxSliderGuide.value = sfxSlider.value;
            guideSliderGuide.value = guideSlider.value;
            AnimalVolSliderGuide.value = AnimalVolSlider.value;

            UpdateVolumeMusicText();
            UpdateVolumeSFXText();
            UpdateVolumeAnimalSndText();
            UpdateVolumeGuideText();
        }
        catch
        {

        }
    }
    public void saveSettings()
    {
        try
        {
            loaddata.MusicVolume = audioManager.musicSource.volume;
            loaddata.SFXVolume = audioManager.sfxSource.volume;
            loaddata.AnimalSndVolume = AnimalVolSlider.value / 100f;
            loaddata.GuideVolume = audioManager.guideSource.volume;
            SaveManager.Save(loaddata);

            LoadSettings();
        }
        catch
        {

        }
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
        musicPercentGuide.text = musicSliderGuide.value.ToString("0") + "%";
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
        sfxPercentGuide.text = sfxPercent.text;
    }

    private void ChangeVolumeAnimalSnd(float value)
    {
        // Convert the slider value (percentage) to a volume level (0 to 1)
        float volumeLevel = value / 100f;


        audioManager.animalSndVol = volumeLevel;

        // Update the volume text
        UpdateVolumeAnimalSndText();
    }

    private void UpdateVolumeAnimalSndText()
    {
        // Update the volume text to display the percentage
        AnimalSndPercent.text = AnimalVolSlider.value.ToString("0") + "%";
        AnimalSndPercentGuide.text = AnimalSndPercent.text;
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
        guidePercentGuide.text = guidePercent.text;
    }
}
    
