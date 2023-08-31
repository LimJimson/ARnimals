using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HG.Extensions;
using HG.ManifestManipulator.Changers;
using Plugins.HG.PermissionManager;

namespace HG.ManifestManipulator
{

    public class SkipPermissionsDialogManipulator : CollectionManipulator, ISkipPermissionsDialogManipulator
    {
        private bool? _isSkippedCache = null;
        
        public SkipPermissionsDialogManipulator(IManifestCollection collection, IList<IManifestInfo> manifests): base(collection, manifests)
        {
            OnRefreshRequired += () => { _isSkippedCache = null; }; // reset the cache when something changed
        }

        public bool IsPermissionDialogsSkipped()
        {
            if (_isSkippedCache == null)
            {
                _isSkippedCache = _manifests.Any(m => SkipPermissionsDialogChanger.IsPermissionDialogsSkipped(m)); 
            }

            return _isSkippedCache.Value;
        }

        public void RemoveSkipPermissionDialog()
        {
            _manifests.ForEach(m => SkipPermissionsDialogChanger.RemoveSkipPermissionDialog(m));
            //RequireRefresh();
        }
      
        public void AddSkipPermissionDialog()
        {
            var target = GetAdditionManifest();
            SkipPermissionsDialogChanger.AddSkipPermissionDialog(target);
   
            //RequireRefresh();
        }

    }
}