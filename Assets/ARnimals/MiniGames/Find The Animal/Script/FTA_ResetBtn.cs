using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FTA_ResetBtn
{
    public static void FTA_ResetProgress()
    {
        //Reset Levels
        PlayerPrefs.SetInt("FTA_Lvl1", 0);
        PlayerPrefs.SetInt("FTA_Lvl2", 0);
        PlayerPrefs.SetInt("FTA_Lvl3", 0);
        PlayerPrefs.SetInt("FTA_Lvl4", 0);
        PlayerPrefs.SetInt("FTA_Lvl5", 0);

        //Reset Stars
        PlayerPrefs.SetInt("FTA_Lvl1StarsCount", 0);
        PlayerPrefs.SetInt("FTA_Lvl2StarsCount", 0);
        PlayerPrefs.SetInt("FTA_Lvl3StarsCount", 0);
        PlayerPrefs.SetInt("FTA_Lvl4StarsCount", 0);
        PlayerPrefs.SetInt("FTA_Lvl5StarsCount", 0);
    }
}
