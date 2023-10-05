using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickcontrol : MonoBehaviour,IPointerDownHandler
{
    public static string nameofobj;
    public GameObject objnametext;
    public Transform objnametextPos;
    public Transform successclick;

    public int randNum = 0;


    void Start()
    {
        
    }

    void Update()
    {
        if (hintmeter.hintused == "y")
        {
            randNum = Random.Range(1, 5);
            if ((gameObject.name == "leopard") && (randNum == 1))
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                hintmeter.hintused = "n";
            }
            if ((gameObject.name == "tiger") && (randNum == 2))
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                hintmeter.hintused = "n";
            }
            if ((gameObject.name == "zebra") && (randNum == 3))
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                hintmeter.hintused = "n";
            }
            if ((gameObject.name == "crocodile") && (randNum == 4))
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                hintmeter.hintused = "n";
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        nameofobj = gameObject.name;
        //Debug.Log (nameofobj);
        Destroy(gameObject);
        Destroy(objnametext);
        trackingclicks.totalclicks = 0;
        Instantiate(successclick, objnametextPos.position, successclick.rotation);
    }
}
