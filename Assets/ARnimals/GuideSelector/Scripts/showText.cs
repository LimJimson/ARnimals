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
        boyDialog.text = "Hi, <color=#FFCD06><b>" + playerName(name) + "</color></b>! I'm <color=#FF2050><b>Patrick</b></color>. Let's explore the wildlife of the animals!";
        girlDialog.text = "Hello, <color=#FFCD06><b>" + playerName(name) + "</color></b>! I'm <color=#FB00FF><b>Sandy</b></color>. Let's explore the wildlife of the animals!";
        boyDialogHighlight.text = "Hi, <color=#FFCD06><b>" + playerName(name) + "</color></b>! I'm <color=#FF2050><b>Patrick</b></color>. Let's explore the wildlife of the animals!";
        girlDialogHighlight.text = "Hello, <color=#FFCD06><b>" + playerName(name) + "</color></b>! I'm <color=#FB00FF><b>Sandy</b></color>. Let's explore the wildlife of the animals!";
    }
}
