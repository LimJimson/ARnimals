using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager mainAudioManager;

	SaveObject loaddata;

	[SerializeField] private Slider musicSlider;
	[SerializeField] private Slider sfxSlider;
	[SerializeField] private Slider guideSlider;

	[SerializeField] private TextMeshProUGUI musicPercentTxt;
	[SerializeField] private TextMeshProUGUI sfxPercentTxt;
	[SerializeField] private TextMeshProUGUI guidePercentText;

	public Slider MusicSlider 
	{
		get { return musicSlider; }
        set { musicSlider = value; }
	}

    void Start()
    {
        try
        {
            mainAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
			Debug.Log("AudioManager Available");
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

		loaddata = SaveManager.Load();

		loadSavedVolume();
    }

	private void Update() 
	{
		
	}

	private void loadSavedVolume() 
	{
		mainAudioManager.musicSource.volume = loaddata.MusicVolume;
		mainAudioManager.sfxSource.volume = loaddata.SFXVolume;
		mainAudioManager.guideSource.volume = loaddata.GuideVolume;

		musicSlider.value = mainAudioManager.musicSource.volume;
		sfxSlider.value = mainAudioManager.sfxSource.volume;
		guideSlider.value = mainAudioManager.guideSource.volume;

		int percentageForMusicSlider = Mathf.RoundToInt(musicSlider.value * 100);
		musicPercentTxt.text = percentageForMusicSlider.ToString() + "%";
		int percentageForSFXSlider = Mathf.RoundToInt(sfxSlider.value * 100);
		sfxPercentTxt.text = percentageForSFXSlider.ToString() + "%";
		int percentageForGuideSlider = Mathf.RoundToInt(guideSlider.value * 100);
		guidePercentText.text = percentageForGuideSlider.ToString() + "%";
	}
	

	public void changeMusicVolume() 
	{	
		mainAudioManager.musicVol = musicSlider.value;

		int percentage = Mathf.RoundToInt(musicSlider.value * 100);
		musicPercentTxt.text = percentage.ToString() + "%";

		Debug.Log("Music Source Volume: " + mainAudioManager.musicSource.volume);
	}

	public void changeSfxVolume() 
	{	
		mainAudioManager.sfxSource.volume = sfxSlider.value;

		int percentage = Mathf.RoundToInt(sfxSlider.value * 100);
		sfxPercentTxt.text = percentage.ToString() + "%";
	}

	public void changeGuideVolume() 
	{	
		mainAudioManager.guideSource.volume = guideSlider.value;

		int percentage = Mathf.RoundToInt(guideSlider.value * 100);
		guidePercentText.text = percentage.ToString() + "%";
	}

	public void saveVolume() 
	{
		changeMusicVolume();
		changeSfxVolume();
		changeGuideVolume();

		loaddata.MusicVolume = mainAudioManager.musicSource.volume;
		loaddata.SFXVolume = mainAudioManager.sfxSource.volume;
		loaddata.GuideVolume = mainAudioManager.guideSource.volume;

		SaveManager.Save(loaddata);

		loadSavedVolume();
	} 

	//Audio Methods to use for different CTF Scripts

    public void pauseBGMusic() 
    {
        try
		{
			mainAudioManager.musicSource.Pause();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }

	public float musicVolume
	{
		set { mainAudioManager.musicVol = value; }
		get { return mainAudioManager.musicVol; }
	} 

	public void stopBGMusic() 
	{
		try
		{
			mainAudioManager.musicSource.Stop();
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
			mainAudioManager.PlaySFX(mainAudioManager.winLevel);
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
			mainAudioManager.PlaySFX(mainAudioManager.loseLevel);
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
			mainAudioManager.musicSource.UnPause();
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
			mainAudioManager.playBGMMusic(mainAudioManager.CTF_BGM);
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
			mainAudioManager.PlaySFX(mainAudioManager.CTF_PowerUps);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }

	public void playCountdown() 
	{
		try
		{
			mainAudioManager.PlaySFX(mainAudioManager.CTF_Countdown);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}

	public void pauseCountdown() 
	{
		try
		{
			mainAudioManager.sfxSource.Pause();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}

	public void unPauseCountdown() 
	{
		try
		{
			mainAudioManager.sfxSource.UnPause();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}

	public void stopCountdown() 
	{
		try
		{
			mainAudioManager.sfxSource.Stop();
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
			mainAudioManager.PlaySFX(mainAudioManager.correctAnswer);
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
			mainAudioManager.PlaySFX(mainAudioManager.wrongAnswer);
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
    }
    public void playBadgeSFX()
    {
        try
        {
            mainAudioManager.PlaySFX(mainAudioManager.badgeSFX);
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
			mainAudioManager.PlayGuide(mainAudioManager.CTF_Patrick[index]);
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
			mainAudioManager.PlayGuide(mainAudioManager.CTF_Sandy[index]);
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
			mainAudioManager.guideSource.Stop();
		}
		catch
		{
			Debug.Log("No AudioManager");
		}
	}
}
