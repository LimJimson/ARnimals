using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToNextASGuide : MonoBehaviour, IPointerDownHandler
{
    SaveObject existingSO;
    public TMP_Text pageNum;
    public TMP_Text pageNum2;
    public int pageCounter = 1;
    public GameObject animalSelectGuide;

    public GameObject animalName_txt;
    public GameObject selectAnimal_txt;
    public GameObject startBtnNoHighlight;
    public GameObject animalExampleNoHighlight;

    public void OnPointerDown(PointerEventData eventData)
    {
        pageCounter++;
    }

    void Start()
    {
        existingSO = SaveManager.Load();
    }

    public void setPageCtr(int newCtr)
    {
        this.pageCounter = newCtr;
    }

    public void minusPageCtr()
    {
        pageCounter--;
    }


    void Update()
    {
        if (pageCounter == 1)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "1/7";
            pageNum2.text = "1/7";
        }
        else if (pageCounter == 2)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "2/7";
            pageNum2.text = "2/7";
        }
        else if (pageCounter == 3)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "3/7";
            pageNum2.text = "3/7";
        }
        else if (pageCounter == 4)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "4/7";
            pageNum2.text = "4/7";
        }
        else if (pageCounter == 5)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "5/7";
            pageNum2.text = "5/7";
        }
        else if (pageCounter == 6)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "6/7";
            pageNum2.text = "6/7";
        }
        else if (pageCounter == 7)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "7/7";
            pageNum2.text = "7/7";
        }
        else
        {
            pageCounter = 1;
            animalSelectGuide.SetActive(false);
            animalName_txt.gameObject.SetActive(true);
            selectAnimal_txt.gameObject.SetActive(true);
            startBtnNoHighlight.gameObject.SetActive(false);
            animalExampleNoHighlight.gameObject.SetActive(false);

            if (!existingSO.AnimalSelectTutorialDone)
            {
                existingSO.AnimalSelectTutorialDone = true;
                SaveManager.Save(existingSO);
            }
        }
    }
}
