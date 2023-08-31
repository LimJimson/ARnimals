using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
