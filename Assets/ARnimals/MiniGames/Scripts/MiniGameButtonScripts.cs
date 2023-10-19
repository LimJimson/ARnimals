using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameButtonScripts : MonoBehaviour
{
    [SerializeField] private Image transitionToOutImg;
    [SerializeField] private Image transitionToInImg;
    [SerializeField] private GameObject plainBlackPanel;
	
	private string buttonCode;

	
	private void Start() 
	{
		StartCoroutine(showTransitionAfterDelay());
	}

	private void Update() 
	{
		checkIfTransitionIsDone();
	}

        private IEnumerator showTransitionAfterDelay() 
        {
            plainBlackPanel.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            plainBlackPanel.SetActive(false);
            transitionToInImg.gameObject.SetActive(true);
        }
	
    public void goToMiniGamesSelect()
    {
		buttonCode = "MiniGamesSelect";
        transitionToOutImg.gameObject.SetActive(true);
    }

    public void goToFindTheAnimal()
    {
		buttonCode = "FTA";
		transitionToOutImg.gameObject.SetActive(true);
    }
    public void goToCatchTheFood()
    {
		buttonCode = "CTF";
		transitionToOutImg.gameObject.SetActive(true);
    }
    public void goToGuessTheAnimalFromSound()
    {
		buttonCode = "GTAFS";
		transitionToOutImg.gameObject.SetActive(true);
    }

    public void goToModeSelect()
    {
		buttonCode = "ModeSelect";
		transitionToOutImg.gameObject.SetActive(true);
    }

    public void goToAr()
    {
		buttonCode = "Animal Selector AR";
        transitionToOutImg.gameObject.SetActive(true);
    }
	
	private void checkIfTransitionIsDone() 
    {

        bool achievedImgPositionOut = transitionToOutImg.color.a >= 0.9999 && transitionToOutImg.color.a <= 1.0001;
        bool achievedImgPositionIn = transitionToInImg.color.a >= -0.0001 && transitionToInImg.color.a <= 0.0001;

        if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "FTA") 
        {
            SceneManager.LoadScene("FTA_lvlSelect");
        }
        else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "CTF")
        {
            SceneManager.LoadScene("CTF_LevelSelector");
        }
		else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "GTAFS")
        {
            SceneManager.LoadScene("GTAFS_lvlSelect");
        }
		else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "ModeSelect")
		{
			SceneManager.LoadScene("ModeSelect");
		}
		else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "MiniGamesSelect")
		{
			SceneManager.LoadScene("MiniGamesSelect");
		}
		else if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "Animal Selector AR")
		{
			SceneManager.LoadScene("Animal Selector AR");
		}

        if (transitionToInImg.gameObject.activeSelf && achievedImgPositionIn) 
        {
            transitionToInImg.gameObject.SetActive(false);
        }
    }
}
