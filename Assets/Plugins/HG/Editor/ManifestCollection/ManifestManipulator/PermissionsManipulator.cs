using System;
using System.Collections.Generic;
using System.Globalization;
using HG.Extensions;
using HG.ManifestManipulator.Changers;
using Plugins.HG.PermissionManager;

namespace HG.ManifestManipulator
{

    public class PermissionsManipulator : CollectionManipulator, IPermissionsManipulator
    {
        private readonly DataHolder.PermissionsData _dataPermissions;

        public PermissionsManipulator(IManifestCollection collection, IList<IManifestInfo> manifests,
            DataHolder.PermissionsData dataPermissions): base(collection, manifests)
        {
            _dataPermissions = dataPermissions;
        }

        public IEnumerable<IPermissionInfo> GetAllPermissions()
        {
            List<IPermissionInfo> allPermissions = new List<IPermissionInfo>();
            
            _manifests.ForEach(m => allPermissions.AddRange( PermissionsChanger.GetPermisions(m, _dataPermissions) ));
            return allPermissions.DistinctBy(p => p.FullName);
        }

        public void RemovePermission(IPermissionInfo permission)
        {
            _manifests.ForEach(m => PermissionsChanger.RemovePermission(m, permission));
            //RequireRefresh();
        }
      
        // Note: Plugins folder can only be in Assets/Plugins/
        public AddPermissionResult AddPermission(string text)
        {
            text = PreprocessPermission(text);
            
            var canAdd = CanAdd(text);
            if (canAdd == AddPermissionResult.OK)
            {
                var target = GetAdditionManifest();
                PermissionsChanger.AddPermission(target, text);
   
                //RequireRefresh();
            }

            return canAdd;           
        }

        private string PreprocessPermission(string text)
        {
            if (text.IsNullOrEmpty()) return text;
            
            text = text.Trim(' ');
            text = text.Trim('\n');
            
            return text;
        }

        private AddPermissionResult CanAdd(string text)
        {
            if(text.IsNullOrEmpty()) return AddPermissionResult.Invalid;
                        
            // @LATER cache permissions somehow
            foreach (var permissionInfo in GetAllPermissions())
            {               
                if (permissionInfo.Equals(text))
                {
                    return AddPermissionResult.AlreadyExists;
                }
            }

            return AddPermissionResult.OK;
        }
    }
}