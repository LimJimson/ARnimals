using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FTA_AudioManager : MonoBehaviour
{
    AudioManager mainAudioManager;

    SaveObject loaddata;

    public AudioSource animalAudioSrc;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider guideSlider;
    public Slider AnimalVolSlider;

    [SerializeField] private TextMeshProUGUI musicPercentTxt;
    [SerializeField] private TextMeshProUGUI sfxPercentTxt;
    [SerializeField] private TextMeshProUGUI guidePercentText;
    public TextMeshProUGUI animalSndPercentText;

    void Start()
    {
        try
        {
            mainAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            Debug.Log("AudioManager Available");
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

        loaddata = SaveManager.Load();

        loadSavedVolume();
    }

    private void Update()
    {

    }

    public void loadSavedVolume()
    {
        mainAudioManager.musicSource.volume = loaddata.MusicVolume;
        mainAudioManager.sfxSource.volume = loaddata.SFXVolume;
        mainAudioManager.guideSource.volume = loaddata.GuideVolume;
        mainAudioManager.animalSndVol = loaddata.AnimalSndVolume;

        musicSlider.value = mainAudioManager.musicSource.volume;
        sfxSlider.value = mainAudioManager.sfxSource.volume;
        guideSlider.value = mainAudioManager.guideSource.volume;
        AnimalVolSlider.value = mainAudioManager.animalSndVol;

        int percentageForMusicSlider = Mathf.RoundToInt(musicSlider.value * 100);
        musicPercentTxt.text = percentageForMusicSlider.ToString() + "%";
        int percentageForSFXSlider = Mathf.RoundToInt(sfxSlider.value * 100);
        sfxPercentTxt.text = percentageForSFXSlider.ToString() + "%";
        int percentageForGuideSlider = Mathf.RoundToInt(guideSlider.value * 100);
        guidePercentText.text = percentageForGuideSlider.ToString() + "%";
        int percentageForAnimalSndSlider = Mathf.RoundToInt(AnimalVolSlider.value * 100);
        animalSndPercentText.text = percentageForAnimalSndSlider.ToString() + "%";
    }

    public void changeMusicVolume()
    {
        mainAudioManager.musicVol = musicSlider.value;

        int percentage = Mathf.RoundToInt(musicSlider.value * 100);
        musicPercentTxt.text = percentage.ToString() + "%";

        Debug.Log("Music Source Volume: " + mainAudioManager.musicSource.volume);
    }

    public void changeSfxVolume()
    {
        mainAudioManager.sfxSource.volume = sfxSlider.value;

        int percentage = Mathf.RoundToInt(sfxSlider.value * 100);
        sfxPercentTxt.text = percentage.ToString() + "%";
    }

    public void changeGuideVolume()
    {
        mainAudioManager.guideSource.volume = guideSlider.value;

        int percentage = Mathf.RoundToInt(guideSlider.value * 100);
        guidePercentText.text = percentage.ToString() + "%";
    }

    public void changeAnimalSndVolume()
    {
        mainAudioManager.animalSndVol = AnimalVolSlider.value;
        animalAudioSrc.volume = mainAudioManager.animalSndVol;

        int percentage = Mathf.RoundToInt(AnimalVolSlider.value * 100);
        animalSndPercentText.text = percentage.ToString() + "%";
    }

    public void saveVolume()
    {
        changeMusicVolume();
        changeSfxVolume();
        changeGuideVolume();
        changeAnimalSndVolume();

        loaddata.MusicVolume = mainAudioManager.musicSource.volume;
        loaddata.SFXVolume = mainAudioManager.sfxSource.volume;
        loaddata.GuideVolume = mainAudioManager.guideSource.volume;
        loaddata.AnimalSndVolume = mainAudioManager.animalSndVol;

        SaveManager.Save(loaddata);

        loadSavedVolume();
    }
}
