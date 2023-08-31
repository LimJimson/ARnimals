using System;
using System.Collections.Generic;
using HG.Extensions;
using Plugins.HG.General.Utils;
using UnityEditor;
using UnityEngine;

namespace HG
{
    

    [Serializable]
    public class AndroidManifestToolSettings : ScriptableObject
    {
        [Serializable] 
        private class ManifestHolder // Unity serialization doesn't support derived classes, so use a builder instead
        {
            public string Path;
        }
        
        [SerializeField]
        private List<ManifestHolder> _manifests = new List<ManifestHolder>();

        public List<IManifestInfo> GetManifests()
        {
            var infos = _manifests.ConvertAll(holder => ManifestInfoFactory.CreateManifestInfo(holder.Path));
            CleanupManifestList(ref infos);

            return infos;
        }

        public void SetManifests(List<IManifestInfo> manifests)
        {
            _manifests = manifests.ConvertAll(m => new ManifestHolder {Path = m.ContainerPath});
            Save();
        }

        private void CleanupManifestList(ref List<IManifestInfo> infos)
        {
            bool removed = RemoveMissingManifests(ref infos);
            removed |= RemoveInvalidManifests(ref infos);

            // check if removed something to avoid infinity cycle
            if (removed)
            {
                Save();
            }
        }

        private bool RemoveConditional(ref List<IManifestInfo> infos, Predicate<IManifestInfo> predicated, string reason)
        {
            var removedElements = infos.RemoveAll(predicated);
            if (removedElements > 0)
            {
                HGLogger.LogWarn("Removed {0} manifests because they were {1}", removedElements, reason);
            }

            return removedElements > 0;
        }
        
        private bool RemoveInvalidManifests(ref List<IManifestInfo> infos)
        {
            return RemoveConditional(ref infos, (m) => !m.IsValid().IsNullOrEmpty(), "invalid");
        }

        // Returns true if changed the list
        private bool RemoveMissingManifests(ref List<IManifestInfo> infos)
        {
            return RemoveConditional(ref infos, (m) => !ManifestsExists(m), "not found");
        }

        private bool ManifestsExists(IManifestInfo info)
        {           
            return (System.IO.File.Exists(info.ContainerPath));
        }

        private void Save()
        {
           ScriptableHelper.Save(this);
        }
    }
}