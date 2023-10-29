using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_GameStartManager : MonoBehaviour
{

    AudioManager audioManager;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private GameObject[] foodSpawners;
    [SerializeField] private GameObject timerManager;
    [SerializeField] private GameObject clickToStart; 

    [SerializeField] private bool gameStarted = false;
    [SerializeField] private TextMeshProUGUI countdownTxt;

    private float countdown = 3f;

    public bool GetGameStarted() 
    {
        return gameStarted;
    }
    
    private void Start()
    {

        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
			Debug.Log("AudioManager Available");
        }
        catch
        {
            Debug.Log("No AudioManager");
        }

        if (pauseManager != null)
        {
            pauseManager.SetIsGamePaused(true); // Pause the game initially
            DisableFoodSpawnersAndScoreHealthCanvasInitially();
        }

        if (startPanel != null)
        {   
            startPanel.SetActive(true); // Show the start panel
        }

        audioManager.playBGMMusic(audioManager.CTF_BGM);
    }

    private void Update()
    {
        if (startPanel.activeSelf == true) 
        {
            startCountdownForClickToStart();
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

    private void startCountdownForClickToStart() 
    {
        countdownTxt.gameObject.SetActive(true);

        if (countdown > 0f) 
        {
            countdown -= Time.deltaTime;
            countdownTxt.text = Mathf.CeilToInt(countdown).ToString();
        }
        else 
        {
            countdownTxt.gameObject.SetActive(false);
            clickToStart.SetActive(true);
        }
    }
}
