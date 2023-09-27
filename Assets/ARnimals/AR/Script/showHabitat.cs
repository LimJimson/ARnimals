using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class showHabitat : MonoBehaviour
{
    int modelIndex;
    bool isHabitatEnabled;
    public GameObject Forest;
    public GameObject Underwater;
    public GameObject Savannah;
    public GameObject sceneLighting;
    public Camera ARCam;
    public ARCameraBackground ARCameraBGScript;

    public float skySpeed;
    

    List<int> forestAnimals = new List<int>{0,1,5,6,8, 12, 15, 17,18};
    List<int> underWaterAnimals = new List<int>{3,11,9,13,16};
    List<int> SavannahAnimals = new List<int>{7,2,4,10,14,19};
    void Awake()
    {
        modelIndex = StateNameController.animalIndexChosen;
        
     }
    private void Update()
    {
        countdownHabitat();
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
        
    }

    public TMP_Text timerHabitat;
    bool isHabitatTimerCounting = false;
    float countdownTime = 5.0f;
    public Button habitatButton;

    void countdownHabitat()
    {
        if (isHabitatTimerCounting)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 5.0f;
                isHabitatTimerCounting = false;
                timerHabitat.gameObject.SetActive(false);
                habitatButton.interactable = true; 
                
            }

            UpdateTimerText();
        }
    }

    public void StartCountdown()
    {
        isHabitatTimerCounting = true;
        countdownHabitat();
        timerHabitat.gameObject.SetActive(true);
        habitatButton.interactable = false;
    }


    private void UpdateTimerText()
    {
        timerHabitat.text = Convert.ToInt16(countdownTime).ToString();
    }

    public void showAnimalHabitat()
    {
        if (isHabitatEnabled)
        {
            isHabitatEnabled = false;
            ARCam.clearFlags = CameraClearFlags.SolidColor;

            ARCameraBGScript.enabled = true;
            sceneLighting.SetActive(true);
            Underwater.SetActive(false);
            Forest.SetActive(false);
            Savannah.SetActive(false);
        }
        else
        {
            isHabitatEnabled = true;

            ARCam.clearFlags = CameraClearFlags.Skybox;

            ARCameraBGScript.enabled = false;
            if (forestAnimals.Contains(modelIndex))
            {

                sceneLighting.SetActive(true);
                Forest.SetActive(true);
                Underwater.SetActive(false);
                Savannah.SetActive(false);
            }
            else if (underWaterAnimals.Contains(modelIndex))
            {
                sceneLighting.SetActive(false);
                Underwater.SetActive(true);
                Forest.SetActive(false);
                Savannah.SetActive(false);
            }
            else if (SavannahAnimals.Contains(modelIndex))
            {
                sceneLighting.SetActive(true);
                Savannah.SetActive(true);
                Forest.SetActive(false);
                Underwater.SetActive(false);
            }
        }
    }

}
