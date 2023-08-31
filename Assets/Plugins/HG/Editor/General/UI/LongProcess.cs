using System;
using HG.Extensions;
using HG.Window;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public static class LongProcess
    {
        public static void Run(Action action, string title, string message)
        {
            // @LATER set the width & height based on the message & title
            
            var window = ModalWindow.CreateWindow(title, new Vector2(250, 40),
                new Label.Label(message));

            EditorApplication.delayCall += () =>
            {
                EditorApplication.delayCall += () =>
                {
                    action.InvokeSafe();
                    window.Close();
                };
            };
        }
    }
}