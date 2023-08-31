using System;

namespace Plugins.HG.PermissionManager
{
    public interface IPermissionManagerBehaviour
    {
        bool IsPermissionGranted(string permissionName);
        void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied);
        bool ShouldShowRequestPermissionRationale(string permissionName);
        
        bool IsPlatformSupported();

        void OpenNativeSettings();
    }
}