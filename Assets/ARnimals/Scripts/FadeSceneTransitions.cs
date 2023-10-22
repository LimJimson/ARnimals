using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeSceneTransitions : MonoBehaviour
{
    [SerializeField] private Image fadePanel;
    [SerializeField] private float fadeDuration = 0.3f;
    [SerializeField] private Image blackPanelImg;
    [SerializeField] private float blackPanelDuration;

    private void Start() 
    {

        if (blackPanelImg != null) 
        {
            StartCoroutine(FadeIn(blackPanelImg, blackPanelDuration));
        }
        else 
        {
            StartCoroutine(FadeIn());
        }
    }
    
    public IEnumerator FadeIn()
    {
        fadePanel.gameObject.SetActive(true);
        Color currentColor = fadePanel.color;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = 1 - (currentTime / fadeDuration);
        // Deactivate the fadeImage when the fade-in is complete
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        fadePanel.gameObject.SetActive(false);
    }

    public IEnumerator FadeIn(Image blackPanel, float delay)
    {
        blackPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);

        blackPanel.gameObject.SetActive(false);

        fadePanel.gameObject.SetActive(true);
        Color currentColor = fadePanel.color;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = 1 - (currentTime / fadeDuration);
        // Deactivate the fadeImage when the fade-in is complete
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        fadePanel.gameObject.SetActive(false);
    }

    public void LoadNextScene(string sceneName)
    {
        // Use this function to load the next scene with a fade-in transition
        StartCoroutine(FadeOut(sceneName));
    }

    public IEnumerator FadeOut(string sceneName)
    {
        fadePanel.gameObject.SetActive(true);
        Color currentColor = fadePanel.color;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = currentTime / fadeDuration;
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        // Load the next scene
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public IEnumerator FadeOut(GameObject closeGameObject, GameObject openGameObject)
    {
        fadePanel.gameObject.SetActive(true);
        Color currentColor = fadePanel.color;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float alpha = currentTime / fadeDuration;
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        closeGameObject.SetActive(false);
        openGameObject.SetActive(true);

        Time.timeScale = 1f;
    }    
}
