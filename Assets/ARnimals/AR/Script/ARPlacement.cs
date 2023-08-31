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
    public GameObject _AnimalInteractionContainer;
    public GameObject[] Animal_interactionsBtns;

    public GameObject respawnBTN;
    public GameObject Gamepad;

    //Main AR
    public GameObject Ar_holder;
    private GameObject spawnedObject;
    private Pose PlacementPose;

    //private bool placementPoseIsValid = false;

    //Objects to spawn container
    public GameObject[] arModels;
    int modelIndex;


    void Start()
    {

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        modelIndex = StateNameController.animalIndexChosen;

        //UI and Canvas
        AR_UI.gameObject.SetActive(true);
        _AnimalInteractionContainer.SetActive(true);
        foreach (GameObject interactions in Animal_interactionsBtns)
        {
            interactions.SetActive(false);
        }
        //Buttons
        Gamepad.gameObject.SetActive(false);
        respawnBTN.gameObject.SetActive(true);

        //Main AR
        
        GameObject clearUp = GameObject.FindGameObjectWithTag("ARMultiModel");
        Destroy(clearUp);
        Destroy(spawnedObject);
        spawnedObject = null;

    }

    public int getAnimalIndex()
    {
        return modelIndex;
    }

    void FixedUpdate()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }


    void ARPlaceObject()
    {

            GameObject clearUp = GameObject.FindGameObjectWithTag("ARMultiModel");
            Destroy(clearUp);
            Quaternion newRotation = PlacementPose.rotation * Quaternion.Euler(0, 180f, 0);
            spawnedObject = Instantiate(arModels[modelIndex], PlacementPose.position, newRotation);

    }

    public void returnToAnimalSelectBTN()
    {
        SceneManager.LoadScene("Animal Selector AR");
    }

    public void respawnAnimal()
    {
        // Get the main camera in the AR world
        Camera arCamera = FindObjectOfType<ARSessionOrigin>().camera;

        // Calculate the position for the respawned object
        Vector3 respawnPosition = arCamera.transform.position + (arCamera.transform.forward * 4.0f) - new Vector3(0.0f, 0.4f, 0.0f);

        // Calculate the rotation for the spawned object to face towards the player
        Quaternion newRotation = Quaternion.LookRotation(arCamera.transform.position - respawnPosition, Vector3.up);

        // Destroy the old spawned object
        Destroy(spawnedObject);

        // Spawn the animal
        spawnedObject = Instantiate(arModels[modelIndex], respawnPosition, newRotation);

        // Display gamepad
        Gamepad.gameObject.SetActive(true);

        _AnimalInteractionContainer.SetActive(true);

        foreach (GameObject interactions in Animal_interactionsBtns)
        {
            interactions.SetActive(true);
        }

    }



}
