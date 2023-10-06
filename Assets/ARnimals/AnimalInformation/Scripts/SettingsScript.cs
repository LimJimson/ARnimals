using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsCanvas;
    public void openSettings()
    {
        settingsCanvas.SetActive(true);
    }
    public void closeSettings()
    {
        settingsCanvas.SetActive(false);
    }
}
