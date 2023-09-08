using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Videoplayback : MonoBehaviour
{
    public VideoClip[] videoclips;
    public VideoPlayer videoplayer;
    private int videoClipIndex;
    public Sprite startSprite;
    public Sprite stopSprite;
    public Button button;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
    }
    void Start()
    {
        videoplayer.clip = videoclips[0];
    }
    public void playNext()
    {
        videoClipIndex++;
        if (videoClipIndex >= videoclips.Length)
        {
            videoClipIndex = videoClipIndex % videoclips.Length;
        }
        videoplayer.clip = videoclips[videoClipIndex];
    }
    public void playPrevious()
    {
        videoClipIndex--;
        if (videoClipIndex >= videoclips.Length)
        {
            videoClipIndex = videoClipIndex % videoclips.Length;
        }
        videoplayer.clip = videoclips[videoClipIndex];
    }
    public void playPause()
    {
        if (videoplayer.isPlaying == false)
        {
            videoplayer.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            videoplayer.Pause();
            button.image.sprite = startSprite;
        }
    }
}
