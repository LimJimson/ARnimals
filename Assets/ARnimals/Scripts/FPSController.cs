using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;
    private int originalTargetFPS;
    public static FPSController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        originalTargetFPS = Application.targetFrameRate;

        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = targetFPS;
    }

    void OnDisable()
    {
        Application.targetFrameRate = originalTargetFPS;
    }

    void OnApplicationQuit() 
    {
        Application.targetFrameRate = originalTargetFPS;
    }
}
