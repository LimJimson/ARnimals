using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;

public class TakeScreenShot : MonoBehaviour
{
    public string fileName = "", albumName = "";
    bool isScreenShotSave;
    public bool isScreenShotWithDateTime;
    public TMP_Text _txt;
    public CanvasGroup uiToHide;

    public void OnButtonClick()
    {
        uiToHide.alpha = 0;

        StartCoroutine(ScreenShotBridge.SaveScreenShot(fileName, albumName, isScreenShotWithDateTime, ScreenShotStatus));
        StartCoroutine(TakeScreenShotAndShowUI());
    }

    void ScreenShotStatus(bool status)
    {
        isScreenShotSave = status;

        if (status)
        {
            // Reload the gallery to show the new screenshot
#if UNITY_ANDROID
            using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaClass mediaScannerClass = new AndroidJavaClass("android.media.MediaScannerConnection");
                mediaScannerClass.CallStatic("scanFile", unityActivity, new string[] { Application.persistentDataPath + "/" + fileName }, null, null);
            }
#endif
        }
    }

    IEnumerator TakeScreenShotAndShowUI()
    {

        //while (!isScreenShotSave)
        //{
        //    yield return null;
        //}
        yield return new WaitForSeconds(1f);
        _txt.text = "Screenshot Saved to Gallery!";
        uiToHide.alpha = 1;
        yield return new WaitForSeconds(1f);
        _txt.text = "";

        isScreenShotSave = false;
    }
}
