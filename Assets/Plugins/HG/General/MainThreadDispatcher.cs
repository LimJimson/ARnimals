using System;
using System.Collections.Generic;
using HG.Extensions;

namespace Plugins.HG.Editor.General.Utils
{
    public class MainThreadDispatcher : EditorSingletonMonoBehaviour<MainThreadDispatcher>
    {
        private List<Action> delayedActions = new List<Action>();

        public static void RunOnMainThread(Action action)
        {
            lock (Instance.delayedActions)
            {
                Instance.delayedActions.Add(action);
            }
        }
        
        public static void RunOnMainThread<T>(Action<T> action, T data)
        {
            RunOnMainThread(() => action.InvokeSafe(data));
        }
        
        private void Update()
        {
            List<Action> actionsTmp;
            
            lock (delayedActions)
            {
                // copy to avoid modification while calling actions
                actionsTmp = new List<Action>(delayedActions); 
                delayedActions.Clear();
            }

            foreach (var action in actionsTmp)
            {
                action.InvokeSafe();
            } 
        }
    }
}