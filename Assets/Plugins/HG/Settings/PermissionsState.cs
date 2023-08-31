using System;
using System.Collections;
using HG.Extensions;
using HG.General;

namespace HG
{
    public enum PermissionState
    {
        NotRequested, // Should be first to act as default()
        DeniedOnce,
        DeniedDontAskAgain,
        Granted
    }

    [Serializable]
    public class PermissionsState : SerializableDictionary<string, PermissionState>
    {
        private DataHolder.PermissionsData _permisstionsData;

        public PermissionsState()
        {            
            PlayModeDetector.OnPlayModeStateChanged += OnPlayModeStateChanged;
        }

        public void Init(DataHolder.PermissionsData permissionsData)
        {
            _permisstionsData = permissionsData;   
        }

        private void OnPlayModeStateChanged()
        {
            if(!SettingsHolder.Instance.TestingSettings.TestingEnabled) return;
             
            if (!SettingsHolder.Instance.TestingSettings.TestingStorePersistently)
            {
                Clear();    
            }
        }

        public override void Set(string permissionName, PermissionState value)
        {
            var permission = _permisstionsData.FindPermissionByFullName(permissionName);

            if (permission == null || permission.Category.IsNullOrEmpty())
            {
                base.Set(permissionName, value);
            }
            else
            {
                base.Set(permission.Category, value);
            }
        }
    
       

        public override PermissionState Get(string permissionName, PermissionState defaultValue = default(PermissionState))
        {
            var permission = _permisstionsData.FindPermissionByFullName(permissionName);

            if (permission == null || permission.Category.IsNullOrEmpty())
            {
                return base.Get(permissionName, defaultValue);
            }
            else
            {
                return base.Get(permission.Category, defaultValue);
            }
        }
    
    }
}