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
    public AudioClip GTS_BGM;

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
            // Loop through all active touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if the touch phase is "began" (when the touch starts)
                if (touch.phase == TouchPhase.Began)
                {
                    // Play the touch sound effect if the audio source is not currently playing
                    if (sfxSource != null && !sfxSource.isPlaying)
                    {
                        PlaySFX(touchSound);
                    }
                    // If audio source is already playing, delay the next touch event
                    else if (sfxSource != null && sfxSource.isPlaying)
                    {
                        StartCoroutine(DelayTouch());
                    }
                }
            }
        }
    }

    private System.Collections.IEnumerator DelayTouch()
    {
        // Wait for the duration of the sound effect
        yield return new WaitForSeconds(sfxSource.clip.length);

        // Allow the next touch event to trigger the sound effect
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
