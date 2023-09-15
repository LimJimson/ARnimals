using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public RectTransform gamePad;
    public float moveSpeed = 0.5f;

    GameObject arObject;
    Vector3 move;

    bool walking;

    void Awake()
    {
        arObject = GameObject.FindGameObjectWithTag("ARMultiModel");
    }

    void Update()
    {
        if (arObject == null)
        {
            arObject = GameObject.FindGameObjectWithTag("ARMultiModel");
        }

    }


    //Gamepad Logic

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        move = gamePad.rotation * new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized;

            if (!walking)
            {
                walking = true;
                arObject.GetComponent<Animator>().SetBool("Walk", true);

            }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(AnimalMovemnt());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;

        StopAllCoroutines();
        walking = false;

        try
        {
            arObject.GetComponent<Animator>().SetBool("Walk", false);
        }
        catch
        {

        }
    }
    
    IEnumerator AnimalMovemnt()
    {
        while (true)
        {
            
            arObject.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if (move != Vector3.zero)
                arObject.transform.rotation = Quaternion.Slerp(arObject.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5.0f);

            yield return null;
        }
    }


}
