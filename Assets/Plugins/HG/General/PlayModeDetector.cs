using System;
using HG.Extensions;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HG.General
{
    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    public class PlayModeDetector
    {
        // Note: these events are invoked only if we are in UNITY_EDITOR
        #pragma warning disable 0067
        public static event Action OnPlayModeStateChanged;
        #pragma warning restore 0067
        
#if UNITY_2017_2_OR_NEWER
        static PlayModeDetector()
        {
        #if UNITY_EDITOR
            EditorApplication.playModeStateChanged += StateChange;
        #endif
        }
        
        #if UNITY_EDITOR
        static void StateChange(PlayModeStateChange mode){
            OnPlayModeStateChanged.InvokeSafe();
        }
        #endif
        
#else
        static PlayModeDetector()
        {
        #if UNITY_EDITOR
            EditorApplication.playmodeStateChanged += StateChange;
        #endif
        }
        
        #if UNITY_EDITOR
        static void StateChange(){
            OnPlayModeStateChanged.InvokeSafe();
        }
        #endif

#endif
    }
}