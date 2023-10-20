using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class animalSelection : MonoBehaviour
{
    public Image[] animalImgs;
    public Button[] animalBtns;

    public TMP_Text selectAnimalTxt;
    public TMP_Text AnimalNameTxt;

    public GameObject StartBtn;
    public GameObject guideBtn;
    public GameObject backBtn;

    int animalIndex;
    bool animalClicked = false;
    string[] animalsList = {"Bat", "Bear","Camel", "Crab",
        "Crocodile", "Deer", "Duck", "Elephant", "Horse", "Koi", "Leopard",
        "Octopus", "Pigeon", "Piranha", "Rhinoceros", "Seagull",
        "Shark", "Owl", "Tiger", "Zebra"};

    AudioManager audioManager;

    [Header("Fade Transition")]
	[SerializeField] private Image transitionToOutImg;
    [SerializeField] private Image transitionToInImg;
	[SerializeField] private GameObject plainBlackPanel;
	
	private string buttonCode;

    void Start()
    {
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
        backBtn.SetActive(true);
        guideBtn.SetActive(true);
        StartBtn.SetActive(false);
        selectAnimalTxt.gameObject.SetActive(true);
        loadingScreen.SetActive(false);
        AnimalNameTxt.gameObject.SetActive(false);
        AnimalNameTxt.text = "";
        disableAllAnimalImgs();
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

    bool achievedImgPositionOut;
    bool achievedImgPositionIn;
    private void checkIfTransitionIsDone() 
    {

        achievedImgPositionOut = transitionToOutImg.color.a >= 0.9999 && transitionToOutImg.color.a <= 1.0001;
        achievedImgPositionIn = transitionToInImg.color.a >= -0.0001 && transitionToInImg.color.a <= 0.0001;

        if (transitionToOutImg.gameObject.activeSelf && achievedImgPositionOut && buttonCode == "ModeSelect") 
        {
            SceneManager.LoadScene("ModeSelect");
        }


        if (transitionToInImg.gameObject.activeSelf && achievedImgPositionIn) 
        {
            transitionToInImg.gameObject.SetActive(false);
        }
    }

    public void resetSelection()
    {
        animalClicked = false;
        StartBtn.SetActive(false);
        AnimalNameTxt.gameObject.SetActive(false);
        AnimalNameTxt.text = "";

        disableAllAnimalImgs();

        foreach (Button button in animalBtns)
        {
            button.image.color = Color.white;

        }
    }
    public void selectedAnimal(int num)
    {

        animalIndex = num;

        StartBtn.SetActive(true);
        disableAllAnimalImgs();
        showAnimalName();
        selectAnimalTxt.gameObject.SetActive(false);
        animalClicked = true;
        animalImgs[num].gameObject.SetActive(true);
        StateNameController.animalIndexChosen = animalIndex;

        foreach (Button button in animalBtns)
        {
            if (button.Equals(animalBtns[num]))
            {
                button.image.color = Color.yellow;
            }
            else
            {
                button.image.color = Color.white;
            }
        }
        
       
    }

    

    void showAnimalName()
    {
        AnimalNameTxt.gameObject.SetActive(true);
        AnimalNameTxt.text = animalsList[animalIndex];
        StateNameController.animalChosen = animalsList[animalIndex];

    }
    void disableAllAnimalImgs()
    {
        foreach (var animal in animalImgs)
        {
            animal.gameObject.SetActive(false);
        }
    }

    public void startBtnClicked()
    {
        if (animalClicked == true)
        {
            StartCoroutine(LoadAsyncWithDelay());
            //LoadLevelAR();
        }
    }

    public void goToModeSelect()
    {
        buttonCode = "ModeSelect";
        transitionToOutImg.gameObject.SetActive(true);
    }

    //LOADING UI
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressTxt;
    public void LoadLevelAR()
    {
        buttonCode = "AR";
        transitionToOutImg.gameObject.SetActive(true);
    }

    public GameObject blckPanelFadeOut;
    public Animator blckPanel;
    IEnumerator LoadAsyncWithDelay()
    {
        backBtn.SetActive(false);
        guideBtn.SetActive(false);
        blckPanelFadeOut.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        while (!blckPanel.GetCurrentAnimatorStateInfo(0).IsName("blckPanelIdle1"))
        {
            yield return null;
            
        }
        

        blckPanelFadeOut.SetActive(false);
        // Load the scene in the background without activating it.
        AsyncOperation operation = SceneManager.LoadSceneAsync("AR");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressTxt.text = (progress * 100f).ToString("F0") + "%";

            // Check if the loading progress is nearly complete.
            if (operation.progress >= 0.9f)
            {
                blckPanel.SetTrigger("fadeOut");
                // Wait for an additional delay before activating the scene.
                yield return new WaitForSeconds(1f);
                while (!blckPanel.GetCurrentAnimatorStateInfo(0).IsName("blckPanelIdle2"))
                {
                    yield return new WaitForSeconds(1f);

                    // Activate the loaded scene.
                    operation.allowSceneActivation = true;

                    yield return null;

                }

            }

            
        }



    }
}
