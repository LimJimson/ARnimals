using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public GameObject[] hiddenObjects;  // Reference to the hidden objects
    public float hintHighlightDuration = 0.5f;  // How long to highlight the object
    public float hintScaleFactor = 1.2f;     // Scale factor for highlighting

    private int currentIndex = 0;
    private Vector3[] originalScales;  // To store original object scales

    private void Start()
    {
        // Initialize to the first hidden object
        HighlightObject(hiddenObjects[currentIndex]);
    }

    private void Awake()
    {
        originalScales = new Vector3[hiddenObjects.Length];
        for (int i = 0; i < hiddenObjects.Length; i++)
        {
            originalScales[i] = hiddenObjects[i].transform.localScale;
        }
    }

    public void ShowHint()
    {
        // Show a hint by highlighting the current hidden object
        UnhighlightObject(hiddenObjects[currentIndex]);
        currentIndex = (currentIndex + 1) % hiddenObjects.Length;  // Cycle through hidden objects
        HighlightObject(hiddenObjects[currentIndex]);
    }

    private void HighlightObject(GameObject obj)
    {
        // Scale up the object temporarily to indicate the hint
        obj.transform.localScale = originalScales[currentIndex] * hintScaleFactor;
    }

    private void UnhighlightObject(GameObject obj)
    {
        // Reset the object's scale to its original size
        obj.transform.localScale = originalScales[currentIndex];
    }
}