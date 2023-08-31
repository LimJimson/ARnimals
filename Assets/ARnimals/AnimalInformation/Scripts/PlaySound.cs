using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSrc;

    public void playSound()
    {
        audioSrc.Play();
    }

    public void stopSound()
    {
        audioSrc.Stop();
    }
}
