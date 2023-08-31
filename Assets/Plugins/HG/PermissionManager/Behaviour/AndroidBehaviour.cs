using System;
using HG.Extensions;
using Plugins.HG.Editor.General.Utils;
using UnityEngine;

namespace Plugins.HG.PermissionManager
{
    [Serializable]
    public class AndroidPermissionCallback : AndroidJavaProxy
    {
        private event Action<string> OnPermissionGrantedAction;
        private event Action<string> OnPermissionDeniedAction;

        public AndroidPermissionCallback(Action<string> onGrantedCallback, Action<string> onDeniedCallback) 
            : base("com.unity3d.plugin.UnityAndroidPermissions$IPermissionRequestResult")
        {
            if (onGrantedCallback != null)
            {
                OnPermissionGrantedAction += onGrantedCallback;
            }
            if (onDeniedCallback != null)
            {
                OnPermissionDeniedAction += onDeniedCallback;
            }
        }

        public void OnPermissionGranted(string permissionName)
        {
            MainThreadDispatcher.RunOnMainThread(()=> OnPermissionGrantedAction.InvokeSafe(permissionName));
        }

        public void OnPermissionDenied(string permissionName)
        {
            MainThreadDispatcher.RunOnMainThread(()=> OnPermissionDeniedAction.InvokeSafe(permissionName));
        }
    }
    
    
    public class AndroidBehaviour : IPermissionManagerBehaviour
    {

        public AndroidBehaviour()
        {
            // needed to create MainThreadDispatcher while we are on main thread
            MainThreadDispatcher.RunOnMainThread(delegate {  }); // @LATER avoid such crutch initialization (Singleton Insteance should be created on MainThread)
        }

        public bool IsPermissionGranted(string permissionName)
        {
            return GetNative().Call<bool>("IsPermissionGranted", Activity, permissionName);
        }
        public bool ShouldShowRequestPermissionRationale(string permissionName)
        {
            return GetNative().Call<bool>("ShouldShowRequestPermissionRationale", Activity, permissionName);
        }

        public void RequestPermission(string permissionName, Action<string> OnPermissionGranted, Action<string> OnPermissionDenied)
        {
            RequestPermissions(new []{permissionName}, new AndroidPermissionCallback(OnPermissionGranted, OnPermissionDenied));
        }

        public bool IsPlatformSupported()
        {
            return true;
        }

        public void OpenNativeSettings()
        {
            try
            {
                string packageName = Activity.Call<string>("getPackageName");
         
                using (var uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromParts", "package", packageName, null))
                using (var intentObject = new AndroidJavaObject("android.content.Intent", "android.settings.APPLICATION_DETAILS_SETTINGS", uriObject))
                {
                    intentObject.Call<AndroidJavaObject>("addCategory", "android.intent.category.DEFAULT");
                    intentObject.Call<AndroidJavaObject>("setFlags", 0x10000000);
                    Activity.Call("startActivity", intentObject);
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        private static AndroidJavaObject _currentActivity; 
        private static AndroidJavaObject _permissionsNative;

        private static AndroidJavaObject Activity
        {
            get
            {
                if (_currentActivity == null)
                {
                    var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    _currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); // @LATER what if activity will change
                }

                return _currentActivity;
            }
        }

        private static AndroidJavaObject GetNative()
        {
            return _permissionsNative ??
                   (_permissionsNative = new AndroidJavaObject("com.unity3d.plugin.UnityAndroidPermissions"));
        }

        private static void RequestPermissions(string[] permissionNames, AndroidPermissionCallback callback)
        {
            GetNative().Call("RequestPermissionAsync", Activity, permissionNames, callback);
        }
    }
}