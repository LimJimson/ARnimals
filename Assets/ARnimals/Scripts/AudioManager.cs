using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    SaveObject loaddata;
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource tapSource;
    public AudioSource guideSource;

    [Header("BGM")]
    public AudioClip mainBG;
    public AudioClip GTS_BGM;
    public AudioClip ForestHabitat_BGM;
    public AudioClip UnderwaterHabitat_BGM;
    public AudioClip SavannahHabitat_BGM;
    public AudioClip FTA_BGM;

    [Header("SFX")]
    public AudioClip touchSound;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip winLevel;
    public AudioClip loseLevel;

    [Header("GUIDE")]
    public AudioClip[] GuideSelector;

    public AudioClip[] MainMenuPatrick;
    public AudioClip[] MainMenuSandy;

    public AudioClip[] MainMenuSettingsPatrick;
    public AudioClip[] MainMenuSettingsSandy;

    public AudioClip[] AnimalInfoPatrick;
    public AudioClip[] AnimalInfoSandy;

    public AudioClip[] ModeSelectPatrick;
    public AudioClip[] ModeSelectSandy;

    public AudioClip[] AnimalSelectorPatrick;
    public AudioClip[] AnimalSelectorSandy;

    public AudioClip[] ARExpPatrick;
    public AudioClip[] ARExpSandy;

    public AudioClip[] MinigameSelectPatrick;
    public AudioClip[] MinigameSelectSandy;

    public AudioClip[] GTS_Patrick;
    public AudioClip[] GTS_Sandy;

    public float musicVol;
    public float sfxVol;
    public float guideVol;
    public float animalSndVol;
    public float vidVol;

    private bool canPlayTouchSound = true;

    public static AudioManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        loaddata = SaveManager.Load();
        loadVolumeSettings();
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerTouch();
        checkIfGuideIsPlaying();
    }

    void checkIfGuideIsPlaying()
    {

        if (guideSource.isPlaying)
        {
            if (musicSource.volume == 0)
            {
                musicSource.volume = 0;
            }
            else
            {
                musicSource.volume = 0.1f;
            }
            
        }
        else
        {
            musicSource.volume = musicVol;
        }
    }
    public void playBGMMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip); 
    }
    public void PlayGuide(AudioClip clip)
    {
        
        guideSource.Stop();
        guideSource.PlayOneShot(clip);
    }



    public void PlayTap(AudioClip clip)
    {
        tapSource.PlayOneShot(clip);
    }

    void checkPlayerTouch()
    {
        if (Input.touchCount > 0)
        {
            // Loop through all active touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if the touch phase is "began" (when the touch starts)
                if (touch.phase == TouchPhase.Began)
                {
                    // Play the touch sound effect if allowed
                    if (tapSource != null && !tapSource.isPlaying && canPlayTouchSound)
                    {
                        PlayTap(touchSound);

                        // Prevent the next touch from playing the sound effect immediately
                        canPlayTouchSound = false;
                        StartCoroutine(EnableTouchSound());
                    }
                }
            }
        }
    }

    private System.Collections.IEnumerator EnableTouchSound()
    {
        // Wait for a short duration before allowing the touch sound again
        yield return new WaitForSeconds(touchSound.length);

        // Allow the next touch event to trigger the sound effect
        canPlayTouchSound = true;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicVol = volume;
    }

    public void AnimalVolume(float volume)
    {
        animalSndVol = volume;
    }
    public void VidVolume(float volume)
    {
        vidVol = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        tapSource.volume = volume;
        sfxVol = volume;
    }

    public void GuideVolume(float volume)
    {
        guideSource.volume = volume;
        guideVol = volume;
    }


    public void loadVolumeSettings()
    {
        musicVol = loaddata.MusicVolume;
        sfxVol = loaddata.SFXVolume;
        guideVol = loaddata.GuideVolume;
        animalSndVol = loaddata.AnimalSndVolume;
        vidVol =loaddata.VideoSndVolume;
    }

}
