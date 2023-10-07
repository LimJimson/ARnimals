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
    public int startingFileIndex = 1;
    public GameObject VidPlayerImage;
    public GameObject RawImg;
    public VideoPlayer VidPlayer;
    public Button play_pause_vid, nextBtn, prevBtn;
    private string[] videoFiles;
    public TMP_Text videoCount;
    public Sprite[] play_btn; 
    private int currentVideoIndex = 0;
    private bool isRecording = false;
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
        #if UNITY_ANDROID && !UNITY_EDITOR
           ScreenRecorderBridge.SetFileNameAndDirectoryName("ARnimals", "ARnimals_Recording");
           ScreenRecorderBridge.SetUpScreenRecorder();
        #endif
        VidPlayer.loopPointReached += OnVideoLoopPointReached;

    }
    private void FixedUpdate()
    {
        checkIfRecordingIsActive();
        
    }

    void checkIfRecordingIsActive()
    {
        if (ScreenRecorderBridge.CheckIfRecordingInProgress() == true)
        {
            isRecording = true;
            _txt.gameObject.SetActive(true);

            stopRecordBtn.SetActive(true);
            StartCountdown();


        }
        else if (ScreenRecorderBridge.CheckIfRecordingInProgress() == false)
        {
            isRecording = false;
            
            stopRecordBtn.SetActive(false);

        }

        enable_disableGameObjects();
    }

    void enable_disableGameObjects()
    {
        if(!isRecording && _ARPlacementScript.didAnimalSpawn)
        {
            foreach (GameObject uiElement in objectsToHide)
            {
                uiElement.SetActive(true);
            }
        }
        else if (isRecording && _ARPlacementScript.didAnimalSpawn)
        {
            foreach (GameObject uiElement in objectsToHide)
            {
                uiElement.SetActive(false);
            }
        }

    }
    public TMP_Text countdownTextRecord;
    private float countdownTime;
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

        // Display the countdown time in the "00:00" format
        countdownTextRecord.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Update()
    {

        if (VidPlayer.isPlaying)
        {
            SetCurrentTimeUI();
            
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

            if (countdownTime == 0.0f)
            {
                isCountingDown = false;
                stopRecord();
            }
        }
    }
    public void RecordButtonOnClick()
    {
        countdownTime = 15.0f;
        StopAllCoroutines();
        ScreenRecorderBridge.StartScreenRecording();
    }

    
    public void stopRecord(){
        if(isRecording){
        ScreenRecorderBridge.StopScreenRecording();
        isRecording = false;
        StartCoroutine(txtDelay());
        }
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
            vidDuration.SetActive(true);
            vidFileName.gameObject.SetActive(true);
            RawImg.SetActive(true);

            vidFileName.text = videoFileName;
            VidPlayer.url = videoFiles[currentVideoIndex];
            videoCount.text = currentVideoIndex + 1 + "/" + videoFiles.Length.ToString();
            VidPlayer.Prepare();

            SetCurrentTimeUI();
            VidPlayer.Play();
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
            currentVideoIndex = 0; // Loop back to the first video
        }
        play_pause_vid.image.sprite = play_btn[1];
        GetVideos();


    }
    public void PlayPreviousVideo()
    {

        currentVideoIndex -= 1;

        if (currentVideoIndex < 0)
        {

            currentVideoIndex = videoFiles.Length - 1; // Wrap around to the last video
        }
        
        play_pause_vid.image.sprite = play_btn[1];
        GetVideos();
    }
    IEnumerator txtDelay()
    {
        _txt.text = "Saved to Gallery!";
        yield return new WaitForSeconds(2f);
        _txt.text = "";
        _txt.gameObject.SetActive(false);

    }

    public void setVidIndex()
    {
        currentVideoIndex = 1;
    }
    //delete video script

    //public void DeleteVideo()
    //{
    //    if (videoFiles.Length > 0)
    //    {
    //        if (VidPlayer.isPlaying)
    //        {
    //            VidPlayer.Stop();
    //            play_pause_vid.image.sprite = play_btn[1];
    //        }
    //        StartCoroutine(showTextDelVid());
    //        string pathToFile = videoFiles[currentVideoIndex];
    //        if (File.Exists(pathToFile)) 
    //        { 
    //            File.Delete(pathToFile);

    //        }
    //        if (videoFiles.Length > 0)
    //        {
    //            PlayNextVideo();
    //        }
    //        else
    //        {
    //            GetVideos();
    //        }
    //    }
    //    else if (videoFiles.Length <= 0)
    //    {
    //        StartCoroutine(showTextNoVid());
    //    }
    //    GetVideos();

    //}

    //IEnumerator showTextNoVid()
    //{
    //    deleteBtn.interactable = false;
    //    errorTxtNoVid.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    errorTxtNoVid.gameObject.SetActive(false);
    //    deleteBtn.interactable = true;
    //}

    //IEnumerator showTextDelVid()
    //{
    //    deleteBtn.interactable = false;
    //    errorTxtDelVid.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    errorTxtDelVid.gameObject.SetActive(false);
    //    deleteBtn.interactable = true;
    //}


}
