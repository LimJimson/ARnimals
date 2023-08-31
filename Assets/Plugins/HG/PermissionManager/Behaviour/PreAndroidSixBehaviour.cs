using System;
using HG;
using HG.Extensions;
using Plugins.HG.Editor.General.Utils;
using UnityEngine;

namespace Plugins.HG.PermissionManager
{
    public class PreAndroidSixBehaviour : TestAndroidBehaviour
    {
        public PreAndroidSixBehaviour(IPermissionsManipulator manipulator) : base(manipulator)
        {
        }
        
        public override bool IsPermissionGranted(string permissionName)
        {
            bool granted = IsPermissionInManifests(permissionName);
            if (!granted)
            {
                ShowNotInManifestError(permissionName);
            }

            return granted;
        }



        public override void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied)
        {
            if (IsPermissionInManifests(permissionName))
            {
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGranted.InvokeSafe(permissionName));
            }
            else
            {
                ShowNotInManifestError(permissionName);
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionDenied.InvokeSafe(permissionName));
            }
        }

        public override bool ShouldShowRequestPermissionRationale(string permissionName)
        {
            return false;
        }

        public override bool IsPlatformSupported()
        {
            return true;
        }
    }
}