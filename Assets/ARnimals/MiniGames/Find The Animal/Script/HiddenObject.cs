using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiddenObject : MonoBehaviour
{
    [Header("Item Correct and Shadows")]
    public GameObject item;
    public GameObject[] itemTarget;

    public int[] randomIndexs;
    public GameObject panelFinish;
    int countItemFind;

    [Header("Audio")]
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;
    public AudioClip winLevelSound;
    public AudioClip loseLevelAnswerSound;

    [Header("TimerTick")]
    private float timer = 0f;
    public float timeLimit = 60f;
    public Text timerText;
    private bool isGameOver = false;

    [Header("Settings")]
    public GameObject settingsMenuObject;
    public GameObject hiddenObjectGame;
    private bool isPaused = false;

    [Header("Wrong Answer Effect")]
    public GameObject wrongAnswerPanel;

    [Header("Health")]
    public int countHealth;
    public GameObject health;
    public GameObject panelGameOver;

    [Header("Level")]
    public Image background;
    public Sprite[] spriteBackground;
    public Image[] imageButtonSelectObject;
    public Image[] extraBackground;
    public Sprite[] spriteExtraBackground;
    public int maxLevel;
    static int levelCount;
    int chosenLevel;
    public Button buttonNext;

    [System.Serializable]
    public class SpriteLevel
    {
        public List<Sprite> sprites;
    }
    public List<SpriteLevel> spriteLevel;

    public ControlPos[] savePosition;

    void Start()
    {
        chosenLevel = StateNameController.levelClickedMG1;

        ChangeSpriteLevel(levelCount);
        Debug.Log(levelCount);
        settingsMenuObject.SetActive(false);
        countHealth = health.transform.childCount;
        RandomItemPos();
        RandomIndex();
        RandomItemTarget();
        DisplayTimer();
        checkLevel();
    }
    private void Update()
    {
        if (!isGameOver && !isPaused && countItemFind < 5)
        {
            timer += Time.deltaTime;
            DisplayTimer();

            if (timer >= timeLimit)
            {
                GameOver();
            }
        }

    }

    public void checkLevel()
    {
        if (background.GetComponent<Image>().sprite == spriteBackground[1])
        {
            extraBackground[0].sprite = spriteExtraBackground[0];
            extraBackground[0].transform.localPosition = new Vector3(-441.0773f, -212.7056f, 0);

            extraBackground[1].sprite = spriteExtraBackground[1];
            extraBackground[1].transform.localPosition = new Vector3(202f, -417f, 0);

            extraBackground[2].sprite = spriteExtraBackground[2];
            extraBackground[2].transform.localPosition = new Vector3(997f, -149f, 0);

            extraBackground[3].sprite = spriteExtraBackground[3];
            extraBackground[3].transform.localPosition = new Vector3(595f, -527f, 0);

            extraBackground[4].sprite = spriteExtraBackground[4];
            extraBackground[4].transform.localPosition = new Vector3(-17f, -212.7056f, 0);
        }
    }

    public void ButtonNextLevel()
    {
        levelCount += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ChangeSpriteLevel(int nomerLevel)
    {
        background.GetComponent<Image>().sprite = spriteBackground[nomerLevel];

        for (int i = 0; i < imageButtonSelectObject.Length; i++)
        {
            imageButtonSelectObject[i].sprite = spriteLevel[nomerLevel].sprites[i];
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        settingsMenuObject.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingsMenuObject.SetActive(false);
    }
    public void RestartGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_lvlSelect");
    }

    public void TogglePauseResume()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void DisplayTimer()
    {
        float remainingTime = Mathf.Max(0f, timeLimit - timer);
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timerText != null)
        {
            timerText.text = timeText;
        }
    }
    private void GameOver()
    {
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);
        panelGameOver.SetActive(true);
        AudioSource.PlayClipAtPoint(loseLevelAnswerSound, transform.position);
    }

    private void GameWin()
    {
        isGameOver = true;
        timer = Mathf.Min(timer, timeLimit);
        panelFinish.SetActive(true);
        AudioSource.PlayClipAtPoint(winLevelSound, transform.position);
    }
    void RandomIndex()
    {
        for (int i = 0; i < randomIndexs.Length; i++) 
        {
            int a = randomIndexs[i];
            int b = Random.Range(0, randomIndexs.Length);
            randomIndexs[i] = randomIndexs[b];
            randomIndexs[b] = a;
        }
    }

    void RandomItemTarget()
    {
        for (int i = 0; i < itemTarget.Length; i++)
        {
            itemTarget[i].GetComponent<Image>().sprite = item.transform.GetChild(randomIndexs[i]).GetComponent<Image>().sprite;
        }
    }

    void RandomItemPos()
    {
        int randomSave = chosenLevel = Random.Range(0, ControlPos.Instance.saveItemPos.Count);
        Debug.Log(randomSave);

        for (int i = 0; i < item.transform.childCount; i++)
        {
            if (randomSave == 0)
            {
                item.transform.GetChild(i).transform.localPosition = savePosition[chosenLevel].saveItemPos[randomSave].itemPos[i];
                item.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void ButtonItem()
    {
        for (int i = 0; i < itemTarget.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite == itemTarget[i].GetComponent<Image>().sprite)
            {
                AudioSource.PlayClipAtPoint(correctAnswerSound, transform.position);
                Debug.Log("You found it!");
                itemTarget[i].GetComponent<Image>().color = Color.white;

                countItemFind += 1;
                Debug.Log(countItemFind);

                if (countItemFind >= 5)
                {
                    GameWin();

                    if (levelCount >= maxLevel)
                    {
                        buttonNext.interactable = false;
                        levelCount = 0;
                    }
                }
                //Destroy(EventSystem.current.currentSelectedGameObject.gameObject);
                EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
                return;
            }
            else
            {
                if (i == itemTarget.Length - 1)
                {
                    AudioSource.PlayClipAtPoint(wrongAnswerSound, transform.position);
                    Debug.Log("Better luck next time");
                    DisplayWrongAnswerEffect();
                    if (countHealth > 1)
                    {
                        health.transform.GetChild(countHealth - 1).GetComponent<Image>().color = Color.black;
                        countHealth --;
                    }
                    else
                    {
                        health.transform.GetChild(countHealth - 1).GetComponent<Image>().color = Color.black;
                        countHealth--;
                        panelGameOver.SetActive(true);
                        GameOver();
                    }
                }
            }
        }
    }
    private void DisplayWrongAnswerEffect()
    {
        StartCoroutine(ShowWrongAnswerPanel());
    }

    private IEnumerator ShowWrongAnswerPanel()
    {
        wrongAnswerPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrongAnswerPanel.SetActive(false);
    }
    public void ButtonRetry()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonHome()
    {
        ResumeGame();
        SceneManager.LoadScene("FTA_lvlSelect");
    }
}
