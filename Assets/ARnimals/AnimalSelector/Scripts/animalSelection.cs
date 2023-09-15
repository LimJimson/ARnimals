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



    void Start()
    {
        backBtn.SetActive(true);
        guideBtn.SetActive(true);
        StartBtn.SetActive(false);
        selectAnimalTxt.gameObject.SetActive(true);
        loadingScreen.SetActive(false);
        AnimalNameTxt.gameObject.SetActive(false);
        disableAllAnimalImgs();
    }

    private void Update() {

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

        foreach(Button button in animalBtns)
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
            StateNameController.animalIndexChosen = animalIndex;
            LoadLevelAR();
        }
    }

    public void goToModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    //LOADING UI
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressTxt;
    public void LoadLevelAR()
    {
        StartCoroutine(LoadAsyncWithDelay());
    }

    IEnumerator LoadAsyncWithDelay()
    {
        backBtn.SetActive(false);
        guideBtn.SetActive(false);
        loadingScreen.SetActive(true);

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
                // Wait for an additional delay (2 seconds in your case) before activating the scene.
                yield return new WaitForSeconds(2.0f);

                // Activate the loaded scene.
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
