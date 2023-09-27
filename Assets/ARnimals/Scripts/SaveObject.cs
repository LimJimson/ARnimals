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
