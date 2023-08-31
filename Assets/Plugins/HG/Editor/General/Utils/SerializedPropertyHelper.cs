using System;
using UnityEditor;

namespace Plugins.HG.Editor.General.Utils
{
    public static class SerializedPropertyHelper
    {   
        //https://answers.unity.com/questions/682932/using-generic-list-with-serializedproperty-inspect.html
        public static System.Collections.Generic.List<T> GetPropertyList<T>(this SerializedProperty property, string listName, Func<SerializedProperty, T> GetValue)
        {
            var keys = property.FindPropertyRelative(listName);
            // @LATER check if keys is a list before doing later work
            
            keys.Next(true); // skip generic field
            keys.Next(true); // advance to array size field
 
            // Get the array size
            var arrayLength = keys.intValue;
 
            keys.Next(true); // advance to first array index
 
            // Write values to list
            System.Collections.Generic.List<T> keyValues = new System.Collections.Generic.List<T>(arrayLength);
            int lastIndex = arrayLength - 1;
            for(int i = 0; i < arrayLength; i++) {
                keyValues.Add(GetValue(keys)); // copy the value to the list
                if(i < lastIndex) keys.Next(false); // advance without drilling into children
            }
            
            return keyValues;
        }
    }
}