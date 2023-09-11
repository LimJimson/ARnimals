using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimalSound : MonoBehaviour
{
    public int animalIndex;
    public ARPlacement _arPlacementScript;
    public AudioSource audioSrc;
    public AudioClip[] clip;

    public void playSound()
    {
        animalIndex = _arPlacementScript.getAnimalIndex();
        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(clip[animalIndex]);
        }

    }

    public void stopSound()
    {
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
        
    }
}
