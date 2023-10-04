using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GTS_Settings : MonoBehaviour
{


    public Sound[] AnimalSnds,SfxSnds,MusicSnd,GuideSnd;
    public AudioSource AnimalSndSrc,SfxSndSrc,MusicSndSrc,GuideSndSrc;
    public Slider AnimalSndSlider, SfxSndSlider,MusicSndSlider, GuideSndSlider;
    

    void Start()
    {
        LoadValues();
    }


   public void SaveToVolumeButton()
    {
        float AnimalSndValue = AnimalSndSlider.value;
        float SfxSndValue = SfxSndSlider.value;
        float MusicSndValue = MusicSndSlider.value;
        float GuideSndValue = GuideSndSlider.value;

        PlayerPrefs.SetFloat("GTS_AnimalSndVal", AnimalSndValue);
        PlayerPrefs.SetFloat("GTS_SfxSndValue", SfxSndValue);
        PlayerPrefs.SetFloat("GTS_MusicSndValue", MusicSndValue);
        PlayerPrefs.SetFloat("GTS_GuideSndValue", GuideSndValue);

        LoadValues();
    }

    void LoadValues()
    {
        try
        {
            float AnimalSndValue = PlayerPrefs.GetFloat("GTS_AnimalSndVal");
            float SfxSndValue = PlayerPrefs.GetFloat("GTS_SfxSndValue");
            float MusicSndValue = PlayerPrefs.GetFloat("GTS_MusicSndValue");
            float GuideSndValue = PlayerPrefs.GetFloat("GTS_GuideSndValue");

            AnimalSndSlider.value = AnimalSndValue;
            SfxSndSlider.value = SfxSndValue;
            MusicSndSlider.value = MusicSndValue;
            GuideSndSlider.value = GuideSndValue;

            AnimalSndSrc.volume = AnimalSndValue;
            SfxSndSrc.volume = SfxSndValue;
            MusicSndSrc.volume = MusicSndValue;
            GuideSndSrc.volume = GuideSndValue;
        }
        catch
        {
            PlayerPrefs.SetFloat("GTS_AnimalSndVal", 0.5f);
            PlayerPrefs.SetFloat("GTS_SfxSndValue", 0.5f);
            PlayerPrefs.SetFloat("GTS_MusicSndValue", 0.5f);
            PlayerPrefs.SetFloat("GTS_GuideSndValue", 0.5f);
        }


    }
}
