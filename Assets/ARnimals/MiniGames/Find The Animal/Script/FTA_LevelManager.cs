using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FTA_LevelManager : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;

    [SerializeField] private GameObject[] locks;

    [SerializeField] private TextMeshProUGUI animalToUnlockName;
    private string SelectedLevel;

    AudioManager audioManager;

    SaveObject SaveARGuide;

    [SerializeField] private FadeSceneTransitions fadeScene;

    string GuideARChosen;

    public void Start()
    {
        SaveARGuide = SaveManager.Load();
        GuideARChosen = SaveARGuide.guideChosen;
        checkIfLevelIsUnlocked();
        SelectedLevel = PlayerPrefs.GetString("FTA_SelectedLevel", "1");
        checkStar();
        try
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            if (audioManager.musicSource.isPlaying)
            {

            }
            else
            {
                audioManager.playBGMMusic(audioManager.mainBG);
            }
        }
        catch
        {
            Debug.Log("No AudioManager");
        }
    }
    public void Level1isCLicked()
    {
        SelectedLevel = "1";
        animalToUnlockName.text = "Leopard";
        checkStar();
        BadgeLevelSelectorLogic();
        playConfirmGameObject.SetActive(true);
        levelbordercompletedholder.sprite = levelborderimages[0];
        levelbordercompletedholder.gameObject.SetActive(true);
        twostarstounlock.gameObject.SetActive(true);
        AnimalIndex = 10;
    }

    public void Level2isCLicked()
    {
        SelectedLevel = "2";
        animalToUnlockName.text = "Pigeon";
        checkStar();
        BadgeLevelSelectorLogic();
        playConfirmGameObject.SetActive(true);
        levelbordercompletedholder.sprite = levelborderimages[1];
        levelbordercompletedholder.gameObject.SetActive(true);
        twostarstounlock.gameObject.SetActive(true);
        AnimalIndex = 12;
    }

    public void Level3isCLicked()
    {
        SelectedLevel = "3";
        animalToUnlockName.text = "Piranha";
        checkStar();
        BadgeLevelSelectorLogic();
        playConfirmGameObject.SetActive(true);
        levelbordercompletedholder.sprite = levelborderimages[2];
        levelbordercompletedholder.gameObject.SetActive(true);
        twostarstounlock.gameObject.SetActive(true);
        AnimalIndex = 13;
    }

    public void Level4isCLicked()
    {
        SelectedLevel = "4";
        animalToUnlockName.text = "Bear";
        checkStar();
        BadgeLevelSelectorLogic();
        playConfirmGameObject.SetActive(true);
        levelbordercompletedholder.sprite = levelborderimages[3];
        levelbordercompletedholder.gameObject.SetActive(true);
        twostarstounlock.gameObject.SetActive(true);
        AnimalIndex = 1;
    }

    public void Level5isCLicked()
    {
        SelectedLevel = "5";
        animalToUnlockName.text = "Owl";
        checkStar();
        BadgeLevelSelectorLogic();
        playConfirmGameObject.SetActive(true);
        levelbordercompletedholder.gameObject.SetActive(false);
        checkGameObjectlvl.SetActive(false);
        twostarstounlock.gameObject.SetActive(false);
        NoAvailLevel.gameObject.SetActive(true);
        AnimalIndex = 17;
    }
    public void LoadNextLevel()
    {
        PlayerPrefs.SetString("FTA_SelectedLevel", SelectedLevel);
        StartCoroutine(fadeScene.FadeOut("FTA_Game"));
        audioManager.musicSource.Stop();
        playConfirmGameObject.SetActive(false);
    }

    private void checkIfLevelIsUnlocked()
    {
        if (PlayerPrefs.GetInt("FTA_Lvl1", 0) == 1)
        {
            locks[0].SetActive(false);
            level2Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl2", 0) == 1)
        {
            locks[1].SetActive(false);
            level3Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl3", 0) == 1)
        {
            locks[2].SetActive(false);
            level4Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl4", 0) == 1)
        {
            locks[3].SetActive(false);
            level5Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("FTA_Lvl5", 0) == 1)
        {

        }
    }
    [SerializeField] private Image starsImg;
    [SerializeField] private Sprite[] starsSprites;
    [SerializeField] private Image levelImg;
    [SerializeField] private Sprite[] levelSprites;
    [SerializeField] private Image animalImg;
    [SerializeField] private Sprite[] animalSprites;
    [SerializeField] private GameObject playConfirmGameObject;

    [SerializeField] private GameObject checkGameObject;
    [SerializeField] private GameObject tryAnimalBtn;
    [SerializeField] private GameObject confirmationToARCanvas;

    [SerializeField] private GameObject checkGameObjectlvl;
    [SerializeField] private Image levelbordercompletedholder;
    [SerializeField] private Sprite[] levelborderimages;
    [SerializeField] private TextMeshProUGUI twostarstounlock;
    [SerializeField] private TextMeshProUGUI NoAvailLevel;

    public void checkStar()
    {

        animalImg.sprite = animalSprites[int.Parse(SelectedLevel)];

        levelImg.sprite = levelSprites[int.Parse(SelectedLevel)];

        int currentStar = PlayerPrefs.GetInt("FTA_Lvl" + SelectedLevel + "StarsCount", 0);

        checkGameObject.SetActive(false);
        tryAnimalBtn.SetActive(false);
        checkGameObjectlvl.SetActive(false);
        NoAvailLevel.gameObject.SetActive(false);

        Debug.Log("Level: " + SelectedLevel + "\n" + "currentStar: " + currentStar);

        switch (currentStar)
        {
            case 0:
                starsImg.sprite = starsSprites[0];
                break;
            case 1:
                starsImg.sprite = starsSprites[1];
                break;
            case 2:
                starsImg.sprite = starsSprites[2];
                checkGameObjectlvl.SetActive(true);
                break;
            case 3:
                starsImg.sprite = starsSprites[3];
                checkGameObject.SetActive(true);
                tryAnimalBtn.SetActive(true);
                checkGameObjectlvl.SetActive(true);
                break;
        }
    }
    public void closeButtonFunction()
    {
        playConfirmGameObject.SetActive(false);
    }
    public void backButtonFTA()
    {
        StartCoroutine(fadeScene.FadeOut("MiniGamesSelect"));
    }

    public GameObject GuideBoyARConfirm;
    public GameObject GuideGirlARConfirm;
    int AnimalIndex;

    public void TryAnimalARButton()
    {
        if (GuideARChosen == "boy_guide")
        {
            GuideBoyARConfirm.SetActive(true);
            GuideGirlARConfirm.SetActive(false);
        }
        else if (GuideARChosen == "girl_guide")
        {
            GuideBoyARConfirm.SetActive(false);
            GuideGirlARConfirm.SetActive(true);
        }
        confirmationToARCanvas.SetActive(true);
    }
    public void ConfirmYesTryAnimalARButton()
    {
        audioManager.musicSource.Stop();
        StateNameController.tryAnimalAnimalIndex = AnimalIndex;
        StateNameController.isTryAnimalARClicked = true;
        StartCoroutine(fadeScene.FadeOut("Animal Selector AR"));
    }
    public void ConfirmNoTryAnimalARButton()
    {
        confirmationToARCanvas.SetActive(false);
    }

    public GameObject BadgeShowCongrats;
    public GameObject BadgeBTN;
    public Image BadgeLevelBorder;
    public Sprite[] BadgeSpriteLevelBorder;
    void BadgeLevelSelectorLogic()
    {
        switch (SelectedLevel)
        {
            case "1":
                if (SaveARGuide.level1BadgeFTA)
                {
                    BadgeBTN.SetActive(true);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[1];
                }
                else
                {
                    BadgeBTN.SetActive(false);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[0];
                }
                break;
            case "2":
                if (SaveARGuide.level2BadgeFTA)
                {
                    BadgeBTN.SetActive(true);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[1];
                }
                else
                {
                    BadgeBTN.SetActive(false);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[0];
                }
                break;
            case "3":
                if (SaveARGuide.level3BadgeFTA)
                {
                    BadgeBTN.SetActive(true);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[1];
                }
                else
                {
                    BadgeBTN.SetActive(false);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[0];
                }
                break;
            case "4":
                if (SaveARGuide.level4BadgeFTA)
                {
                    BadgeBTN.SetActive(true);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[1];
                }
                else
                {
                    BadgeBTN.SetActive(false);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[0];
                }
                break;
            case "5":
                if (SaveARGuide.level5BadgeFTA)
                {
                    BadgeBTN.SetActive(true);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[1];
                }
                else
                {
                    BadgeBTN.SetActive(false);
                    BadgeLevelBorder.sprite = BadgeSpriteLevelBorder[0];
                }
                break;
        }
    }
    public void BadgeButtonCongratsOn()
    {
        playConfirmGameObject.SetActive(false);
        BadgeShowCongrats.SetActive(true);
    }
    public void BadgeButtonCongratsOff()
    {
        playConfirmGameObject.SetActive(true);
        BadgeShowCongrats.SetActive(false);
    }
}
