using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateNameController : MonoBehaviour
{
    public static bool successfullDataFetch = false;

    public static string player_name;
    public static string guide_chosen;
    public static bool mainMenuGuide;
    public static bool modeSelectGuide;
    public static bool miniGamesSelectGuide;
    public static bool animalSelectGuide;
    public static bool ARExperienceGuide;
    public static bool animalInfoGuide;
    public static bool mainMenuSettingsGuide;
    public static bool GTS_GAME_GUIDE;

    public static int levelClickedMG1;
    public static int levelClickedMG2;
    public static int levelClickedMG3;

    public static int animalIndexChosen;
    public static string animalCategoryChosen;
    public static string animalChosen;

    public static int failedAnimal;
    public static bool isGTSExploreClicked;

    public static int tryAnimalAnimalIndex;
    public static bool isTryAnimalARClicked;
}
