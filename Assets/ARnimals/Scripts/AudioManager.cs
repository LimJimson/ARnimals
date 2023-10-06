using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource guideSource;

    [Header("BGM")]
    public AudioClip mainBG;

    [Header("SFX")]
    public AudioClip touchSound;

    [Header("GUIDE")]
    public AudioClip[] GuideSelector;
    public AudioClip[] MainMenu;
    public AudioClip[] ModeSelect;
    public AudioClip[] AnimalSelector;
    public AudioClip[] MinigameSelect;




    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        checkPlayerTouch();
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


    void checkPlayerTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                sfxSource.Stop();
                PlaySFX(touchSound);
            }
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void GuideVolume(float volume)
    {
        guideSource.volume = volume;
    }

}
