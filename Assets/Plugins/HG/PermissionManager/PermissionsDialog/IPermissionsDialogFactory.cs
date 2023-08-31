using System;

namespace Plugins.HG.PermissionManager
{
    public interface IPermissionsDialogFactory
    {
        void CreateTwoButton(string message, Action<IPermissionsDialog> onLeftPressed, Action<IPermissionsDialog> onRightPressed, 
            bool checkboxVisible, bool isCheckedonToggled);
    }
}