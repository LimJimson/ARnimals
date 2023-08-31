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
            existingSO.AnimalInfoTutorialDone = so.AnimalInfoTutorialDone;
            existingSO.AnimalSelectTutorialDone = so.AnimalSelectTutorialDone;
            existingSO.ARExpTutorialDone = so.ARExpTutorialDone;

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
