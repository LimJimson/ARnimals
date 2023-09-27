using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Transform spawnPoint;

    Vector3 spawnPosition;

    private void Awake()
    {
        modelIndex = StateNameController.animalIndexChosen;
        
    }

    void Start()
    {
        
        //UI and Canvas
        AR_UI.gameObject.SetActive(true);
        spawnAnimalContainer.SetActive(true);
    }
    
    private void Update()
    {

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

    public void respawnAnimal()
    {

        if (spawnedAnimalCtr >= 2)
        {
            showAnimalLimit();
            return;
        }

        // Calculate the position for the spawned animal based on the initial position.
        Vector3 spawnPositionCopy = spawnPosition + (spawnedAnimalCtr == 0 ? Vector3.left : Vector3.right) * 1.5f;

        GameObject spawnedAnimal = Instantiate(arModelsCopy[modelIndex], spawnPositionCopy, spawnedObject.transform.rotation);

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
        yield return new WaitForSeconds(animationDuration);


        limitAnimalTXT.SetActive(false);
        isLimitAnimalTxtShown = false;
        StopAllCoroutines();
    }


}
