using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveObject
{
    [SerializeField]
    public string name;
    public int unlockedLevelMG3 = 1; 
    public string guideChosen;
    public int unlockedLevelMG1 = 1;
    public int unlockedLevelMG2 = 1;
    public bool MainMenuTutorialDone = false;
    public bool ModeSelectTutorialDone = false;
    public bool MiniGamesTutorialDone = false;
    public bool AnimalInfoTutorialDone = false;
    public bool AnimalSelectTutorialDone = false;
    public bool ARExpTutorialDone = false;
    public bool animalInfoGuide = false;
    public bool mainMenuSettingsGuide = false;
    public bool GTS_GAME_GUIDE = false;

    //GTS Stars
    public int GTS_lvl1_star = 0;
    public int GTS_lvl2_star = 0;
    public int GTS_lvl3_star = 0;
    public int GTS_lvl4_star = 0;
    public int GTS_lvl5_star = 0;

    //GTS Unlock Animal
    public bool isRhinoUnlock = false;
    public bool isCamelUnlock = false;
    public bool isBatUnlock = false;
    public bool isKoiUnlock = false;
    public bool isCrabUnlock = false;

    //CTF Unlock Animal
    public bool isOctopusUnlock = false;
    public bool isDeerUnlock = false;
    public bool isSeagullUnlock = false;
    public bool isSharkUnlock = false;
    public bool isDuckUnlock = false;


    //FTA Unlock Animal
    public bool isLeopardUnlock = false;
    public bool isPigeonUnlock = false;
    public bool isPiranhaUnlock = false;
    public bool isBearUnlock = false;
    public bool isOwlUnlock = false;

    //CTF_HighScoreLists
	[System.Serializable]
	public class CTF_HighScore 
    {
        public int score;
        public string dateAchieved;
    }

    //High Score List for Level 1
    public List<CTF_HighScore> ctf_HighScoresLvl1 = new List<CTF_HighScore>(); 
    //High Score List for Level 2
    public List<CTF_HighScore> ctf_HighScoresLvl2 = new List<CTF_HighScore>();
    //High Score List for Level 3
    public List<CTF_HighScore> ctf_HighScoresLvl3 = new List<CTF_HighScore>();
    //High Score List for Level 4
    public List<CTF_HighScore> ctf_HighScoresLvl4 = new List<CTF_HighScore>();
    //High Score List for Level 5
    public List<CTF_HighScore> ctf_HighScoresLvl5 = new List<CTF_HighScore>();

    public void setName(string playerName)
    {
        this.name = playerName;
    }
    public string getName()
    {
        return this.name;
    }

    public void setUnlockedLevelMG2(int unlockedMG2Lvl)
    {
        this.unlockedLevelMG2 += unlockedMG2Lvl;
    }
    public int getUnlockedLevelMG2()
    {
        return this.unlockedLevelMG2;
    }

    public void setGuide(string guideGender)
    {
        this.guideChosen = guideGender;
    }
    public string getGuide()
    {
        return guideChosen;
    }


}
