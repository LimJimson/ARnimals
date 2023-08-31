using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class showText : MonoBehaviour
{
    new string name ="";
    public TMP_Text boyDialog;
    public TMP_Text girlDialog;
    public TMP_Text boyDialogHighlight;
    public TMP_Text girlDialogHighlight;
    void Start()
    {
        name = StateNameController.player_name;

        playerName(name);
        dialogBoxTxt();
    }

    private string playerName(string text = "")
    {
        if(string.IsNullOrEmpty(text))
        {
            text = "Test";
        }
        return char.ToUpper(text[0]) + ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
    }

    void dialogBoxTxt()
    {
        boyDialog.text = "Hi, " + playerName(name) + "! I'm <color=#FF0000><b>Lorem</b></color>. Let's explore the wildlife of the animals!";
        girlDialog.text = "Hi, " + playerName(name) + "! I'm <color=#C57EE0><b>Ipsum</b></color>. Let's explore the wildlife of the animals!";
        boyDialogHighlight.text = "Hi, " + playerName(name) + "! I'm <color=#FF0000><b>Lorem</b></color>. Let's explore the wildlife of the animals!";
        girlDialogHighlight.text = "Hi, " + playerName(name) + "! I'm <color=#C57EE0><b>Ipsum</b></color>. Let's explore the wildlife of the animals!";
    }
}
