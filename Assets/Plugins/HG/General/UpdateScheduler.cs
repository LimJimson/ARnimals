using System;
using HG.Extensions;
using UnityEngine;

namespace Plugins.HG.Editor.General.Utils
{
    public class UpdateScheduler : EditorSingletonMonoBehaviour<UpdateScheduler>
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate.InvokeSafe();
        }
    }
}