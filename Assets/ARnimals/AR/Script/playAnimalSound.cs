using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playAnimalSound : MonoBehaviour
{
    public int animalIndex;
    public ARPlacement _arPlacementScript;
    public AudioSource audioSrc;
    public AudioClip[] clip;

    public GameObject animalSndBtn;

    private void Awake()
    {
        animalIndex = _arPlacementScript.getAnimalIndex();

    }

    private void Start()
    {
        if (clip[animalIndex] == null)
        {
            animalSndBtn.SetActive(false);
        }
        else
        {
            animalSndBtn.SetActive(true);
        }
    }
    public void playSound()
    {
        
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
