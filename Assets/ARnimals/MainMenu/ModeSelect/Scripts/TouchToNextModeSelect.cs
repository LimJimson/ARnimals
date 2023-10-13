using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToNextModeSelect : MonoBehaviour,IPointerDownHandler
{
    SaveObject existingSO;
    public TMP_Text pageNum;
    public int pageCounter = 1;
    public GameObject mode_select_guide;

    public ModeSelectGuide modeSelectGuideScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        pageCounter++;
        modeSelectGuideScript.guideVoiceOver();
    }

    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
        if (pageCounter == 1)
        {
            pageNum.text = "1/5";
        }
        else if (pageCounter == 2)
        {
            pageNum.text = "2/5";
        }
        else if (pageCounter == 3)
        {
            pageNum.text = "3/5";
        }
        else if (pageCounter == 4)
        {
            pageNum.text = "4/5";
        }
        else if (pageCounter == 5)
        {
            pageNum.text = "5/5";
        }
        else
        {
            pageCounter = 1;
            mode_select_guide.SetActive(false);
            modeSelectGuideScript.stopGuideVoice();
            if (!existingSO.ModeSelectTutorialDone)
            {
                existingSO.ModeSelectTutorialDone = true;
                SaveManager.Save(existingSO);
            }
        }
    }
}
