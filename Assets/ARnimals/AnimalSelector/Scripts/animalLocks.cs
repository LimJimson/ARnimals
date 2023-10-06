using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class animalLocks : MonoBehaviour
{

    public Button[] animalBtns;
    public Button[] animal_Locks;
    SaveObject loaddata;
    string guide_chosen;

    //GTS
    bool isRhinoUnlock;
    bool isCamelUnlock;
    bool isBatUnlock;
    bool isKoiUnlock;
    bool isCrabUnlock;

    //FTA

    bool isLeopardUnlock;
    bool isPigeonUnlock;
    bool isPiranhaUnlock;
    bool isBearUnlock;
    bool isOwlUnlock;


    //CTF

    bool isOctopusUnlock;
    bool isDeerUnlock;
    bool isSeagullUnlock;
    bool isSharkUnlock;
    bool isDuckUnlock;




    void Start()
    {
        loaddata = SaveManager.Load();
        guide_chosen = loaddata.getGuide();
        lockAnimals();


        checkIfAnimalIsUnlocked();
        unlockAnimal();
    }

    
    void Update()
    {
        
    }

    void checkIfAnimalIsUnlocked()
    {
        //GTS

        isRhinoUnlock = loaddata.isRhinoUnlock;
        isCamelUnlock = loaddata.isCamelUnlock;
        isBatUnlock = loaddata.isBatUnlock;
        isKoiUnlock = loaddata.isKoiUnlock;
        isCrabUnlock = loaddata.isCrabUnlock;


        //CTF

        isOctopusUnlock = loaddata.isOctopusUnlock;
        isDeerUnlock = loaddata.isDeerUnlock;
        isSeagullUnlock = loaddata.isSeagullUnlock;
        isSharkUnlock = loaddata.isSharkUnlock;
        isDuckUnlock = loaddata.isDuckUnlock;


        //FTA

        isLeopardUnlock = loaddata.isLeopardUnlock;
        isPigeonUnlock = loaddata.isPigeonUnlock;
        isPiranhaUnlock = loaddata.isPiranhaUnlock;
        isBearUnlock = loaddata.isBearUnlock;
        isOwlUnlock = loaddata.isOwlUnlock;
    }

    void lockAnimals()
    {
        foreach (Button button in animalBtns)
        {
            button.interactable = false;

        }

        foreach (Button locks in animal_Locks)
        {
            locks.gameObject.SetActive(true);
            locks.onClick.AddListener(showGoToMiniGames);
        }
    }
    public GameObject MiniGamesConfirm;

    public void goToMiniGames()
    {
        SceneManager.LoadScene("MiniGamesSelect");
    }

    public GameObject boy_guide;
    public GameObject girl_guide;
    void showGoToMiniGames()
    {
        if(guide_chosen == "boy_guide")
        {
            boy_guide.SetActive(true);
            girl_guide.SetActive(false);
        }
        else if(guide_chosen == "girl_guide")
        {
            boy_guide.SetActive(false);
            girl_guide.SetActive(true);
        }
        MiniGamesConfirm.SetActive(true);
    }

    public void hideGoToMiniGames()
    {
        MiniGamesConfirm.SetActive(false);
    }

    void unlockAnimal()
    {
        //GTS

        if (isRhinoUnlock)
        {
            animalBtns[3].interactable = true;
            animal_Locks[3].gameObject.SetActive(false);
        }
        if (isCamelUnlock)
        {
            animalBtns[4].interactable = true;
            animal_Locks[4].gameObject.SetActive(false);
        }
        if (isBatUnlock)
        {

            animalBtns[9].interactable = true;
            animal_Locks[9].gameObject.SetActive(false);
        }
        if(isKoiUnlock)
        {

            animalBtns[13].interactable = true;
            animal_Locks[13].gameObject.SetActive(false);
        }
        if (isCrabUnlock)
        {

            animalBtns[14].interactable = true;
            animal_Locks[14].gameObject.SetActive(false);
        }

        //CTF
        if (isOctopusUnlock)
        {

            animalBtns[11].interactable = true;
            animal_Locks[11].gameObject.SetActive(false);
        }
        if (isDeerUnlock)
        {

            animalBtns[2].interactable = true;
            animal_Locks[2].gameObject.SetActive(false);
        }
        if (isSeagullUnlock)
        {

            animalBtns[7].interactable = true;
            animal_Locks[7].gameObject.SetActive(false);
        }
        if (isSharkUnlock)
        {

            animalBtns[12].interactable = true;
            animal_Locks[12].gameObject.SetActive(false);
        }
        if (isDuckUnlock)
        {

            animalBtns[8].interactable = true;
            animal_Locks[8].gameObject.SetActive(false);
        }


        //FTA
        if (isLeopardUnlock)
        {

            animalBtns[0].interactable = true;
            animal_Locks[0].gameObject.SetActive(false);
        }
        if (isPigeonUnlock)
        {

            animalBtns[5].interactable = true;
            animal_Locks[5].gameObject.SetActive(false);
        }
        if (isPiranhaUnlock)
        {

            animalBtns[10].interactable = true;
            animal_Locks[10].gameObject.SetActive(false);
        }
        if (isBearUnlock)
        {

            animalBtns[1].interactable = true;
            animal_Locks[1].gameObject.SetActive(false);
        }
        if (isOwlUnlock)
        {

            animalBtns[6].interactable = true;
            animal_Locks[6].gameObject.SetActive(false);
        }

    }
}
