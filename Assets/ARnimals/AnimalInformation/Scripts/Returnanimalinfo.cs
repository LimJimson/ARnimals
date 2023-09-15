using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Returnanimalinfo : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void goToAnimal_Information()
    {
        SceneManager.LoadScene("Animal_Information");
    }

}
