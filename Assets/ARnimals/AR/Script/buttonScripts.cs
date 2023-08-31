using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour
{

    bool showUI = true;

    public GameObject MainUI;
    public GameObject OptionsUI;
    public GameObject GalleryImgUI;
    public GameObject GalleryUI;
    public GameObject GalleryVidUI;

    public GameObject LeanTouchScript;
    private void Start()
    {
        OptionsUI.SetActive(false);
        GalleryVidUI.SetActive(false);
        GalleryImgUI.SetActive(false);
        GalleryUI.SetActive(false);
    }

    //return button
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void openOptions()
    {
        LeanTouchScript.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void closeOptions()
    {
        LeanTouchScript.SetActive(true);
        OptionsUI.SetActive(false);
    }

    public void showImgGallery()
    {
        GalleryUI.SetActive(false);
        GalleryImgUI.SetActive(true);
    }

    public void hideImgGallery()
    {
        GalleryImgUI.SetActive(false);
        GalleryUI.SetActive(true);
    }
    public void showVidGallery()
    {
        GalleryUI.SetActive(false);
        GalleryVidUI.SetActive(true);
    }

    public void hideVidGallery()
    {
        GalleryVidUI.SetActive(false);
        GalleryUI.SetActive(true);
    }

    public void showGallerySelectionUI()
    {
        GalleryVidUI.SetActive(false);
        GalleryImgUI.SetActive(false);
        GalleryUI.SetActive(true);
    }
    public void hideGallerySelectionUI()
    {
        GalleryUI.SetActive(false);
    }
    public void show_hide_UI()
    {
        if(showUI == true)
        {
            showUI = false;
            MainUI.SetActive(false);
        }else if(showUI == false)
        {
            showUI = true;
            MainUI.SetActive(true);
        }
    }
}
