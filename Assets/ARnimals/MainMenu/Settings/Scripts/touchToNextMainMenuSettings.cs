using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchToNextMainMenuSettings : MonoBehaviour, IPointerDownHandler
{
    SaveObject existingSO;
    public MainMenuSettingsGuide _MainMenuSettingsGuideScript;
    public TMP_Text pageNum;
    public TMP_Text pageNum2;
    public int pageCounter = 1;
    public GameObject MainMenuSettingsGuideGO;
    public void OnPointerDown(PointerEventData eventData)
    {
        pageCounter++;
        _MainMenuSettingsGuideScript.guideVoiceOver();
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
            pageNum.text = "1/10";
            pageNum2.text = "1/10";
        }
        else if (pageCounter == 2)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "2/10";
            pageNum2.text = "2/10";
        }
        else if (pageCounter == 3)
        {
            pageNum.gameObject.SetActive(true);
            pageNum2.gameObject.SetActive(false);
            pageNum.text = "3/10";
            pageNum2.text = "3/10";
        }
        else if (pageCounter == 4)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "4/10";
            pageNum2.text = "4/10";
        }
        else if (pageCounter == 5)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "5/10";
            pageNum2.text = "5/10";
        }
        else if (pageCounter == 6)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "6/10";
            pageNum2.text = "6/10";
        }
        else if (pageCounter == 7)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "7/10";
            pageNum2.text = "7/10";
        }
        else if (pageCounter == 8)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "8/10";
            pageNum2.text = "8/10";
        }
        else if (pageCounter == 9)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "9/10";
            pageNum2.text = "9/10";
        }
        else if (pageCounter == 10)
        {
            pageNum.gameObject.SetActive(false);
            pageNum2.gameObject.SetActive(true);
            pageNum.text = "10/10";
            pageNum2.text = "10/10";
        }
        else
        {
            pageCounter = 1;
            pageNum.text = "1/10";

            MainMenuSettingsGuideGO.SetActive(false);
            _MainMenuSettingsGuideScript.returnBGMVol();
            _MainMenuSettingsGuideScript.stopGuideVoice();
            if (!existingSO.mainMenuSettingsGuide)
            {
                existingSO.mainMenuSettingsGuide = true;
                SaveManager.Save(existingSO);
            }
        }
    }
}
