using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "playerSave.json";

    public static void Save(SaveObject so)
    {

        string dir = Application.persistentDataPath + directory;
        
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string fullPath = dir + fileName;

        // If the file exists, load its contents and merge it with the new data
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            SaveObject existingSO = JsonUtility.FromJson<SaveObject>(json);

            existingSO.name = so.name;
            existingSO.guideChosen = so.guideChosen;
            existingSO.unlockedLevelMG1 = so.unlockedLevelMG1;
            existingSO.unlockedLevelMG2 = so.unlockedLevelMG2;
            existingSO.unlockedLevelMG3 = so.unlockedLevelMG3;
            existingSO.MainMenuTutorialDone = so.MainMenuTutorialDone;
            existingSO.ModeSelectTutorialDone = so.ModeSelectTutorialDone;
            existingSO.MiniGamesTutorialDone = so.MiniGamesTutorialDone;
            existingSO.AnimalInfoTutorialDone = so.AnimalInfoTutorialDone;
            existingSO.AnimalSelectTutorialDone = so.AnimalSelectTutorialDone;
            existingSO.ARExpTutorialDone = so.ARExpTutorialDone;
            existingSO.animalInfoGuide = so.animalInfoGuide;
            existingSO.mainMenuSettingsGuide = so.mainMenuSettingsGuide;
            existingSO.GTS_GAME_GUIDE = so.GTS_GAME_GUIDE;
            existingSO.FTA_GAME_GUIDE = so.FTA_GAME_GUIDE;

            //Settings
            existingSO.MusicVolume = so.MusicVolume;
            existingSO.SFXVolume = so.SFXVolume;
            existingSO.GuideVolume = so.GuideVolume;
            existingSO.AnimalSndVolume = so.AnimalSndVolume;
            existingSO.VideoSndVolume = so.VideoSndVolume;

            //GTS Star
            existingSO.GTS_lvl1_star = so.GTS_lvl1_star;
            existingSO.GTS_lvl2_star = so.GTS_lvl2_star;
            existingSO.GTS_lvl3_star = so.GTS_lvl3_star;
            existingSO.GTS_lvl4_star = so.GTS_lvl4_star;
            existingSO.GTS_lvl5_star = so.GTS_lvl5_star;

            //GTS Unlock Animal
            existingSO.isRhinoUnlock = so.isRhinoUnlock;
            existingSO.isCrabUnlock = so.isCrabUnlock;
            existingSO.isKoiUnlock = so.isKoiUnlock;
            existingSO.isBatUnlock = so.isBatUnlock;
            existingSO.isCamelUnlock = so.isCamelUnlock;

            //CTF Unlock Animal
            existingSO.isOctopusUnlock = so.isOctopusUnlock;
            existingSO.isDeerUnlock = so.isDeerUnlock;
            existingSO.isSeagullUnlock = so.isSeagullUnlock;
            existingSO.isSharkUnlock = so.isSharkUnlock;
            existingSO.isDuckUnlock = so.isDuckUnlock;


            //FTA Unlock Animal
            existingSO.isLeopardUnlock = so.isLeopardUnlock;
            existingSO.isPigeonUnlock = so.isPigeonUnlock;
            existingSO.isPiranhaUnlock = so.isPiranhaUnlock;
            existingSO.isBearUnlock = so.isBearUnlock;
            existingSO.isOwlUnlock = so.isOwlUnlock;

            //CTF_HighScores
            existingSO.ctf_HighScoresLvl1 = so.ctf_HighScoresLvl1;
            existingSO.ctf_HighScoresLvl2 = so.ctf_HighScoresLvl2;
            existingSO.ctf_HighScoresLvl3 = so.ctf_HighScoresLvl3;
            existingSO.ctf_HighScoresLvl4 = so.ctf_HighScoresLvl4;
            existingSO.ctf_HighScoresLvl5 = so.ctf_HighScoresLvl5;


            so = existingSO;
        }

        // Serialize the merged data and save it to the file
        string mergedJson = JsonUtility.ToJson(so);
        File.WriteAllText(fullPath, mergedJson);
        Debug.Log("Data Saved at:" + fullPath);
    }



    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
            StateNameController.successfullDataFetch = true;
            Debug.Log("file found at: " + fullPath);
        }
        else
        {
            StateNameController.successfullDataFetch = false;
            Debug.Log("Save File Does Not Exist.");
        }

        return so;
    }

    public static void DeleteFile()
    {

        string fullPath = Application.persistentDataPath + directory + fileName;

        // check if file exists
        if (!File.Exists(fullPath))
        {
            Debug.Log( "no Save file exists" );
        }
        else
        {
           Debug.Log( fileName + " file exists, deleting... " );
            File.Delete(fullPath);
            SceneManager.LoadScene("TitleScreen");
            RefreshEditorProjectWindow();

        }
    }
    static void RefreshEditorProjectWindow()
    {
        #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
        #endif
    }

}
