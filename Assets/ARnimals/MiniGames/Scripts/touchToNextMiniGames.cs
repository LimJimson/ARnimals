using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchToNextMiniGames : MonoBehaviour, IPointerDownHandler
{
    SaveObject existingSO;
    public TMP_Text pageNum;
    public TMP_Text pageNum2;
    public int pageCounter = 1;
    public GameObject miniGameSelectGuide;

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
            pageNum.text = "1/6";
            pageNum2.text = "1/6";
        }
        else if (pageCounter == 2)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "2/6";
            pageNum2.text = "2/6";
        }
        else if (pageCounter == 3)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "3/6";
            pageNum2.text = "3/6";
        }
        else if (pageCounter == 4)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "4/6";
            pageNum2.text = "4/6";
        }
        else if (pageCounter == 5)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "5/6";
            pageNum2.text = "5/6";
        }
        else if(pageCounter == 6)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "6/6";
            pageNum2.text = "6/6";
        }
        else
        {
            pageCounter = 1;
            miniGameSelectGuide.SetActive(false);
            if (!existingSO.MiniGamesTutorialDone)
            {
                existingSO.MiniGamesTutorialDone = true;
                SaveManager.Save(existingSO);
            }
        }
    }


}
