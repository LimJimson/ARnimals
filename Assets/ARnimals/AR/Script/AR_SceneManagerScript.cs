using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AR_SceneManagerScript : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    //void OnApplicationFocus(bool hasFocus)
    //{
    //    if (!Application.isEditor)
    //    {
    //        if (!hasFocus)
    //        {
    //            LoadPreviousScene();
    //        }
    //    }
    //}


    //void LoadPreviousScene()
    //{
    //    // Load the previous scene by name
    //    SceneManager.LoadScene("Animal Selector AR");
    //}

}
