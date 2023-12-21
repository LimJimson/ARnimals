using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_Gallery : MonoBehaviour
{
    [SerializeField]
    GameObject Image;
    public TMP_Text imgCounter;
    string[] files = null;
    Sprite defaultImage;
    public TMP_Text errorTxtNoImg;
    public TMP_Text errorTxtDelImg;
    public Button deleteBtn;
    int whichScreenShotIsShown = 0;

    public TMP_Text fileNameImgTxt;


    public GameObject ImgGallery;

    void Start()
    {
        errorTxtNoImg.gameObject.SetActive(false);
        errorTxtDelImg.gameObject.SetActive(false);

        getPicture();
    }

    public void getPicture()
    {
        try
        {
#if UNITY_ANDROID && !UNITY_EDITOR
                    files = Directory.GetFiles("/storage/emulated/0/DCIM/" + Application.productName + "CTFCaptures", "*.png");
                    if (files.Length > 0)
                    {
                        imgCounter.gameObject.SetActive(true);
                        Image.gameObject.SetActive(true);  
                        fileNameImgTxt.gameObject.SetActive(true);
                        GetPictureAndShowIt();
                    }
                    else if (files.Length == 0)
                    {
                        imgCounter.gameObject.SetActive(false);
                        Image.gameObject.SetActive(false);
                        fileNameImgTxt.gameObject.SetActive(false);
                    }
#endif

        }
        catch
        {
            Debug.Log("No Folder Found! CTFCaptures");
        }

    }
    string ImgFileName;
    void GetPictureAndShowIt()
    {
        ImgFileName = Path.GetFileName(files[whichScreenShotIsShown]);
        fileNameImgTxt.text = ImgFileName;
        string pathToFile = files[whichScreenShotIsShown];
        imgCounter.text = whichScreenShotIsShown + 1 + "/" + files.Length;
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        Image.GetComponent<Image>().sprite = sp;
    }

    Texture2D GetScreenshotImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public void DeleteImage()
    {
        string galleryPath = "/storage/emulated/0/DCIM/" + Application.productName + "CTFCaptures/";
        if (files.Length > 0)
        {
            StartCoroutine(showTextDelImg());
            string pathToFile = files[whichScreenShotIsShown];
            if (File.Exists(pathToFile))
                File.Delete(pathToFile);
            files = Directory.GetFiles("/storage/emulated/0/DCIM/" + Application.productName + "CTFCaptures", "*.png");
            if (files.Length > 0)
                NextPicture();
            else
                getPicture();
        }
        else if (files.Length <= 0)
        {
            StartCoroutine(showTextNoImg());
        }
        whichScreenShotIsShown = 0;
        getPicture();

        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        mediaScanner.CallStatic("scanFile", currentActivity, new string[] { galleryPath }, null, null);
    }

    IEnumerator showTextNoImg()
    {
        deleteBtn.interactable = false;
        errorTxtNoImg.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        errorTxtNoImg.gameObject.SetActive(false);
        deleteBtn.interactable = true;
    }
    IEnumerator showTextDelImg()
    {
        deleteBtn.interactable = false;
        errorTxtDelImg.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        errorTxtDelImg.gameObject.SetActive(false);
        deleteBtn.interactable = true;
    }
    public void NextPicture()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShown += 1;
            if (whichScreenShotIsShown > files.Length - 1)
                whichScreenShotIsShown = 0;
            GetPictureAndShowIt();
        }
        else if (files.Length == 0)
        {
            Image.gameObject.SetActive(false);
        }
    }

    public void PreviousPicture()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShown -= 1;
            if (whichScreenShotIsShown < 0)
                whichScreenShotIsShown = files.Length - 1;
            GetPictureAndShowIt();
        }
        else if (files.Length == 0)
        {
            Image.gameObject.SetActive(false);
        }
    }

    public void hideImgGallery()
    {
        ImgGallery.SetActive(false);
    }


    public void showImgGallery()
    {
        getPicture();
        ImgGallery.SetActive(true);
    }
}
