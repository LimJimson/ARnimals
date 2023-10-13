using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchToNextAR : MonoBehaviour, IPointerDownHandler
{
    SaveObject existingSO;

    public AR_Guide _ARGuideScript;

    public TMP_Text pageNum;
    public TMP_Text pageNum2;
    public TMP_Text pageNum3;
    public int pageCounter = 1;
    public GameObject ARGuideGO;
    void Start()
    {
        existingSO = SaveManager.Load();
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (pageCounter != 2)
        {
            pageCounter++;
            _ARGuideScript.guideVoiceOver();
        }


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
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "1/17";
            pageNum2.text = "1/17";
            pageNum3.text = "1/17";
        }
        else if (pageCounter == 2)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "2/17";
            pageNum2.text = "2/17";
            pageNum3.text = "2/17";

            
        }
        else if (pageCounter == 3)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "3/17";
            pageNum2.text = "3/17";
            pageNum3.text = "3/17";
        }
        else if (pageCounter == 4)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "4/17";
            pageNum2.text = "4/17";
            pageNum3.text = "4/17";
        }
        else if (pageCounter == 5)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(true);
            pageNum.text = "5/17";
            pageNum2.text = "5/17";
            pageNum3.text = "5/17";
        }
        else if (pageCounter == 6)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "6/17";
            pageNum2.text = "6/17";
            pageNum3.text = "6/17";
        }
        else if (pageCounter == 7)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "7/17";
            pageNum2.text = "7/17";
            pageNum3.text = "7/17";
        }
        else if (pageCounter == 8)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "8/17";
            pageNum2.text = "8/17";
            pageNum3.text = "8/17";
        }
        else if (pageCounter == 9)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "9/17";
            pageNum2.text = "9/17";
            pageNum3.text = "9/17";
        }
        else if (pageCounter == 10)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "10/17";
            pageNum2.text = "10/17";
            pageNum3.text = "10/17";
        }
        else if (pageCounter == 11)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "11/17";
            pageNum2.text = "11/17";
            pageNum3.text = "11/17";
        }
        else if (pageCounter == 12)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "12/17";
            pageNum2.text = "12/17";
            pageNum3.text = "12/17";
        }
        else if (pageCounter == 13)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "13/17";
            pageNum2.text = "13/17";
            pageNum3.text = "13/17";
        }
        else if (pageCounter == 14)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "14/17";
            pageNum2.text = "14/17";
            pageNum3.text = "14/17";
        }
        else if (pageCounter == 15)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "15/17";
            pageNum2.text = "15/17";
            pageNum3.text = "15/17";
        }
        else if (pageCounter == 16)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "16/17";
            pageNum2.text = "16/17";
            pageNum3.text = "16/17";
        }
        else if (pageCounter == 17)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum3.gameObject.SetActive(false);
            pageNum.text = "17/17";
            pageNum2.text = "17/17";
            pageNum3.text = "17/17";
        }
        else
        {
            pageCounter = 1;
            pageNum.text = "1/17";

            ARGuideGO.SetActive(false);
            _ARGuideScript.stopGuideVoice();

            if (!existingSO.ARExpTutorialDone)
            {
                existingSO.ARExpTutorialDone = true;
                SaveManager.Save(existingSO);
            }
        }
    }
}

