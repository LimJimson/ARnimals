using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToNextMainMenu : MonoBehaviour, IPointerDownHandler
{
    public TMP_Text pageNum;
    public int pageCounter = 1;
    public GameObject main_menu_guide;
    public GameObject firstStartTxt;

    public GameObject origHelpBtn;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (pageCounter == 0)
        {
            firstStartTxt.SetActive(false);
            pageCounter++;
        }
        else
        {
            pageCounter++;
        }
    }
    public void setPageCtr(int newCtr)
    {
        this.pageCounter = newCtr;
    }

    public void minusCtr()
    {
        this.pageCounter--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pageCounter == 0)
        {
            pageNum.text = "";
        }
        else if (pageCounter == 1)
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
            origHelpBtn.SetActive(false);
            pageNum.text = "6/6";
        }
        else
        {
            pageCounter = 1;
            origHelpBtn.SetActive(true);
            main_menu_guide.SetActive(false);
        }
    }

}
