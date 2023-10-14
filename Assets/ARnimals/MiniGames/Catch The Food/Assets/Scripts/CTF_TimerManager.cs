using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CTF_TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float maxTime = 10f;

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
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }
}
