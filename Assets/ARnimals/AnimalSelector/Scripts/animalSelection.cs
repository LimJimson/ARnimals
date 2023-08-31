using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class animalSelection : MonoBehaviour
{
    public Image[] animalImgs;
    public TMP_Text selectAnimalTxt;
    public TMP_Text AnimalNameTxt;

    public GameObject StartBtn;
    public GameObject guideBtn;
    public GameObject backBtn;
    public Toggle showHabitatToggle;

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
        showHabitatToggle.gameObject.SetActive(true);
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
            StateNameController.showHabitat = showHabitatToggle.isOn;
            Debug.Log(showHabitatToggle.isOn);
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
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        backBtn.SetActive(false);
        guideBtn.SetActive(false);
        showHabitatToggle.gameObject.SetActive(false);
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("AR");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressTxt.text = progress * 100f + "%";
            Debug.Log(progress);

            yield return null;
        }
    }
}
