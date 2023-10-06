using UnityEngine;

[System.Serializable]

public class SaveObject
{
    [SerializeField]
    public string name;
    public string guideChosen;
    public int unlockedLevelMG1 = 1;
    public int unlockedLevelMG2 = 1;
    public int unlockedLevelMG3 = 1; 
    public bool MainMenuTutorialDone = false;
    public bool ModeSelectTutorialDone = false;
    public bool MiniGamesTutorialDone = false;
    public bool AnimalInfoTutorialDone = false;
    public bool AnimalSelectTutorialDone = false;
    public bool ARExpTutorialDone = false;
    public bool animalInfoGuide = false;

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
