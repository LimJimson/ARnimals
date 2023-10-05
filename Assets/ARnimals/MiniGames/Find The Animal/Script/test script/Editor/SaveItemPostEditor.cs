using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveItemPos))]
public class SaveItemPostEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveItemPos myScript = (SaveItemPos)target;

        if (GUILayout.Button("Save Pos!"))
        {
            myScript.savePos();
        }
    }
}
