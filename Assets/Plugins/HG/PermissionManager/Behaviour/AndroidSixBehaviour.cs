using System;
using System.Text;
using HG;
using HG.Extensions;
using Plugins.HG.Editor.General.Utils;
using UnityEngine;

namespace Plugins.HG.PermissionManager
{
    public class AndroidSixBehaviour : TestAndroidBehaviour
    {
        private readonly IPermissionsDialogFactory _permissionsDialogFactory;
        private readonly PermissionsState _permissionsState;
        private readonly DataHolder.PermissionsData _permissionsData;
        private readonly PermissionRequestQueue _permissionQueue;

        public AndroidSixBehaviour(IPermissionsManipulator manipulator, IPermissionsDialogFactory permissionsDialogFactory, PermissionsState permissionsState, DataHolder.PermissionsData permissionsData) : base(manipulator)
        {
            _permissionsDialogFactory = permissionsDialogFactory;
            _permissionsState = permissionsState;
            _permissionsData = permissionsData;
            _permissionQueue = new PermissionRequestQueue(RequestPermissionImpl);
        }

        public override bool IsPermissionGranted(string permissionName)
        {
            if (!IsPermissionInManifests(permissionName))
            {
                ShowNotInManifestError(permissionName);
                return false;
            }

            return _permissionsState.Get(permissionName) == PermissionState.Granted;
        }

        public override void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied)
        {
            _permissionQueue.Add(permissionName, OnPermissionGranted, OnPermissionDenied);
        }
        
        private void RequestPermissionImpl(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied)
        {
            if (!IsPermissionInManifests(permissionName))
            {
                ShowNotInManifestError(permissionName);
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionDenied.InvokeSafe(permissionName));
                return;
            }
            
            if (_permissionsState.Get(permissionName) == PermissionState.Granted)
            {
                HGLogger.LogInfo(permissionName + " permission was granted previously, so the dialog is not shown");
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGranted.InvokeSafe(permissionName));
                return;
            }

            var permissionInfo = _permissionsData.FindPermissionByFullName(permissionName);
            if (permissionInfo != null)
            {
                if (!permissionInfo.IsDangerous())
                {
                    // All non-dangerous permissions are granted by default
                    HGLogger.LogInfo("'{0}' permission automatically granted by being non-dangerous", permissionName);
                    MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGranted.InvokeSafe(permissionName));
                    return;
                }
            }
            else
            {
                HGLogger.LogInfo("'{0}' permission is unknown and assumed to be non-dangerous", permissionName);
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGranted.InvokeSafe(permissionName));
                return;
            }

            if (_permissionsState.Get(permissionName) == PermissionState.DeniedDontAskAgain)
            {
                // @Later should this be LogVerbose instead?
                HGLogger.LogInfo(permissionName + " permission Denied because it was previously denied with 'Don't Ask Again' checked");
                MainThreadDispatcher.RunOnMainThread(()=> OnPermissionDenied.InvokeSafe(permissionName));
                return;
            }

            _permissionsDialogFactory.CreateTwoButton(GetDialogText(permissionName),
                (dialog) =>
                {
                    if (dialog.IsChecked())
                    {
                        _permissionsState.Set(permissionName, PermissionState.DeniedDontAskAgain);
                    }
                    else
                    {
                        _permissionsState.Set(permissionName, PermissionState.DeniedOnce);    
                    }
                    
                    MainThreadDispatcher.RunOnMainThread(()=> OnPermissionDenied.InvokeSafe(permissionName));
                },
                (dialog) =>
                {
                    _permissionsState.Set(permissionName, PermissionState.Granted);
                    MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGranted.InvokeSafe(permissionName));
                }, _permissionsState.Get(permissionName) == PermissionState.DeniedOnce, false);
        }

        private string GetDialogText(string permissionName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Allow <b><color=black>{0}</color></b> to use\n<size=18>{1}?</size>", Application.productName, permissionName);


            var permissionInfo = _permissionsData.FindPermissionByFullName(permissionName);
            if (permissionInfo != null && !permissionInfo.Category.IsNullOrEmpty())
            {
                stringBuilder.AppendFormat("\n<size=16><color=#80808099>[{0} Permission Group]</color></size>", permissionInfo.Category);
            }

            return stringBuilder.ToString();
        }

        public override bool ShouldShowRequestPermissionRationale(string permissionName)
        {
            if (!IsPermissionInManifests(permissionName))
            {
                ShowNotInManifestError(permissionName);
                return false;
            }

            var permissionState = _permissionsState.Get(permissionName);
            return permissionState == PermissionState.DeniedOnce;
        }

        public override bool IsPlatformSupported()
        {
            return true;
        }
    }
}