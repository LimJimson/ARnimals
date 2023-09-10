using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputLogic : MonoBehaviour
{
    public SaveObject soScript;
    public TMP_InputField input;
    public int maxCharCount = 10;
    public int minCharCount = 3;
    public TextMeshProUGUI error;

    public Button continueBtn;

    private void Start()
    {
        
        StartCoroutine(StartDelay());
        
    }
    private void Update()
    {

    }

    public void OnInputFieldValueChanged()
    {
        //only accepts alphabet char.
        input.text = Regex.Replace(input.text, @"[^a-zA-Z]+", "");


        if (input.text.Length == 0)
        {
            error.text = "Please Input a Name";

        }

        else if (input.text.Length <= minCharCount)
        {
            error.text = "Name must be 2-10 characters long";

        }
        else
        {
            error.text = "";
        }


    }
    public void continueBtnClickedNoSave()
    {
        if (input.text.Length == 0)
        {
            error.text = "Please Input a Name";
        }
        else if (input.text.Length <= minCharCount)
        {
        }
        else
        {
            soScript.name = input.text.ToUpper();
            StateNameController.player_name = input.text.ToUpper();
            SaveManager.Save(soScript);
            SceneManager.LoadScene("GuideSelector");
        }
    }
    public void NoGuideSelected()
    {
        SceneManager.LoadScene("GuideSelector");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator StartDelay()
    {
        while (input == null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);
        input.characterLimit = maxCharCount;
        
    }

}
