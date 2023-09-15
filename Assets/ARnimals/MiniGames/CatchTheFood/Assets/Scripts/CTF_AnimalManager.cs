using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CTF_AnimalManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animals;
    [SerializeField] private GameObject[] foodsOfAnimal;
    [SerializeField] private Sprite[] animalHabitatBackgrounds;
    [SerializeField] private Sprite[] scoreAndTimerHolder;

    [SerializeField] private GameObject[] trivias; 

    private string selectedAnimal;

    [SerializeField] private Image scoreHolder;
    [SerializeField] private Image timerHolder;
    [SerializeField] private Image background;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI timer;

    [SerializeField] private GameObject timerGameObject;
    [SerializeField] private GameObject scoreGameObject; 

    private void Start()
    {
        selectedAnimal = PlayerPrefs.GetString("SelectedAnimal");
        ShowAnimalAndFoods(selectedAnimal);

        // Retrieve the selected level from PlayerPrefs
        string selectedLevel = PlayerPrefs.GetString("SelectedLevel");

        // Change the background based on the selected level
        switch (selectedLevel)
        {
            case "Level 1":
                background.sprite = animalHabitatBackgrounds[0];
                scoreHolder.sprite = scoreAndTimerHolder[0];
                timerHolder.sprite = scoreAndTimerHolder[0];
                trivias[0].SetActive(true);
                break;
            case "Level 2":
                background.sprite = animalHabitatBackgrounds[1];
                scoreHolder.sprite = scoreAndTimerHolder[1];
                timerHolder.sprite = scoreAndTimerHolder[1];
                trivias[1].SetActive(true);
                break;
            case "Level 3":
                background.sprite = animalHabitatBackgrounds[2];
                scoreHolder.sprite = scoreAndTimerHolder[2];
                timerHolder.sprite = scoreAndTimerHolder[2];
                trivias[2].SetActive(true);

                scoreText.color = Color.red; scoreText.outlineColor = Color.white;
                timerText.color = Color.red; timerText.outlineColor = Color.white;

                score.color = Color.black; score.outlineColor = Color.white;
                timer.color = Color.black; timer.outlineColor = Color.white;

                scoreGameObject.transform.Translate(new Vector3(0f, 25f, 0f));
                timerGameObject.transform.Translate(new Vector3(-5f, 25f, 0f));
                break;
            case "Level 4":
                background.sprite = animalHabitatBackgrounds[3];
                scoreHolder.sprite = scoreAndTimerHolder[3];
                timerHolder.sprite = scoreAndTimerHolder[3];
                trivias[3].SetActive(true);
                break;
            case "Level 5":
                background.sprite = animalHabitatBackgrounds[4];
                scoreHolder.sprite = scoreAndTimerHolder[4];
                timerHolder.sprite = scoreAndTimerHolder[4];
                trivias[4].SetActive(true);

                scoreText.color = Color.red; scoreText.outlineColor = Color.white;
                timerText.color = Color.red; timerText.outlineColor = Color.white;

                score.color = Color.black; score.outlineColor = Color.white;
                timer.color = Color.black; timer.outlineColor = Color.white;

                scoreGameObject.transform.Translate(new Vector3(0f, 25f, 0f));
                timerGameObject.transform.Translate(new Vector3(-5f, 25f, 0f));
                break;
            default:
                Debug.LogError("Invalid level: " + selectedLevel);
                break;
        }
    }

    private Dictionary<string, int[]> animalFoodMappings = new Dictionary<string, int[]>()
    {
        { "Elephant", new int[] { 0, 1, 2, 3, 4, 5 } },
        { "Pigeon", new int[] { 6, 7, 8, 9, 10, 11 } },
        { "Koi", new int[] { 12, 13, 14, 15, 16, 17 } },
        { "Camel", new int[] { 18, 19, 20, 21, 22, 23} },
        { "Crab", new int[] { 24, 25, 26, 27, 28, 29} },
        // Add more animal-food mappings here if needed
    };

    public void ShowAnimalAndFoods(string animalName)
    {
        int[] foodIndices;
        if (animalFoodMappings.TryGetValue(animalName, out foodIndices))
        {
            foreach (GameObject animal in animals)
            {
                animal.SetActive(animal.name == animalName);
            }

            foreach (GameObject food in foodsOfAnimal)
            {
                food.SetActive(false);
            }

            foreach (int foodIndex in foodIndices)
            {
                if (foodIndex >= 0 && foodIndex < foodsOfAnimal.Length)
                {
                    foodsOfAnimal[foodIndex].SetActive(true);
                }
            }
        }
        else
        {
            Debug.LogError("Invalid animal name: " + animalName);
        }
    }
}
