using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animalInfoBook : MonoBehaviour
{

    int animalIndex;
    public AnimalInfoScript _animalInfoScript;
    public GameObject _AnimalInfoCanvas;

    void Start()
    {
        
    }

    public Image animalImg;
    public TMP_Text animalNameTxt;
    public TMP_Text animalClassficicationTxt;

    public TMP_Text animalHabitat1Txt;
    public Image animalHabitat1Img;
    public TMP_Text animalHabitat2Txt;
    public Image animalHabitat2Img;
    public TMP_Text animalHabitat3Txt;
    public Image animalHabitat3Img;

    public Sprite[] animalImgContainer;
    public string[] animalNameContainer;
    public string[] animalClassification;
    public string[] animalHabitatTxt;
    public Sprite[] animalHabitat;


    List<int> Mammals = new List<int> {5, 6, 7, 14, 1, 4, 9, 2, 3, 12};
    List<int> Crustacean = new List<int> { 19};
    List<int> Reptile = new List<int> { 0 };
    List<int> Bird = new List<int> { 8, 11, 10, 13, };
    List<int> Fish = new List<int> {18, 16, 15};
    List<int> Mollusk = new List<int> { 17};

    public void showAnimalInfo()
    {

        _showAnimalInfo();
        _AnimalInfoCanvas.SetActive(true);
        
    }
    public void hideAnimalInfo()
    {
        _AnimalInfoCanvas.SetActive(false);
    }
    public GameObject speakerBtn;
    public void _showAnimalInfo()
    {
        speakerBtn.SetActive(true);
        animalIndex = _animalInfoScript.chosenAnimalIndex;
        animalHabitat1Img.gameObject.SetActive(true);
        animalHabitat1Txt.gameObject.SetActive(true);
        animalHabitat2Img.gameObject.SetActive(true);
        animalHabitat2Txt.gameObject.SetActive(true);
        animalHabitat3Img.gameObject.SetActive(false);
        animalHabitat3Txt.gameObject.SetActive(false);
        animalImg.sprite = animalImgContainer[animalIndex];
        animalNameTxt.text = animalNameContainer[animalIndex];

        if (Mammals.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[0];
        }
        else if (Crustacean.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[1];
        }
        else if (Reptile.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[2];
        }
        else if (Bird.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[3];
        }
        else if (Fish.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[4];
        }
        else if (Mollusk.Contains(animalIndex))
        {
            animalClassficicationTxt.text = animalClassification[5];
        }

        switch (animalIndex)
        {
            case 0:
                animalHabitat1Img.sprite = animalHabitat[3];
                animalHabitat1Txt.text = animalHabitatTxt[3];
                animalHabitat2Img.sprite = animalHabitat[4];
                animalHabitat2Txt.text = animalHabitatTxt[4];
                break;

            case 1:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[3];
                animalHabitat2Txt.text = animalHabitatTxt[3];
                break;

            case 2:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[1];
                animalHabitat2Txt.text = animalHabitatTxt[1];
                break;

            case 3:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[0];
                animalHabitat3Txt.text = animalHabitatTxt[0];
                break;

            case 4:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[0];
                animalHabitat3Txt.text = animalHabitatTxt[0];
                break;

            case 5:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[1];
                animalHabitat2Txt.text = animalHabitatTxt[1];
                break;

            case 6:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[6];
                animalHabitat2Txt.text = animalHabitatTxt[6];
                break;

            case 7:
                animalHabitat1Img.sprite = animalHabitat[3];
                animalHabitat1Txt.text = animalHabitatTxt[3];
                animalHabitat2Img.sprite = animalHabitat[7];
                animalHabitat2Txt.text = animalHabitatTxt[7];
                break;

            case 8:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[4];
                animalHabitat2Txt.text = animalHabitatTxt[4];
                break;

            case 9:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[3];
                animalHabitat2Txt.text = animalHabitatTxt[3];
                break;

            case 10:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[0];
                animalHabitat3Txt.text = animalHabitatTxt[0];
                break;

            case 11:
                animalHabitat1Img.sprite = animalHabitat[0];
                animalHabitat1Txt.text = animalHabitatTxt[0];
                animalHabitat2Img.sprite = animalHabitat[11];
                animalHabitat2Txt.text = animalHabitatTxt[11];
                break;

            case 12:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[3];
                animalHabitat3Txt.text = animalHabitatTxt[3];
                break;

            case 13:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[10];
                animalHabitat3Txt.text = animalHabitatTxt[10];
                break;

            case 14:
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[0];
                animalHabitat3Txt.text = animalHabitatTxt[0];
                break;

            case 15:
                speakerBtn.SetActive(false);
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[9];
                animalHabitat3Txt.text = animalHabitatTxt[9];
                
                break;

            case 16:
                speakerBtn.SetActive(false);
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[2];
                animalHabitat3Txt.text = animalHabitatTxt[2];
                
                break;

            case 17:
                speakerBtn.SetActive(false);
                animalHabitat1Img.sprite = animalHabitat[2];
                animalHabitat1Txt.text = animalHabitatTxt[2];
                animalHabitat2Img.sprite = animalHabitat[5];
                animalHabitat2Txt.text = animalHabitatTxt[5];
                
                break;

            case 18:
                speakerBtn.SetActive(false);
                animalHabitat1Img.gameObject.SetActive(false);
                animalHabitat1Txt.gameObject.SetActive(false);
                animalHabitat2Img.gameObject.SetActive(false);
                animalHabitat2Txt.gameObject.SetActive(false);
                animalHabitat3Img.gameObject.SetActive(true);
                animalHabitat3Txt.gameObject.SetActive(true);
                animalHabitat3Img.sprite = animalHabitat[8];
                animalHabitat3Txt.text = animalHabitatTxt[8];
                
                break;

            case 19:
                speakerBtn.SetActive(false);
                animalHabitat1Img.sprite = animalHabitat[2];
                animalHabitat1Txt.text = animalHabitatTxt[2];
                animalHabitat2Img.sprite = animalHabitat[5];
                animalHabitat2Txt.text = animalHabitatTxt[5];
                break;
        }
    }
}
