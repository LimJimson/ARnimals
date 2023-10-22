using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameButtonScripts : MonoBehaviour
{
    [SerializeField] private FadeSceneTransitions fadeScene;
    
	
    public void goToMiniGamesSelect()
    {
        StartCoroutine(fadeScene.FadeOut("MiniGamesSelect"));
    }

    public void goToFindTheAnimal()
    {
		StartCoroutine(fadeScene.FadeOut("FTA_lvlSelect"));
    }
    public void goToCatchTheFood()
    {
		StartCoroutine(fadeScene.FadeOut("CTF_LevelSelector"));
    }
    public void goToGuessTheAnimalFromSound()
    {
		StartCoroutine(fadeScene.FadeOut("GTAFS_lvlSelect"));
    }

    public void goToModeSelect()
    {
		StartCoroutine(fadeScene.FadeOut("ModeSelect"));
    }
    int animalIndex;
    public void setIndex (int index)
    {
        animalIndex = index;
    }

    public void goToAr()
    {
        StateNameController.tryAnimalAnimalIndex = animalIndex;
        StateNameController.isTryAnimalARClicked = true;
        StartCoroutine(fadeScene.FadeOut("Animal Selector AR"));
    }
}
