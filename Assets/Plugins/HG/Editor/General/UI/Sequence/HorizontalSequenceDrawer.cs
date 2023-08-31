using System.Collections.Generic;
using UnityEditor;

namespace HG
{
    public class HorizontalSequenceDrawer : SequenceDrawer
    {
        // @LATER allow to pass GUIStyle to use it in BeginHorizontal
        public HorizontalSequenceDrawer(params IDrawer[] drawers): base(drawers)
        {
        }
        
        public override void Draw()
        {
            EditorGUILayout.BeginHorizontal();
            base.Draw();
            EditorGUILayout.EndHorizontal();
        }
    }
}