using UnityEngine;

public class CTF_PauseManager : MonoBehaviour
{
    [SerializeField] private bool isGamePaused = false;
    [SerializeField] private CTF_GameManager gameManager;
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f; // Resume the game by setting the time scale to 1
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }

    public void SetIsGamePaused(bool isGamePaused) 
    {
        this.isGamePaused = isGamePaused;
    }
}
