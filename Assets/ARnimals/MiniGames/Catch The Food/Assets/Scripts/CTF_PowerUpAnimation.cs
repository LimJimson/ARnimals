using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTF_PowerUpAnimation : MonoBehaviour
{

    [SerializeField] private GameObject powerUpGo;
    [SerializeField] private Sprite points2X;
    [SerializeField] private Sprite shield;
    [SerializeField] private Sprite luck;

    private Image powerUpImg;

    private float fadeDuration = 0.8f;

    private bool fadeStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        powerUpImg = powerUpGo.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        showPowerUpState();
    }

    private IEnumerator FadeIn(Sprite sprite)
    {
        powerUpImg.sprite = sprite;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
            powerUpImg.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
            powerUpImg.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }

    private IEnumerator PowerUpSequence(Sprite firstSprite, Sprite secondSprite)
    {
        if (!fadeStarted) 
        {
            fadeStarted = true;
            yield return StartCoroutine(FadeIn(firstSprite));
            yield return StartCoroutine(FadeOut());
            yield return StartCoroutine(FadeIn(secondSprite));
            yield return StartCoroutine(FadeOut());
            fadeStarted = false;
        }
    }

    private IEnumerator PowerUpSequence(Sprite firstSprite, Sprite secondSprite, Sprite thirdSprite)
    {
        if (!fadeStarted) 
        {
            fadeStarted = true;
            yield return StartCoroutine(FadeIn(firstSprite));
            yield return StartCoroutine(FadeOut());
            yield return StartCoroutine(FadeIn(secondSprite));
            yield return StartCoroutine(FadeOut());
            yield return StartCoroutine(FadeIn(thirdSprite));
            yield return StartCoroutine(FadeOut());
            fadeStarted = false;
        }
    }

    private void showPowerUpState() 
    {
        if (CTF_GameManager.Instance.InLuckState && CTF_GameManager.Instance.InShieldState && !CTF_GameManager.Instance.InX2PointsState) 
        {
            if (CTF_GameManager.Instance.ShieldDuration > CTF_GameManager.Instance.LuckDuration)
            {
                StartCoroutine(PowerUpSequence(shield, luck));
            }
            else 
            {
                StartCoroutine(PowerUpSequence(luck, shield));
            }
        }
        else if (CTF_GameManager.Instance.InLuckState && CTF_GameManager.Instance.InX2PointsState && !CTF_GameManager.Instance.InShieldState) 
        {
            if (CTF_GameManager.Instance.LuckDuration > CTF_GameManager.Instance.Points2XDuration)
            {
                StartCoroutine(PowerUpSequence(luck, points2X));
            }
            else 
            {
                StartCoroutine(PowerUpSequence(points2X, luck));
            }
        }
        else if (CTF_GameManager.Instance.InX2PointsState && CTF_GameManager.Instance.InShieldState && !CTF_GameManager.Instance.InLuckState) 
        {
            if (CTF_GameManager.Instance.Points2XDuration > CTF_GameManager.Instance.ShieldDuration)
            {
                StartCoroutine(PowerUpSequence(points2X, shield));
            }
            else 
            {
                StartCoroutine(PowerUpSequence(shield, points2X));
            }
        }
        else if (CTF_GameManager.Instance.InLuckState && CTF_GameManager.Instance.InShieldState && CTF_GameManager.Instance.InX2PointsState) 
        {
            if (CTF_GameManager.Instance.Points2XDuration > CTF_GameManager.Instance.ShieldDuration && CTF_GameManager.Instance.Points2XDuration > CTF_GameManager.Instance.LuckDuration) 
            {
                StartCoroutine(PowerUpSequence(points2X, shield, luck));
            }
            else if (CTF_GameManager.Instance.LuckDuration > CTF_GameManager.Instance.ShieldDuration && CTF_GameManager.Instance.LuckDuration > CTF_GameManager.Instance.Points2XDuration) 
            {
                StartCoroutine(PowerUpSequence(luck, points2X, shield));
            }
            else if (CTF_GameManager.Instance.ShieldDuration > CTF_GameManager.Instance.LuckDuration && CTF_GameManager.Instance.ShieldDuration > CTF_GameManager.Instance.Points2XDuration) 
            {
                StartCoroutine(PowerUpSequence(shield, luck, points2X));
            }
        }
    }
}
