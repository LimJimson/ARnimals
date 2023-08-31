using System;
using HG.Button;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public class SkipPermissionDialogDrawer : VerticalSequenceDrawer
    {
        private readonly ISkipPermissionsDialogManipulator _skipPermissionsDialogManipulator;

        public SkipPermissionDialogDrawer(ISkipPermissionsDialogManipulator skipPermissionsDialogManipulator)
        {
            _skipPermissionsDialogManipulator = skipPermissionsDialogManipulator;

            var autoRequestToggle = new HG.Toggle("Auto-Request permissions on application start", IsAutoRequestEnabled(), OnStateChanged)
                .SetTooltip("Auto-Request permissions on application start? This is enabled by default in unity and controlled by the 'unityplayer.SkipPermissionsDialog'")
                .SetLabelWidth(270);


            AddDrawer(
                new ConditionalDrawer(
                    new Clickable( 
                        new HelpBox.HelpBox("It is highly recommended to uncheck \"Auto-Request permissions\" and request permissions right before you will need" +
                                    " them instead of requesting all dangerous permissions at application start without explanation dialogs as this is against" +
                                    " Android guidelines. Click [here] to read more.", MessageType.Warning),
                    () => { Application.OpenURL("http://letsmakeagame.net/documentation-permission-manager/#unity-auto-request-permissions");}),
                () => autoRequestToggle.IsChecked()));

            AddDrawer(autoRequestToggle);
            
            
            _skipPermissionsDialogManipulator.OnRefreshRequired += () =>
            {
                autoRequestToggle.SetChecked(IsAutoRequestEnabled());
            };
        }

        private bool IsAutoRequestEnabled()
        {
            return !_skipPermissionsDialogManipulator.IsPermissionDialogsSkipped();
        }

        private void OnStateChanged(bool isChecked)
        {
            if (isChecked)
            {
                _skipPermissionsDialogManipulator.RemoveSkipPermissionDialog();
            }
            else
            {
                _skipPermissionsDialogManipulator.AddSkipPermissionDialog();

            }
        }
    }
}