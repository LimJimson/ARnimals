using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class stop_play : MonoBehaviour
{
    public VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    void Update()
    {

    }
    public void ChangeStartStop()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;
        }
    }
}