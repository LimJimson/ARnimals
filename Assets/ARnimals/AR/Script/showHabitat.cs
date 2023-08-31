using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHabitat : MonoBehaviour
{
    int modelIndex;
    bool isHabitatEnabled;
    public GameObject Forest;
    public GameObject Underwater;
    public GameObject Savannah;
    public GameObject sceneLighting;
    public GameObject ARCamWithBG;
    public GameObject ARCamNoBG;
    

    List<int> forestAnimals = new List<int>{0,1,5,6,8,17,18};
    List<int> underWaterAnimals = new List<int>{3,11,9,13,16};
    List<int> SavannahAnimals = new List<int>{7,2,4,10,12,14,15,19};
    void Start()
    {
        modelIndex = StateNameController.animalIndexChosen;
        isHabitatEnabled = StateNameController.showHabitat;
        
        if(isHabitatEnabled){
            ARCamNoBG.SetActive(true);
            ARCamWithBG.SetActive(false);
            if(forestAnimals.Contains(modelIndex))
            {
                sceneLighting.SetActive(true);
                Forest.SetActive(true);
                Underwater.SetActive(false);
                Savannah.SetActive(false);
            }
            else if(underWaterAnimals.Contains(modelIndex))
            {
                sceneLighting.SetActive(false);
                Underwater.SetActive(true);
                Forest.SetActive(false);
                Savannah.SetActive(false);
            }
            else if(SavannahAnimals.Contains(modelIndex))
            {
                sceneLighting.SetActive(true);
                Savannah.SetActive(true);
                Forest.SetActive(false);
                Underwater.SetActive(false);
            }
        }
        else{
            ARCamWithBG.SetActive(true);
            sceneLighting.SetActive(true);
            ARCamNoBG.SetActive(false);
            Underwater.SetActive(false);
            Forest.SetActive(false);
            Savannah.SetActive(false);
        }
     }

    // Update is called once per frame
    void Update()
    {

    }

}
