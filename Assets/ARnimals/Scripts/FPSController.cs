using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;
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
        QualitySettings.vSyncCount = 0; 
    }

    void Update() 
    {
        if (Application.targetFrameRate != targetFPS) 
        {
            Application.targetFrameRate = targetFPS;
        }
    }
}
