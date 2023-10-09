using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RectTransform videoPlayerRectTransform;
    private Vector2 originalSize;
    private Vector3 originalPosition;
    private bool isFullscreen = false;
    public float fullscreenScale = 0.8f;
    public GameObject referenceCanvas; 
	
	public bool IsFullScreen 
	{
		get {return isFullscreen; } set { isFullscreen = value; }
	}

    private void Start()
    {
        originalSize = videoPlayerRectTransform.sizeDelta;
        originalPosition = videoPlayerRectTransform.anchoredPosition3D;
    }

    public void ToggleFullscreen()
    {
        if (!isFullscreen)
        {
            // Enter fullscreen with a percentage of the canvas size
            Vector2 canvasSize = referenceCanvas.GetComponent<RectTransform>().sizeDelta;
            Vector2 newSize = canvasSize * fullscreenScale;
            videoPlayerRectTransform.sizeDelta = newSize;
            videoPlayerRectTransform.anchoredPosition3D = canvasSize / 2f; 
        }
        else
        {
            // Exit fullscreen
            videoPlayerRectTransform.sizeDelta = originalSize;
            videoPlayerRectTransform.anchoredPosition3D = originalPosition;
        }

        isFullscreen = !isFullscreen;
		
		Debug.Log("In Full Screen: " + isFullscreen);
    }
}

