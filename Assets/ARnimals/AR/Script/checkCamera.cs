using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class checkCamera : MonoBehaviour
{

    public GameObject cameraBlockGO;
    ARSession arSession;
    public ARPlacement arPlacementScript;
    public AR_Narration arNarrationScript;
    public AR_Guide arGuideScript;
    public recordBTNScript _recordScript;
    void Start()
    {
        arSession = FindObjectOfType<ARSession>();
    }

    void Update()
    {
        //    ARSessionState sessionState = ARSession.state;

        //    if (sessionState == ARSessionState.SessionTracking)
        //    {
        //        //camera is not blocked
        //        disableCameraBlock();
        //    }
        //    else if (sessionState == ARSessionState.Unsupported || sessionState == ARSessionState.NeedsInstall)
        //    {
        //        Debug.LogWarning("AR is unsupported or needs installation.");
        //    }
        //    else if (sessionState == ARSessionState.None || sessionState == ARSessionState.CheckingAvailability)
        //    {
        //        Debug.Log("AR system is initializing or checking availability.");
        //    }
        //    else
        //    {
        //        //camera is blocked
        //        cameraBlockGO.SetActive(true);
        //        if (arNarrationScript.isNarrationActive)
        //        {
        //            arNarrationScript.exitNarration();
        //        }

        //    }



        //}
        //void disableCameraBlock()
        //{
        //    cameraBlockGO.SetActive(false);
        //}
    }
}
