using HG;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class runtimePerms : MonoBehaviour
{

    public GameObject TitleScreenUI;
    public GameObject PermissionDeniedUI;
    void Start()
    {
        // Check if the Android version is 13 or higher
        if (IsAndroidVersionAtLeast(13))
        {
            if (!PermissionManager.IsPermissionGranted(Permission.CAMERA) || !PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(false);
                PermissionDeniedUI.SetActive(true);
            }
            else if (PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(true);
                PermissionDeniedUI.SetActive(false);
            }
        }
        else
        {

            if (!PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE) || !PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE) || !PermissionManager.IsPermissionGranted(Permission.CAMERA) || !PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(false);
                PermissionDeniedUI.SetActive(true);
            }
            else if (PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(true);
                PermissionDeniedUI.SetActive(false);
            }
        }
    }

    private bool IsAndroidVersionAtLeast(int minVersion)
    {

            // Check if the Android SDK version is equal to or greater than minVersion
            using (AndroidJavaClass version = new AndroidJavaClass("android.os.Build$VERSION"))
            {
                int sdkInt = version.GetStatic<int>("SDK_INT");
                return sdkInt >= minVersion;
            }

    }
    public void requestPerms()
    {
        if (!PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE))
        {
            PermissionManager.RequestPermission(Permission.READ_EXTERNAL_STORAGE, OnPermissionGranted, OnPermissionDenied);
        }
        if (!PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE))
        {
            PermissionManager.RequestPermission(Permission.WRITE_EXTERNAL_STORAGE, OnPermissionGranted, OnPermissionDenied);
        }
        if (!PermissionManager.IsPermissionGranted(Permission.CAMERA))
        {
            PermissionManager.RequestPermission(Permission.CAMERA, OnPermissionGranted, OnPermissionDenied);
        }
        if (!PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
        {
            PermissionManager.RequestPermission(Permission.RECORD_AUDIO, OnPermissionGranted, OnPermissionDenied);
        }


    }

    private void OnPermissionDenied(string deniedPerm)
    {
        Debug.Log("Permission Denied");


    }
    public void reloadScene()
    {
        if (IsAndroidVersionAtLeast(13))
        {
            if (!PermissionManager.IsPermissionGranted(Permission.CAMERA) || !PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(false);
                PermissionDeniedUI.SetActive(true);
            }
            else if (PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(true);
                PermissionDeniedUI.SetActive(false);
            }
        }
        else
        {
            if (!PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE) && !PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE) && !PermissionManager.IsPermissionGranted(Permission.CAMERA) && !PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(false);
                PermissionDeniedUI.SetActive(true);
                requestPerms();
            }
            else if (PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }


    }
    private void OnPermissionGranted(string grantedPerm)
    {
        Debug.Log("Permission Granted");
        if (IsAndroidVersionAtLeast(13))
        {
            if (!PermissionManager.IsPermissionGranted(Permission.CAMERA) || !PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(false);
                PermissionDeniedUI.SetActive(true);
            }
            else if (PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                TitleScreenUI.SetActive(true);
                PermissionDeniedUI.SetActive(false);
            }
        }
        else
        {
            if (PermissionManager.IsPermissionGranted(Permission.READ_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.WRITE_EXTERNAL_STORAGE) && PermissionManager.IsPermissionGranted(Permission.CAMERA) && PermissionManager.IsPermissionGranted(Permission.RECORD_AUDIO))
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }

    }
}
