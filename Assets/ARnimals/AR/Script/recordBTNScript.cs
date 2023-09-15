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
    public int startingFileIndex = 1;
    public GameObject VidPlayerImage;
    public GameObject RawImg;
    public VideoPlayer VidPlayer;
    public Button play_pause_vid;
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
        #if UNITY_ANDROID && !UNITY_EDITOR
            if (ScreenRecorderBridge.CheckIfRecordingInProgress() == true)
            {
                isRecording = true;
                _txt.text = "Recording...";
            }
            else if (ScreenRecorderBridge.CheckIfRecordingInProgress() == false)
            {
                isRecording = false;
            }
        #endif
    }

    public void RecordButtonOnClick()
    {
        
        if (!isRecording)
        {
            // Start the recording
           
            ScreenRecorderBridge.StartScreenRecording();
        }
        else
        {
            // Stop the recording
            ScreenRecorderBridge.StopScreenRecording();
            isRecording = false;
            StartCoroutine(txtDelay());

        }
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

    public void GetVideos()
    {
        if (videoFiles.Length > 0)
        {
            videoFileName = Path.GetFileName(videoFiles[currentVideoIndex]);
            if (VidPlayer.isPlaying)
            {
                VidPlayer.Stop();
            }
            videoCount.gameObject.SetActive(true);
            VidPlayer.gameObject.SetActive(true);
            vidFileName.text = videoFileName;
            RawImg.SetActive(true);
            VidPlayer.url = videoFiles[currentVideoIndex];
            videoCount.text = currentVideoIndex + 1 + "/" + videoFiles.Length.ToString();
            VidPlayer.Play();
            VidPlayer.Pause();
        }
        else
        {
            videoCount.gameObject.SetActive(false);
            VidPlayer.gameObject.SetActive(false);
            RawImg.SetActive(false);
        }
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
