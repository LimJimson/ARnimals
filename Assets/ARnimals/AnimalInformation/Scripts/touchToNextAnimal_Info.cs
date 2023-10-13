using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchToNextAnimal_Info : MonoBehaviour, IPointerDownHandler
{
    SaveObject existingSO;
    public TMP_Text pageNum;
    public TMP_Text pageNum2;
    public TMP_Text pageNum3;
    public int pageCounter = 1;
    public animalInfoGuide _animalInfoGuideScript;
    public GameObject animalInfoGuide;

    public void OnPointerDown(PointerEventData eventData)
    {
        pageCounter++;
        _animalInfoGuideScript.guideVoiceOver();
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
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "1/13";
            pageNum2.text = "1/13";
            pageNum3.text = "1/13";
        }
        else if (pageCounter == 2)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "2/13";
            pageNum2.text = "2/13";
            pageNum3.text = "2/13";
        }
        else if (pageCounter == 3)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "3/13";
            pageNum2.text = "3/13";
            pageNum3.text = "3/13";
        }
        else if (pageCounter == 4)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "4/13";
            pageNum2.text = "4/13";
            pageNum3.text = "4/13";
        }
        else if (pageCounter == 5)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "5/13";
            pageNum2.text = "5/13";
            pageNum3.text = "5/13";
        }
        else if (pageCounter == 6)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "6/13";
            pageNum2.text = "6/13";
            pageNum3.text = "6/13";
        }
        else if (pageCounter == 7)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "7/13";
            pageNum2.text = "7/13";
            pageNum3.text = "7/13";
        }
        else if (pageCounter == 8)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "8/13";
            pageNum2.text = "8/13";
            pageNum3.text = "8/13";
        }
        else if (pageCounter == 9)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "9/13";
            pageNum2.text = "9/13";
            pageNum3.text = "9/13";
        }
        else if (pageCounter == 10)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "10/13";
            pageNum2.text = "10/13";
            pageNum3.text = "10/13";
        }
        else if (pageCounter == 11)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);

            pageNum.text = "11/13";
            pageNum2.text = "11/13";
            pageNum3.text = "11/13";
        }
        else if (pageCounter == 12)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "12/13";
            pageNum2.text = "12/13";
            pageNum3.text = "12/13";
        }
        else if (pageCounter == 13)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);

            pageNum.text = "13/13";
            pageNum2.text = "13/13";
            pageNum3.text = "13/13";
        }
        else
        {
            pageCounter = 1;
            pageNum.text = "1/13";
            _animalInfoGuideScript.stopGuideVoice();
            animalInfoGuide.SetActive(false);

            if (!existingSO.animalInfoGuide)
            {
                existingSO.animalInfoGuide = true;
                SaveManager.Save(existingSO);
            }
        }
    }
}
