using BrainCheck;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class recordBTNScript : MonoBehaviour
{
    public ARPlacement _ARPlacementScript;
    public showHabitat _showHabitatScript;
    public int startingFileIndex = 1;
    public GameObject VidPlayerImage;
    public GameObject RawImg;
    public VideoPlayer VidPlayer;
    public Button play_pause_vid, nextBtn, prevBtn;
    private string[] videoFiles;
    public TMP_Text videoCount;
    public Sprite[] play_btn; 
    private int currentVideoIndex = 0;
    public bool isRecording = false;
    public TMP_Text _txt;

    string DirPath;
    public TMP_Text errorTxtNoVid;
    public TMP_Text errorTxtDelVid;
    public Button deleteBtn;

    public TMP_Text vidFileName;
    public TMP_Text vidCurrDuration,vidTotDuration;


    public GameObject stopRecordBtn;
    public GameObject[] objectsToHide;

    void Start()
    {
        try
        {
            ScreenRecorderBridge.SetFileNameAndDirectoryName("ARnimals", "ARnimals_Recording");
            ScreenRecorderBridge.SetUpScreenRecorder();
        }
        catch { }
        VidPlayer.loopPointReached += OnVideoLoopPointReached;

    }

    void checkIfRecordingIsActive()
    {
        if (ScreenRecorderBridge.CheckIfRecordingInProgress() == true)
        {
            isRecording = true;

            if (isRecording && _ARPlacementScript.didAnimalSpawn)
            {
                _ARPlacementScript.Arrow.SetActive(false);
                _ARPlacementScript.distanceTxt.gameObject.SetActive(false);
                stopRecordBtn.SetActive(true);
                foreach (GameObject uiElement in objectsToHide)
                {
                    uiElement.SetActive(false);
                }
                StartCountdown();
            }

            
        }
        else if (ScreenRecorderBridge.CheckIfRecordingInProgress() == false)
        {
            isRecording = false;
            

            if (!isRecording && _ARPlacementScript.didAnimalSpawn)
            {
                _ARPlacementScript.Arrow.SetActive(true);
                
                _ARPlacementScript.distanceTxt.gameObject.SetActive(true);
                stopRecordBtn.SetActive(false);

                foreach (GameObject uiElement in objectsToHide)
                {
                    uiElement.SetActive(true);
                }
            }

        }

    }

    public TMP_Text countdownTextRecord;
    private float countdownTime = 15f;
    private bool isCountingDown = false;

    public void StartCountdown()
    {
        isCountingDown = true;
    }

    private void UpdateCountdownText()
    {
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);

        countdownTextRecord.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void FixedUpdate()
    {
        checkIfRecordingIsActive();
    }
    private void Update()
    {
        
        if (VidPlayer.isPlaying)
        {
            SetCurrentTimeUI();
            _showHabitatScript.pauseMainBGM();
        }
        else
        {
            _showHabitatScript.unPauseMainBGM();
        }

        if (VidPlayer.isPrepared)
        {
            SetTotalTimeUI();
        }
        if (isCountingDown)
        {
            countdownTime -= Time.deltaTime;

            countdownTime = Mathf.Max(countdownTime, 0.0f);

            UpdateCountdownText();

            if (countdownTime == 0.0f && isRecording)
            {
                isCountingDown = false;
                stopRecord();
            }
        }
    }
    public void RecordButtonOnClick()
    {
        countdownTime = 15.0f;
        _txt.gameObject.SetActive(false);
        ScreenRecorderBridge.StartScreenRecording();
    }


    public void stopRecord(){
        ScreenRecorderBridge.StopScreenRecording();
        stopRecordBtn.SetActive(false);
        StartCoroutine(txtDelay());
        _ARPlacementScript.Arrow.SetActive(true);
        _ARPlacementScript.distanceTxt.gameObject.SetActive(true);
        _txt.gameObject.SetActive(true);
        
    }

    public void stopTxtDelayCoroutine()
    {
        StopCoroutine(txtDelay());
        _txt.gameObject.SetActive(false);
    }
    IEnumerator txtDelay()
    {
        _txt.text = "Saved to Gallery!";
        yield return new WaitForSeconds(1f);
        _txt.text = "";
        stopTxtDelayCoroutine();
    }
    string videoFileName;

    public void getVideoPath()
    {
        _ARPlacementScript.destroyObject();
        DirPath = "/storage/emulated/0/Movies/";
        if (Directory.Exists(DirPath + "ARnimals"))
        {
            videoFiles = Directory.GetFiles("/storage/emulated/0/Movies/ARnimals", "*.mp4");
        }
        else if (Directory.Exists(DirPath + "HBRecorder"))
        {
            videoFiles = Directory.GetFiles("/storage/emulated/0/Movies/HBRecorder", "*.mp4");
        }

        try
        {
            VidPlayer.url = videoFiles[currentVideoIndex];
            

            GetVideos();
            
        }
        catch
        {
            VidPlayer.gameObject.SetActive(false);
            RawImg.SetActive(false);
        }

    }

    public GameObject vidDuration;
    public TMP_Text slashTxt;

    public void GetVideos()
    {
        if (videoFiles.Length > 0)
        {
            videoFileName = Path.GetFileName(videoFiles[currentVideoIndex]);
            if (VidPlayer.isPlaying)
            {
                VidPlayer.Stop();
            }

            play_pause_vid.gameObject.SetActive(true);
            nextBtn.gameObject.SetActive(true);
            prevBtn.gameObject.SetActive(true);
            videoCount.gameObject.SetActive(true);
            slashTxt.text = "/";
            VidPlayer.gameObject.SetActive(true);
            vidFileName.gameObject.SetActive(true);
            RawImg.SetActive(true);

            vidFileName.text = videoFileName;
            VidPlayer.url = videoFiles[currentVideoIndex];
            videoCount.text = currentVideoIndex + 1 + "/" + videoFiles.Length.ToString();
            VidPlayer.Prepare();

            
            VidPlayer.Play();
            Invoke("SetTotalTimeUI", 0.5f);
            Invoke("SetCurrentTimeUI",0.5f);
            VidPlayer.Pause();
        }
        else
        {
            play_pause_vid.gameObject.SetActive(false);
            nextBtn.gameObject.SetActive(false);
            prevBtn.gameObject.SetActive(false);
            vidDuration.SetActive(false);
            vidFileName.gameObject.SetActive(false);
            videoCount.gameObject.SetActive(false);
            VidPlayer.gameObject.SetActive(false);
            RawImg.SetActive(false);
        }
    }

    void SetCurrentTimeUI()
    {
        string curMinutes = Mathf.Floor((int)VidPlayer.time / 60).ToString("00");
        string curSeconds = ((int)VidPlayer.time % 60).ToString("00");


        vidCurrDuration.text = curMinutes + ":"+ curSeconds;
    }


    void SetTotalTimeUI()
    {
        double durationInSeconds = VidPlayer.frameCount / VidPlayer.frameRate;
        System.TimeSpan VideoUrlLength = System.TimeSpan.FromSeconds(durationInSeconds);
        int minutes = Mathf.FloorToInt((float)durationInSeconds / 60);
        int seconds = Mathf.FloorToInt((float)durationInSeconds % 60);

        string formattedTime = minutes.ToString("00") + ":" + seconds.ToString("00");

        vidTotDuration.text = formattedTime;

    }

    public void playVideo()
    {
        if (videoFiles.Length > 0)
        {
            if (!VidPlayer.isPlaying)
            {
                play_pause_vid.image.sprite = play_btn[0];
                VidPlayer.Play();
                vidDuration.SetActive(true);
            }
            else
            {
                play_pause_vid.image.sprite = play_btn[1];
                VidPlayer.Pause();
            }
        }
        
    }

    
    private void OnVideoLoopPointReached(VideoPlayer source)
    {
        // Change the sprite to "Play"
        play_pause_vid.image.sprite = play_btn[1];
    }

    public void PlayNextVideo()
    {
        currentVideoIndex+=1;
        if (currentVideoIndex >= videoFiles.Length)
        {
            currentVideoIndex = 0; 
        }
        vidDuration.SetActive(false);
        play_pause_vid.image.sprite = play_btn[1];
        GetVideos();
    }
    public void PlayPreviousVideo()
    {

        currentVideoIndex -= 1;

        if (currentVideoIndex < 0)
        {

            currentVideoIndex = videoFiles.Length - 1; 
        }
        vidDuration.SetActive(false);
        play_pause_vid.image.sprite = play_btn[1];
        GetVideos();
    }


    public void setVidIndex()
    {
        currentVideoIndex = 0;
        GetVideos();
    }
}
