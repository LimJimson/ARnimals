using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager audioManager;

    void Start()
    {
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        }
        catch
        {
            Debug.Log("No AudioManager");
        }
    }

	//Audio Methods to use for different CTF Scripts

    public void pauseBGMusic() 
    {
        try
		{
			audioManager.musicSource.Pause();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
	public void stopBGMusic() 
	{
		try
		{
			audioManager.musicSource.Stop();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}
	public void playLvlCompletedSFX() 
	{
		try
		{
			audioManager.PlaySFX(audioManager.winLevel);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}
	public void playGameOverSFX() 
	{
		try
		{
			audioManager.PlaySFX(audioManager.loseLevel);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}
    public void unPauseBGMusic() 
    {
        try
		{
			audioManager.musicSource.UnPause();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playBGMusic() 
    {
        try
		{
			audioManager.playBGMMusic(audioManager.CTF_BGM);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playPowerUpSFX() 
    {
        try
		{
			audioManager.PlaySFX(audioManager.CTF_PowerUps);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playCorrectFoodSFX() 
    {
        try
		{
			audioManager.PlaySFX(audioManager.correctAnswer);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playWrongFoodSFX() 
    {
        try
		{
			audioManager.PlaySFX(audioManager.wrongAnswer);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playBoyGuideVoiceOver(int index) 
    {
        try
		{
			audioManager.PlayGuide(audioManager.CTF_Patrick[index]);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playGirlGuideVoiceOver(int index) 
    {
        try
		{
			audioManager.PlayGuide(audioManager.CTF_Sandy[index]);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
	public void stopGuideVoiceOvers() 
	{
		try
		{
			audioManager.guideSource.Stop();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}
}
