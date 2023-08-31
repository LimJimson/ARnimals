using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plugins.HG.PermissionManager
{
    public class UnityPermissionsDialogFactory : IPermissionsDialogFactory
    {
        public void CreateTwoButton(string message, Action<IPermissionsDialog> onLeftPressed, Action<IPermissionsDialog> onRightPressed, 
            bool checkboxVisible, bool isChecked)
        {

            var currentEventSystem = EventSystem.current;
            if (currentEventSystem == null)
            {
                var eventSystemPrefab = Resources.Load("APM_EventSystem");
                GameObject.Instantiate(eventSystemPrefab);
            }

            var prefab = Resources.Load("PermissionsDialogCanvas");
            var newDialogObject = GameObject.Instantiate(prefab) as GameObject;

            var dialog = newDialogObject.GetComponent<PermissionsDialog>();
            dialog.Setup(message, ()=>onLeftPressed(dialog), ()=>onRightPressed(dialog));
            dialog.SetupCheckbox(checkboxVisible, isChecked);
        }
    }
}