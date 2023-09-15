using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	public GameObject AR_UI;
	public TMP_Text text;
    public bool takingScreenshot = false;
    public void TakeAShot()
	{
        try
        {
            StartCoroutine(TakeScreenshotAndSave());
        }
        catch
        {

        }
	}

	//IEnumerator CaptureIt()
	//{
	//	AR_UI.SetActive (false);
	//	string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
	//	string fileName = "ARnimals_SS_" + timeStamp + ".png";
	//	string pathToSave = fileName;

	//	ScreenCapture.CaptureScreenshot(pathToSave);
	//	yield return new WaitForEndOfFrame();
 //       AR_UI.SetActive(true);
	//	text.text = "Screenshot saved to Gallery!";

	//	yield return new WaitForSeconds(2f);
	//	text.text = "";
 //   }
    private IEnumerator TakeScreenshotAndSave()
    {
            AR_UI.SetActive(false);
            takingScreenshot = true;
            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            // Save the screenshot to Gallery/Photos
            string name = string.Format("{0}_Capture_{1}.png", Application.productName ,System.DateTime.Now.ToString("yyyy -MM-dd_HH-mm-ss"));
            Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
            takingScreenshot = false;
            AR_UI.SetActive(true);
            text.text = "Screenshot saved to Gallery!";

            yield return new WaitForSeconds(2f);
            text.text = "";
        StopAllCoroutines();
    }
}
