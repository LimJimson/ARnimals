using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CTF_GameResumeTimerManager : MonoBehaviour
{

    [SerializeField] private CTF_AudioManager audioManager;
    [SerializeField] private GameObject resumeTimerCanvas;
    [SerializeField] private GameObject gameResumeTimerManager;
    [SerializeField] private GameObject bgPanelCanvas;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private TextMeshProUGUI countdownText;

    private float resumeTime = 3f;

    private void Update()
    {
        resumeTime -= Time.unscaledDeltaTime;
        int secondsLeft = Mathf.CeilToInt(resumeTime);

        resumeTimerCanvas.SetActive(true);

        if (secondsLeft > 0)
        {
            countdownText.text = secondsLeft.ToString();
        }
        else
        {
            resumeTime = 3f;
            bgPanelCanvas.SetActive(false);
            resumeTimerCanvas.SetActive(false);
            gameResumeTimerManager.SetActive(false);
			audioManager.unPauseBGMusic();
            audioManager.unPauseCountdown();
            pauseManager.ResumeGame();
        }    
    }
}
