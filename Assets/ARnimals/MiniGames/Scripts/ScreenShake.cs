using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;  // Duration of the shake animation
    public float shakeIntensity = 10f;  // Intensity of the shake effect

    private Vector2 originalAnchoredPosition;
    private RectTransform canvasRectTransform;

    private void Start()
    {
        // Get the reference to the RectTransform component of the canvas
        canvasRectTransform = GetComponent<RectTransform>();
        // Store the original anchored position of the canvas
        originalAnchoredPosition = canvasRectTransform.anchoredPosition;
    }

    public void ShakeCanvas()
    {
        StartCoroutine(ShakeAnimation());
    }

    private IEnumerator ShakeAnimation()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Generate a random offset within the specified intensity
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            float offsetY = Random.Range(-1f, 1f) * shakeIntensity;
            Vector2 offset = new Vector2(offsetX, offsetY);

            // Apply the offset to the canvas anchored position
            canvasRectTransform.anchoredPosition = originalAnchoredPosition + offset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the canvas anchored position to its original value
        canvasRectTransform.anchoredPosition = originalAnchoredPosition;
    }
}
