using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToNextASGuide : MonoBehaviour, IPointerDownHandler
{
    public int pageCounter = 1;
    public TMP_Text pageNum;
    public GameObject AnimalSelectGuide;
    public void OnPointerDown(PointerEventData eventData)
    {
        pageCounter++;
    }
    public void setPageCtr(int newCtr)
    {
        this.pageCounter = newCtr;
    }

    public void minusPageCtr()
    {
        pageCounter--;
    }

    // Update is called once per frame
    void Update()
    {

        if (pageCounter == 1)
        {
            pageNum.text = "1/6";
        }
        else if (pageCounter == 2)
        {
            pageNum.text = "2/6";
        }
        else if (pageCounter == 3)
        {
            pageNum.text = "3/6";
        }
        else if (pageCounter == 4)
        {
            pageNum.text = "4/6";
        }
        else if (pageCounter == 5)
        {
            pageNum.text = "5/6";
        }
        else if (pageCounter == 6)
        {
            pageNum.text = "6/6";
        }
        else
        {
            pageCounter = 1;
            AnimalSelectGuide.SetActive(false);
        }
    }
}
