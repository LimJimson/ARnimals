using System;
using HG.Collections;
using HG.Extensions;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public interface IDrawerWithHeight : IDrawer
    {
        float GetHeight();
    }

    public class Menu : IDrawerWithHeight
    {
        private readonly IReadOnlyList<string> _options;
        public event Action<int> OptionSelected;
        
        public Menu(IReadOnlyList<string> options)
        {
            Debug.Assert(options != null);
            _options = options;
        }

        public void Draw()
        {
            var area = EditorGUILayout.GetControlRect(true, 0f); // this is a hack to get a rect, specify 0 height to not add extra padding
            //GUILayout.BeginArea(new Rect(0, 0, area.width - 2, EditorGUIUtility.singleLineHeight * _options.Count));
            for (var index = 0; index < _options.Count; index++)
            {
                // @LATER allow to set the starting 'y' ?
                var line = new Rect(0, index * SingleHeight(), area.width - 2, EditorGUIUtility.singleLineHeight);
                // @LATER create a button derived that allows to set Rect
                //if(GUILayout.Button(_options[index], EditorStyles.toolbarButton))
                if (GUI.Button(line, _options[index], EditorStyles.toolbarButton))
                {
                    // @LATER, buttons are not clicking when drawn on top of other clickable elements because the first to be drawn is actually getting the events
                    
                    var selectedIndex = index;
                    EditorApplication.delayCall += () =>
                    {
                        OptionSelected.InvokeSafe(selectedIndex);
                    };
                }
            }
            // let know the GUILayout of our buttons 
            GUILayout.Space(EditorGUIUtility.singleLineHeight * _options.Count + EditorGUIUtility.standardVerticalSpacing * 2);
            //GUILayout.EndArea();
        }

        private static float SingleHeight()
        {
            return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }

        public float GetHeight()
        {
            return _options.Count * SingleHeight();
        }
    }
}