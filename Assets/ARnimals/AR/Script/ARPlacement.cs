using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit;

public class ARPlacement : MonoBehaviour
{

    //UI and Canvas
    public Canvas AR_UI;

    //Buttons
    public GameObject spawnAnimalContainer;


    //Main AR
    public GameObject Ar_holder;
    private GameObject spawnedObject;


    //Objects to spawn container
    public GameObject[] arModels;
    public GameObject[] arModelsCopy;
    int modelIndex;

    public Camera arCamera;
    bool didAnimalSpawn = false;

    public GameObject limitAnimalTXT;
    public Animator limitAnimalTXTAnim;

    Vector3 spawnPosition;

    public GameObject[] GameObjectsToHide;
    bool isGameObjectHidden;

    public playAnimalSound playAnimalSndScript;

    private void Awake()
    {
        modelIndex = StateNameController.animalIndexChosen;
        
    }
    void hide_showGameObjects()
    {
        if (isGameObjectHidden)
        {
            isGameObjectHidden = false;
            foreach (GameObject uiElement in GameObjectsToHide)
            {
                uiElement.SetActive(false);
            }
        }
        else
        {
            isGameObjectHidden = true;
            foreach (GameObject uiElement in GameObjectsToHide)
            {
                uiElement.SetActive(true);
            }
        }
    }
    void Start()
    {
        //hide GameObjects
        foreach (GameObject uiElement in GameObjectsToHide)
        {
            uiElement.SetActive(false);
        }

        //UI and Canvas
        AR_UI.gameObject.SetActive(true);
        spawnAnimalContainer.SetActive(true);
    }

    private void Update()
    {
        countdownSpawnAnimal();
        countdownSpawnAdtnlAnimal();
    }
    private void CalculateSpawnPosition()
    {
        // Get the camera's position and rotation
        Vector3 cameraPosition = Camera.main.transform.position;
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // Set the height below the camera where you want to spawn the object
        float spawnHeight = 0.5f;

        // Set the distance in front of the camera where you want to spawn the object
        float spawnDistance = 3f;

        // Calculate the center of the screen in viewport coordinates (0.5, 0.5)
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane);

        // Calculate the spawn position based on the screen center
        spawnPosition = Camera.main.ViewportToWorldPoint(screenCenter);

        // Adjust the spawn position by moving it downward by the specified height
        spawnPosition -= Vector3.up * spawnHeight;

        // Move the spawn position forward by the specified distance
        spawnPosition += cameraRotation * Vector3.forward * spawnDistance;
    }

    float desiredRotationDegrees = 180.0f;

    void destroyObject()
    {
        Destroy(spawnedObject);
        didAnimalSpawn = false;
    }

    public void spawnAnimal()
    {
        destroyObject();
        CalculateSpawnPosition();

        //show GameObjects
        foreach (GameObject uiElement in GameObjectsToHide)
        {
            uiElement.SetActive(true);
        }

        playAnimalSndScript.Invoke("showSpeaker", 1f);

        if (!didAnimalSpawn)
        {
            Destroy(spawnedObject);
            spawnedObject = Instantiate(arModels[modelIndex], spawnPosition, Camera.main.transform.rotation);
            spawnedObject.transform.rotation = Quaternion.Euler(0.0f, desiredRotationDegrees, 0.0f);


            didAnimalSpawn = true;
        }

    }


    public int getAnimalIndex()
    {
        return modelIndex;
    }


    int spawnedAnimalCtr;
    GameObject spawnedAnimal;
    public void respawnAnimal()
    {

        if (spawnedAnimalCtr >= 2)
        {
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("ARMultiModelCopy");

            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }

            showAnimalLimit();
            spawnedAnimalCtr = 0;
            return;
        }

        // Calculate the position for the spawned animal based on the initial position.
        //Vector3 spawnPositionCopy = spawnPosition + (spawnedAnimalCtr == 0 ? Vector3.left : Vector3.right) * 1.5f;
        Vector3 spawnPositionCopy = spawnedObject.transform.position + (spawnedAnimalCtr == 0 ? Vector3.left : Vector3.right) * 1.5f;


        spawnedAnimal = Instantiate(arModelsCopy[modelIndex], spawnPositionCopy, spawnedObject.transform.rotation);

        if (spawnedAnimalCtr == 0)
        {

            moveAnimalScript animalMovement1 = spawnedAnimal.AddComponent<moveAnimalScript>();
        }
        else if (spawnedAnimalCtr == 1)
        {

            moveAnimalScript2 animalMovement2 = spawnedAnimal.AddComponent<moveAnimalScript2>();
        }


        spawnedAnimalCtr++;
    }

    bool isLimitAnimalTxtShown;
    void showAnimalLimit()
    {
        if (!isLimitAnimalTxtShown)
        {
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        
        limitAnimalTXT.SetActive(true);
        isLimitAnimalTxtShown = true;
        float animationDuration = limitAnimalTXTAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(animationDuration +1f);


        limitAnimalTXT.SetActive(false);
        isLimitAnimalTxtShown = false;
        StopAllCoroutines();
    }

    // BUTTON TIMERS

    //Spawn Animal Timer
    public TMP_Text timerSpawnAnimalTxt;
    bool isSpawnAnimalTimerCounting = false;
    float countdownTime = 5.0f;
    public Button spawnAnimalBtn;

    void countdownSpawnAnimal()
    {
        if (isSpawnAnimalTimerCounting)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 5.0f;
                isSpawnAnimalTimerCounting = false;
                timerSpawnAnimalTxt.gameObject.SetActive(false);
                spawnAnimalBtn.interactable = true;

            }

            UpdateTimerText();
        }
    }

    public void StartCountdownSpawnAnimal()
    {
        isSpawnAnimalTimerCounting = true;
        countdownSpawnAnimal();
        timerSpawnAnimalTxt.gameObject.SetActive(true);
        spawnAnimalBtn.interactable = false;

    }
    private void UpdateTimerText()
    {
        timerSpawnAnimalTxt.text = Convert.ToInt16(countdownTime).ToString();
    }


    //Spawn Additional Animal Timer

    public TMP_Text timerAdtnlSpawnAnimalTxt;
    bool isSpawnAdtnlAnimalTimerCounting = false;
    float countdownTimeSpawnAdtnl = 3.0f;
    public Button spawnAdtnlAnimalBtn;

    void countdownSpawnAdtnlAnimal()
    {
        if (isSpawnAdtnlAnimalTimerCounting)
        {
            countdownTimeSpawnAdtnl -= Time.deltaTime;

            if (countdownTimeSpawnAdtnl <= 0)
            {
                countdownTimeSpawnAdtnl = 3.0f;
                isSpawnAdtnlAnimalTimerCounting = false;
                timerAdtnlSpawnAnimalTxt.gameObject.SetActive(false);
                spawnAdtnlAnimalBtn.interactable = true;

            }

            UpdateTimerTextSpawnAdtnl();
        }
    }

    public void StartCountdownSpawnAdtnlAnimal()
    {
        isSpawnAdtnlAnimalTimerCounting = true;
        countdownSpawnAdtnlAnimal();
        timerAdtnlSpawnAnimalTxt.gameObject.SetActive(true);
        spawnAdtnlAnimalBtn.interactable = false;

    }
    private void UpdateTimerTextSpawnAdtnl()
    {
        timerAdtnlSpawnAnimalTxt.text = Convert.ToInt16(countdownTimeSpawnAdtnl).ToString();
    }

}
