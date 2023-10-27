using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CTF_TimerManager : MonoBehaviour
{

    [SerializeField] CTF_AudioManager audioManager;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float maxTime = 10f;

    private bool tenSecondsLeft = false;

    private bool isVolumeFading = false;
    private float fadeDuration = 5f;

    private float initialMusicVolume;

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
            Debug.Log("Ten Seconds Left: " + tenSecondsLeft);
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }

    private IEnumerator FadeOutMusic(float initialVolume)
    {
        isVolumeFading = true;

        float currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / fadeDuration;

            float newVolume = Mathf.Lerp(initialVolume, 0f, normalizedTime);
            audioManager.musicVolume = newVolume;

            yield return null;
        }

        isVolumeFading = false;
    }
}
