using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeScreenshot : MonoBehaviour {

	public GameObject AR_UI;
	public TMP_Text text;
    public bool takingScreenshot = false;
    public void TakeAShot()
	{
        try
        {
            StopAllCoroutines();
            StartCoroutine(TakeScreenshotAndSave());
        }
        catch
        {

        }
	}
    private IEnumerator TakeScreenshotAndSave()
    {
        arrow3d.SetActive(false);
        AR_UI.SetActive(false);
        pnlImgCameraTxt.gameObject.SetActive(true);
        takingScreenshot = true;
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_Capture_{1}.png", Application.productName, System.DateTime.Now.ToString("yyyy -MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + "Captures/ARExperience", name));
        takingScreenshot = false;
        AR_UI.SetActive(true);
        arrow3d.SetActive(true);
        text.text = "Screenshot saved to <color=#FFFF00>Gallery</color>!";

        yield return new WaitForSeconds(2f);
        text.text = "";
        pnlImgCameraTxt.gameObject.SetActive(false);
        StopAllCoroutines();
    }


    public GameObject arrow3d;
    public GameObject pnlImgCameraTxt;
    private void Update()
    {
        countdownSS();
    }


    public TMP_Text timerSSTxt;
    bool isSSTimerCounting = false;
    float countdownTime = 3.0f;
    public Button screenShotBtn;

    void countdownSS()
    {
        if (isSSTimerCounting)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 3.0f;
                isSSTimerCounting = false;
                timerSSTxt.gameObject.SetActive(false);
                screenShotBtn.interactable = true;

            }

            UpdateTimerText();
        }
    }

    public void StartCountdown()
    {
        isSSTimerCounting = true;
        countdownSS();
        timerSSTxt.gameObject.SetActive(true);
        screenShotBtn.interactable = false;

    }
    private void UpdateTimerText()
    {
        timerSSTxt.text = Convert.ToInt16(countdownTime).ToString();
    }
}
