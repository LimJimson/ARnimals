using System;
using System.Linq;
using HG;
using UnityEngine;

namespace Plugins.HG.PermissionManager
{
    public abstract class TestAndroidBehaviour : IPermissionManagerBehaviour
    {
        private IPermissionsManipulator _manipulator;
        
        public TestAndroidBehaviour(IPermissionsManipulator manipulator)
        {
            _manipulator = manipulator;
        }

        protected bool IsPermissionInManifests(string permissionName)
        {
            return _manipulator.GetAllPermissions().Any(p => p.Equals(permissionName));
        }
        
        protected void ShowNotInManifestError(string permissionName)
        {
            HGLogger.LogError(permissionName + " was not granted as it wasn't found in manifests\nYou can add it on the \"Permissions\" tab.");
        }

        public abstract bool IsPermissionGranted(string permissionName);
        public abstract void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied);
        public abstract bool ShouldShowRequestPermissionRationale(string permissionName);

        public abstract bool IsPlatformSupported();
        public void OpenNativeSettings()
        {
            HGLogger.LogInfo("OpenNativeSettings() was called, this would open settings window on Android");
        }
    }
}