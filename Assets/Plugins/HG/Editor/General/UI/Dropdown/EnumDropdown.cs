﻿using System;
using HG.Extensions;
using UnityEditor;

namespace HG.Dropdown
{
    public class EnumDropdown : IDropdown, IDrawer
    {
        private Enum _value;
        private readonly string _text;
        public event Action OnChangedSelection;

        public EnumDropdown(Enum initialValue, string text = "")
        {
            _value = initialValue;
            _text = text;
        }

        public Enum GetCurrentValue()
        {
            return _value;
        }
        

        public void Draw()
        {
            var prevValue = _value;
            
            _value = EditorGUILayout.EnumPopup(_text, _value);

            if (!Equals(prevValue, _value))
            {
                OnChangedSelection.InvokeSafe();
            }
        }
    }
}