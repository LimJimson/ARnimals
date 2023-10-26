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
        if (arSession == null)
        {
            Debug.LogWarning("ARSession not found.");
            return;
        }

        ARSessionState sessionState = ARSession.state;

        if (sessionState == ARSessionState.SessionTracking)
        {
            Invoke("disableCameraBlock",1f);


        }
        else if (sessionState == ARSessionState.Unsupported || sessionState == ARSessionState.NeedsInstall)
        {
            Debug.LogWarning("AR is unsupported or needs installation.");
        }
        else
        {
            // The camera may be blocked or not functioning properly.
            cameraBlockGO.SetActive(true);
            if (arNarrationScript.isNarrationActive)
            {
                arNarrationScript.exitNarration();
            }
            
            //if (_recordScript.isRecording)
            //{
            //    _recordScript.stopRecord();
            //}
            
            //arPlacementScript.removeAllAdditionalAnimals();

            //if (!arGuideScript.isGuideActive)
            //{
            //    arPlacementScript.destroyObject();
            //}
            

            
        }

        
    }
    void disableCameraBlock()
    {
        cameraBlockGO.SetActive(false);
    }
}
