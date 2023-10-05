using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class trackingclicks : MonoBehaviour,IPointerDownHandler
{
    public static int totalclicks = 0;
    public KeyCode mouseclick;

    public void OnPointerDown(PointerEventData eventData)
    {
        totalclicks += 1;
        if (totalclicks >= 5)
        {
            Debug.Log("FAIL!!!");
            totalclicks = 0;
        }
    }

    void Start()
    {
        
    }
}
