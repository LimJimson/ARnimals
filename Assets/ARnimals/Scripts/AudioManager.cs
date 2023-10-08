using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource tapSource;
    public AudioSource guideSource;

    [Header("BGM")]
    public AudioClip mainBG;
    public AudioClip GTS_BGM;

    [Header("SFX")]
    public AudioClip touchSound;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip winLevel;
    public AudioClip loseLevel;

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
                    // Play the touch sound effect if the audio source is not currently playing
                    if (tapSource != null && !tapSource.isPlaying)
                    {
                        PlayTap(touchSound);
                    }
                    // If audio source is already playing, delay the next touch event
                    else if (tapSource != null && tapSource.isPlaying)
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
        yield return new WaitForSeconds(tapSource.clip.length);

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
