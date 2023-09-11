using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDownScript : MonoBehaviour
{
    
    public GameObject interactionsContainer;
    public float duration;
    public Transform pos1, pos2;

    bool isShown;

    public Sprite[] arrow;
    public Button dropBtn;
    private void Update()
    {
        if(!isShown)
        {
            dropBtn.image.sprite = arrow[0];
        }
        else
        {
            dropBtn.image.sprite = arrow[1];
        }
    }
    public void Move(){
        if (!isShown) { 
            LeanTween.moveY(interactionsContainer, pos1.position.y, duration);
            isShown = true;
        }
        else
        {
            LeanTween.moveY(interactionsContainer, pos2.position.y, duration);
            isShown = false;
        }
    }
}
