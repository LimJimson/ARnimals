using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    

    List<int> forestAnimals = new List<int>{0,1,5,6,8,17,18};
    List<int> underWaterAnimals = new List<int>{3,11,9,13,16};
    List<int> SavannahAnimals = new List<int>{7,2,4,10,12,14,15,19};
    void Awake()
    {
        modelIndex = StateNameController.animalIndexChosen;
        
     }
    private void LateUpdate()
    {
        if (isHabitatEnabled)
        {
            
            ARCam.backgroundColor = new Color(0.53f, 0.81f, 0.92f);
        }
        else
        {
            ARCam.backgroundColor = Color.black;
        }
    }
    public void showAnimalHabitat()
    {
        if (isHabitatEnabled)
        {
            isHabitatEnabled = false;

            
            ARCameraBGScript.enabled = true;
            sceneLighting.SetActive(true);
            Underwater.SetActive(false);
            Forest.SetActive(false);
            Savannah.SetActive(false);
        }
        else
        {
            isHabitatEnabled = true;
            
            

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
