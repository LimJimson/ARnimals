using UnityEditor;
using UnityEngine;

namespace HG
{
    public class HorizontalLine : IDrawer
    {
        public void Draw()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        }
    }
}