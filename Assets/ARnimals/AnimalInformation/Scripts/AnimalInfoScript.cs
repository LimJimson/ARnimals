using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimalInfoScript : MonoBehaviour
{
    public Sprite[] animalImgsSprite;
    public string[] animalNames;
    public VideoClip[] animalVids;
    public Sprite[] play_pauseSprite;

    public RenderTexture vidRenderTexture;
    public GameObject MainCanvas,AnimalInfoCanvas;
    public Image play_pauseBtn;
    public VideoPlayer animalVidPlayer;
    public Image animalImg;
    public TMP_Text animalNameTxt;
    int chosenAnimalIndex;
    bool isExploreBtnClicked;
    private void Start()
    {
        isExploreBtnClicked = StateNameController.isGTSExploreClicked;
        checkIfGTS_ExploreBtnClicked();
    }
    private void OnDisable()
    {
        StateNameController.isGTSExploreClicked = false;
    }
    void checkIfGTS_ExploreBtnClicked()
    {
        if (isExploreBtnClicked)
        {
            selectedAnimal(StateNameController.failedAnimal);
        }
    }
    public void selectedAnimal(int animalIndex)
    {
        this.chosenAnimalIndex = animalIndex;
        showAnimalInfo();
    }
    public void play_pauseVid()
    {
        play_pauseBtn.sprite = play_pauseSprite[0];
        if (animalVidPlayer.isPlaying)
        {
            play_pauseBtn.sprite = play_pauseSprite[0];
            animalVidPlayer.Pause();
        }
        else
        {
            play_pauseBtn.sprite = play_pauseSprite[1];
            animalVidPlayer.Play();
        }
    }

    public void goToAnimalInfoSelect()
    {
        MainCanvas.SetActive(true);
        AnimalInfoCanvas.SetActive(false);
        vidRenderTexture.Release();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void showAnimalInfo()
    {
        MainCanvas.SetActive(false);
        play_pauseBtn.sprite = play_pauseSprite[1];
        switch(chosenAnimalIndex)
        {
            case 0: //croc
                animalImg.sprite = animalImgsSprite[0];
                animalNameTxt.text = animalNames[0];
                animalVidPlayer.clip = animalVids[0];
                break;
            case 1: // elephant
                animalImg.sprite = animalImgsSprite[1];
                animalNameTxt.text = animalNames[1];
                animalVidPlayer.clip = animalVids[1];

                break;
            case 2: //tiger
                animalImg.sprite = animalImgsSprite[2];
                animalNameTxt.text = animalNames[2];
                animalVidPlayer.clip = animalVids[2];
                break;
            case 3://zebra
                animalImg.sprite = animalImgsSprite[3];
                animalNameTxt.text = animalNames[3];
                animalVidPlayer.clip = animalVids[3];
                break;
            case 4: //horse
                animalImg.sprite = animalImgsSprite[4];
                animalNameTxt.text = animalNames[4];
                animalVidPlayer.clip = animalVids[4];
                break;
            case 5: //bat
                animalImg.sprite = animalImgsSprite[5];
                animalNameTxt.text = animalNames[5];
                animalVidPlayer.clip = animalVids[5];
                break;
            case 6: //bear
                animalImg.sprite = animalImgsSprite[6];
                animalNameTxt.text = animalNames[6];
                animalVidPlayer.clip = animalVids[6];
                break;
            case 7: //camel
                animalImg.sprite = animalImgsSprite[7];
                animalNameTxt.text = animalNames[7];
                animalVidPlayer.clip = animalVids[7];
                break;
            case 8: //duck
                animalImg.sprite = animalImgsSprite[8];
                animalNameTxt.text = animalNames[8];
                animalVidPlayer.clip = animalVids[8];
                break;
            case 9: //leopard
                animalImg.sprite = animalImgsSprite[9];
                animalNameTxt.text = animalNames[9];
                animalVidPlayer.clip = animalVids[9];
                break;
            case 10://owl
                animalImg.sprite = animalImgsSprite[10];
                animalNameTxt.text = animalNames[10];
                animalVidPlayer.clip = animalVids[10];
                break;
            case 11://pigeon
                animalImg.sprite = animalImgsSprite[11];
                animalNameTxt.text = animalNames[11];
                animalVidPlayer.clip = animalVids[11];
                break;
            case 12: //rhinoceros
                animalImg.sprite = animalImgsSprite[12];
                animalNameTxt.text = animalNames[12];
                animalVidPlayer.clip = animalVids[12];
                break;
            case 13: //seagull
                animalImg.sprite = animalImgsSprite[13];
                animalNameTxt.text = animalNames[13];
                animalVidPlayer.clip = animalVids[13];
                break;
            case 14://deer
                animalImg.sprite = animalImgsSprite[14];
                animalNameTxt.text = animalNames[14];
                animalVidPlayer.clip = animalVids[14];
                break;
            case 15://piranha
                animalImg.sprite = animalImgsSprite[15];
                animalNameTxt.text = animalNames[15];
                animalVidPlayer.clip = animalVids[15];
                break;
            case 16://shark
                animalImg.sprite = animalImgsSprite[16];
                animalNameTxt.text = animalNames[16];
                animalVidPlayer.clip = animalVids[16];
                break;
            case 17://octopus
                animalImg.sprite = animalImgsSprite[17];
                animalNameTxt.text = animalNames[17];
                animalVidPlayer.clip = animalVids[17];
                break;
            case 18://koi
                animalImg.sprite = animalImgsSprite[18];
                animalNameTxt.text = animalNames[18];
                animalVidPlayer.clip = animalVids[18];
                break;
            case 19://crab
                animalImg.sprite = animalImgsSprite[19];
                animalNameTxt.text = animalNames[19];
                animalVidPlayer.clip = animalVids[19];
                break;
        }
        AnimalInfoCanvas.SetActive(true);
    }
}
