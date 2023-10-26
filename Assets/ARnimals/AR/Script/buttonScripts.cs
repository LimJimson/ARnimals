using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonScripts : MonoBehaviour
{

    bool showUI = true;
    public ARPlacement ARPlacementScript;
    public showHabitat _showHabitatScript;
    public GameObject MainUI;
    public GameObject OptionsUI;
    public GameObject GalleryImgUI;
    public GameObject GalleryUI;
    public GameObject GalleryVidUI;

    public GameObject LeanTouchScript;
    public GameObject noteCanvas;

    public Animator continueBtnNoteAnim;
    public Button continueBtnNote;

    public GameObject animalBook;

    AudioManager audioManager;

    public checkCamera _checkCamScript;

    private void Start()
    {
        try { audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); } catch { }
        OptionsUI.SetActive(false);
        GalleryVidUI.SetActive(false);
        GalleryImgUI.SetActive(false);
        GalleryUI.SetActive(false);
        noteCanvas.SetActive(true);
        continueBtnNote.interactable = false;
        StartCoroutine(WaitForAnimation());
    }

    
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator WaitForAnimation()
    {

        // Wait for the animation to finish
        float animationDuration = continueBtnNoteAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(animationDuration);

        // Enable the button after the animation is complete
        continueBtnNote.interactable = true;
        StopAllCoroutines();
    }


    public void showAnimalInfo()
    {
        animalBook.SetActive(true);
    }
    public void hideAnimalInfo()
    {
        animalBook.SetActive(false);
    }
    public void hideNote()
    {
        noteCanvas.SetActive(false);
        _checkCamScript.enabled = true;
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
    public void returnToAnimalSelectBTN()
    {
        try { audioManager.guideSource.Stop(); }catch { }
        SceneManager.LoadScene("Animal Selector AR");
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

    public RenderTexture renderTextureVid;
    public void showVidGallery()
    {
        GalleryUI.SetActive(false);
        renderTextureVid.Release();
        GalleryVidUI.SetActive(true);
    }

    public void hideVidGallery()
    {
        GalleryVidUI.SetActive(false);
        GalleryUI.SetActive(true);
        _showHabitatScript.unPauseMainBGM();
    }

    public void showGallerySelectionUI()
    {
        GalleryVidUI.SetActive(false);
        GalleryImgUI.SetActive(false);
        GalleryUI.SetActive(true);
        ARPlacementScript.resetTimerSpawnAnimal();
        _checkCamScript.enabled = true;
    }
    public void hideGallerySelectionUI()
    {
        GalleryUI.SetActive(false);
        _checkCamScript.enabled = false;
        _showHabitatScript.playEnvironmentBGM();
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
