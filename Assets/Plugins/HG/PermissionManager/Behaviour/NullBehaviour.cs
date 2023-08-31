using System;
using HG.Extensions;

namespace Plugins.HG.PermissionManager
{
    // Behaviour that always returns true & allows permissions instantly
    public class NullBehaviour : IPermissionManagerBehaviour
    {
        public bool IsPermissionGranted(string permissionName)
        {
            return false;
        }

        public void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied)
        { 
            // Note: we avoid throwing on main thread to avoid creation of the MainThreadDispatcher that will try to search the scene
            OnPermissionDenied.InvokeSafe(permissionName);
        }

        public bool ShouldShowRequestPermissionRationale(string permissionName)
        {
            return false;
        }

        public bool IsPlatformSupported()
        {
            return false;
        }

        public void OpenNativeSettings()
        {
        }
    }
}