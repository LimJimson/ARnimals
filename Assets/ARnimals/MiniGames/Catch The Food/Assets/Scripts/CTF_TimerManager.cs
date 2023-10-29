using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class CTF_TimerManager : MonoBehaviour
{

    [SerializeField] CTF_AudioManager audioManager;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float maxTime = 10f;

    private bool tenSecondsLeft = false;

    private bool isVolumeFading = false;
    private float fadeDuration = 5f;

    private float initialMusicVolume;

    private float changedValue = 0f;
    private float currentTime;

    public float getCurrentTime() 
    {
        return currentTime;
    }

    private void Start()
    {
        currentTime = maxTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Time's up logic
            CTF_GameManager.Instance.TimeUp();
        }

        if (currentTime <= 15f && currentTime > 10f && !isVolumeFading)
        {
            initialMusicVolume = audioManager.musicVolume;
            StartCoroutine(FadeOutMusic(initialMusicVolume));
        }

        if (currentTime <= 10.0f && !tenSecondsLeft) 
        {
            audioManager.stopBGMusic();
            audioManager.playCountdown();
            tenSecondsLeft = true;
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }

    private IEnumerator FadeOutMusic(float initialVolume)
    {
        isVolumeFading = true;

        float localInitialVolume = initialMusicVolume;

        float currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / fadeDuration;

            float newVolume = Mathf.Lerp(initialVolume, 0f, normalizedTime);

            if (!CTF_GameManager.Instance.IsOptionsUIOpen) 
            {
                audioManager.musicVolume = newVolume;
            }
            else 
            {
                if (Mathf.RoundToInt(audioManager.musicVolume * 100) == Mathf.RoundToInt(newVolume * 100))  
                {
                    changedValue = localInitialVolume;
                    audioManager.musicVolume = changedValue;
                }
                else 
                {
                    localInitialVolume = audioManager.musicVolume;
                    changedValue = localInitialVolume;
                    audioManager.musicVolume = changedValue;
                }
            }
            yield return null;
        }

        if (changedValue == 0) 
        {
            audioManager.musicVolume = initialMusicVolume;
        }
        else 
        {
            audioManager.musicVolume = changedValue;
        }

        isVolumeFading = false;
    }
}
