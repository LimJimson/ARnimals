using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class GuidePopUpAnimation : MonoBehaviour
{

    [SerializeField] private float moveDuration = 0.3f;
    [SerializeField] private Vector2 startPosition = new Vector2(-123.86f, -1216f);
    [SerializeField] private Vector2 endPosition= new Vector2(-123.86f, -71.802f);

    //===================ShowGuidePopUp Methods========================

    public void showGuidePopUp(RectTransform rectTransform, GameObject toEnable) 
    {
        StartCoroutine(guidePopUp(rectTransform, toEnable));
    }

    public void showGuidePopUp(RectTransform rectTransform, GameObject toEnable, GameObject toDisable) 
    {
        StartCoroutine(guidePopUp(rectTransform, toEnable, toDisable));
    }

    //=================HideGuidePopUp Methods==========================

    public void hideGuidePopUp(RectTransform rectTransform, GameObject toDisable) 
    {
        StartCoroutine(guidePopUpHide(rectTransform, toDisable));
    }

    public void hideGuidePopUp(RectTransform rectTransform, GameObject toDisable, GameObject toEnable) 
    {
        StartCoroutine(guidePopUpHide(rectTransform, toDisable, toEnable));
    }

    public void hideGuidePopUp(string code, RectTransform rectTransform, GameObject toDisable, GameObject[] toEnable) 
    {
        StartCoroutine(guidePopUpHide(code, rectTransform, toDisable, toEnable));
    }

    //====================IEnumerators===========================

    private IEnumerator guidePopUp(RectTransform rectTransform, GameObject toEnable, GameObject toDisable)
    {
        float currentTime = 0f;

        toEnable.SetActive(true);
        toDisable.SetActive(false);

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition;
    }
    private IEnumerator guidePopUp(RectTransform rectTransform, GameObject toEnable)
    {
        float currentTime = 0f;

        toEnable.SetActive(true);

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition;
    }

    private IEnumerator guidePopUpHide(RectTransform rectTransform, GameObject toDisable)
    {
        float currentTime = 0f;

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t);
            yield return null;
        }

        toDisable.SetActive(false);

        rectTransform.anchoredPosition = endPosition;
    }

    private IEnumerator guidePopUpHide(RectTransform rectTransform, GameObject toDisable, GameObject toEnable)
    {
        float currentTime = 0f;

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t);
            yield return null;
        }

        toDisable.SetActive(false);
        toEnable.SetActive(true);

        rectTransform.anchoredPosition = endPosition;
    }

    private IEnumerator guidePopUpHide(string confirmQuitCode, RectTransform rectTransform, GameObject toDisable, GameObject[] toEnable)
    {
        float currentTime = 0f;

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t);
            yield return null;
        }

        toDisable.SetActive(false);
        
        switch(confirmQuitCode)
        {
            case "OptionsUI":
                toEnable[0].SetActive(true);
                break;
            case "GameOverUI":
                toEnable[1].SetActive(true);
                break;
            case "LevelCompleteUI":
                toEnable[2].SetActive(true);
                break;
        }  

        rectTransform.anchoredPosition = endPosition;
    }
}
