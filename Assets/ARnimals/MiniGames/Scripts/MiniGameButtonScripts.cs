using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameButtonScripts : MonoBehaviour
{


    public void goToMiniGamesSelect()
    {
        SceneManager.LoadScene("MiniGamesSelect");
    }

    public void goToFindTheAnimal()
    {
        SceneManager.LoadScene("FTA_lvlSelect");
    }
    public void goToCatchTheFood()
    {
        SceneManager.LoadScene("CTF_LevelSelector");
    }
    public void goToGuessTheAnimalFromSound()
    {
        SceneManager.LoadScene("GTAFS_lvlSelect");
    }

    public void goToModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void goToAr()
    {
        SceneManager.LoadScene("Animal Selector AR");
    }
}
