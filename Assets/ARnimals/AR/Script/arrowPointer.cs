using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class arrowPointer : MonoBehaviour
{
    [SerializeField] private string targetTag = "ARMultiModel"; 
    [SerializeField] private Camera arCamera; 
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private GameObject Arrow;

    private GameObject targetObject;

    private void Start()
    {
        
    }

    private void Update()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null && arCamera != null)
        {

            Vector3 directionToTarget = targetObject.transform.position - transform.position;
            Arrow.transform.rotation = Quaternion.LookRotation(directionToTarget);

            float distance = Vector3.Distance(arCamera.transform.position, targetObject.transform.position);

            if (distanceText != null)
            {
                distanceText.text = $"{distance:F2}m";
            }
        }

    }
}
