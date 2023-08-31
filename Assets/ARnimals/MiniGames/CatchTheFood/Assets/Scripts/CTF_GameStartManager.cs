using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_GameStartManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private GameObject[] foodSpawners;
    [SerializeField] private GameObject timerManager;
    [SerializeField] private GameObject clickToStart; 

    [SerializeField] private bool gameStarted = false;

    public bool GetGameStarted() 
    {
        return gameStarted;
    }
    
    private void Start()
    {
        if (pauseManager != null)
        {
            pauseManager.SetIsGamePaused(true); // Pause the game initially
            DisableFoodSpawnersAndScoreHealthCanvasInitially();
        }

        if (startPanel != null)
        {   
            startPanel.SetActive(true); // Show the start panel
        }
    }

    private void Update()
    {

        if (startPanel.activeSelf == true) 
        {
            Invoke("activateClickToStart", 3f);
        }
    }

    public void DisableFoodSpawnersAndScoreHealthCanvasInitially() 
    {
        foodSpawners[0].SetActive(false);
        foodSpawners[1].SetActive(false);
        foodSpawners[2].SetActive(false);

        timerManager.SetActive(false);
    }

    public void EnableFoodSpawnersAndScoreHealthCanvas() 
    {
        foodSpawners[0].SetActive(true);
        foodSpawners[1].SetActive(true);
        foodSpawners[2].SetActive(true);

        timerManager.SetActive(true);
    }

    public void activateClickToStart() 
    {
        clickToStart.SetActive(true);
    }

    public void StartGame()
    {
        if (gameStarted == false && clickToStart.activeSelf == true)
        {
            if (pauseManager != null)
            {
                pauseManager.ResumeGame(); // If the player clicks anywhere, resume the game
            }

            if (startPanel != null)
            {
                startPanel.SetActive(false); // Hide the start panel
            }

            gameStarted = true; // Toggle the gameStarted flag
            EnableFoodSpawnersAndScoreHealthCanvas();
        }
    }
}
