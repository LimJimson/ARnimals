using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.HG.PermissionManager;
using HG;
using Plugins.HG.PermissionManager;
using UnityEngine;

namespace HG
{
    public static class PermissionManager
    {
        /// <summary>
        /// Checks whether your app has a given permission
        /// </summary>
        /// <param name="permissionName">Name of the permission to be checked. Constants can be found in the HG.Permissions class</param>
        /// <returns></returns>
        public static bool IsPermissionGranted(string permissionName)
        {
            return BehaviourSelector.CurrentBehaviour.IsPermissionGranted(permissionName);
        }

        /// <summary>
        /// Requests permissions to be granted to this application. These permissions must be added in your manifest and they should have protection level dangerous
        /// Normal permissions PROTECTION_NORMAL are granted at install time if they were added in the manifest.
        /// </summary>
        /// <param name="permissionName">Which permission to request (see HG.Permissions)</param>
        /// <param name="OnPermissionGranted">Method to be called if permission was granted. Pass in 'null' for no callback</param>
        /// <param name="OnPermissionDenied">Method to be called if permission was denied. Pass in 'null' for no callback</param>
        public static void RequestPermission(string permissionName, 
            Action<string> OnPermissionGranted = null, Action<string> OnPermissionDenied = null)
        {
            BehaviourSelector.CurrentBehaviour.RequestPermission(permissionName, OnPermissionGranted, OnPermissionDenied);
        }

        /// <summary>
        /// Returns true on Android
        /// Also returns true in Editor if "Testing" is enabled in plugin settings
        /// </summary>
        public static bool IsPlatformSupported()
        {
            return BehaviourSelector.CurrentBehaviour.IsPlatformSupported();
        }

        /// <summary>
        /// Gets whether you should show UI with rationale for requesting a permission. You should do this only if you do not have the permission and the context in which the permission is requested does not clearly communicate to the user what would be the benefit from granting this permission.
        /// For example, if you write a camera app, requesting the camera permission would be expected by the user and no rationale for why it is requested is needed. If however, the app needs location for tagging photos then a non-tech savvy user may wonder how location is related to taking photos. In this case you may choose to show UI with rationale of requesting this permission.
        /// </summary>
        /// <param name="permissionName">Which permission to check</param>
        /// <returns>Returns true if rationale needs to be shown</returns>
        public static bool ShouldShowRequestPermissionRationale(string permissionName)
        {
            return BehaviourSelector.CurrentBehaviour.ShouldShowRequestPermissionRationale(permissionName);
        }

        /// <summary>
        /// Opens the native Android settings where the user can manually grant permissions. Can be useful for cases when permission was denied with "Don’t show again" but permission is required
        /// </summary>
        public static void OpenNativeSettings()
        {
            BehaviourSelector.CurrentBehaviour.OpenNativeSettings();
        }
    }
}
