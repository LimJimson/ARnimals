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
    bool didInitialAnimalSpawn = false;

    public GameObject limitAnimalTXT;
    public Animator limitAnimalTXTAnim;

    public Transform spawnPoint;

    private void Awake()
    {
        modelIndex = StateNameController.animalIndexChosen;
        
    }

    void Start()
    {
        
        //UI and Canvas
        AR_UI.gameObject.SetActive(true);
        spawnAnimalContainer.SetActive(true);
        spawnAnimal();
        //CalculateSpawnPosition();
    }
    
    private void Update()
    {

    }

    public void spawnAnimal()
    {
        //CalculateSpawnPosition();

        if (!didInitialAnimalSpawn)
        {
            Destroy(spawnedObject);
            spawnedObject = Instantiate(arModels[modelIndex], spawnPoint.position, spawnPoint.rotation);

            didInitialAnimalSpawn = true;
        }

    }


    public int getAnimalIndex()
    {
        return modelIndex;
    }

    Quaternion newRotation;

    int spawnedAnimalCtr;

    public void respawnAnimal()
    {

        if (spawnedAnimalCtr >= 2)
        {
            showAnimalLimit();
            return;
        }

        // Calculate the position for the spawned animal based on the initial position.
        Vector3 spawnPositionCopy = spawnPoint.position + (spawnedAnimalCtr == 0 ? Vector3.left : Vector3.right) * 1.5f;

        GameObject spawnedAnimal = Instantiate(arModelsCopy[modelIndex], spawnPositionCopy, spawnPoint.rotation);

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
