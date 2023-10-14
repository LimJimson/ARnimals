using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CTF_Reset
{
    public static void CTF_ResetProgress() 
    {
        //Reset Levels
        PlayerPrefs.SetInt("CTF_Lvl1", 0);
        PlayerPrefs.SetInt("CTF_Lvl2", 0);
        PlayerPrefs.SetInt("CTF_Lvl3", 0);
        PlayerPrefs.SetInt("CTF_Lvl4", 0);
        PlayerPrefs.SetInt("CTF_Lvl5", 0);

        //Reset Tutorial
        PlayerPrefs.SetInt("CTF_IsTutorialDone", 0);

        //Reset High Score
        PlayerPrefs.SetInt("CTF_HighScoreLvl1", 0);
		PlayerPrefs.SetInt("CTF_HighScoreLvl2", 0);
		PlayerPrefs.SetInt("CTF_HighScoreLvl3", 0);
		PlayerPrefs.SetInt("CTF_HighScoreLvl4", 0);
		PlayerPrefs.SetInt("CTF_HighScoreLvl5", 0);
		
		//Reset Stars
		PlayerPrefs.SetInt("CTF_Lvl1StarsCount", 0);
		PlayerPrefs.SetInt("CTF_Lvl2StarsCount", 0);
		PlayerPrefs.SetInt("CTF_Lvl3StarsCount", 0);
		PlayerPrefs.SetInt("CTF_Lvl4StarsCount", 0);
		PlayerPrefs.SetInt("CTF_Lvl5StarsCount", 0);
    }
}
