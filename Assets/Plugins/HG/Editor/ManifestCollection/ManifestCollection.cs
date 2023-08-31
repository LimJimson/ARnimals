using System;
using System.Collections.Generic;
using System.Linq;
using HG.Extensions;
using HG.ManifestManipulator;
using UnityEngine;

namespace HG
{
    public class ManifestCollection : IManifestCollection
    {
        public event Action OnManifestListChanged;

        private List<IManifestInfo> _manifests;
        private readonly IKnownListNotifier _assetNotifier;
        private bool _listChangeNotificationSuspended; // allows to stop notifications until we process all changes

        public ManifestCollection(List<IManifestInfo> manifests, IKnownListNotifier assetNotifier)
        {
            _manifests = manifests ?? new List<IManifestInfo>();
            _assetNotifier = assetNotifier;
            AssetImporingNotifier.AddProcessor(_assetNotifier);
            SetupFileNotifier(assetNotifier);
        }

        private void SetupFileNotifier(IKnownListNotifier assetNotifier)
        {
            assetNotifier.RegisterKnownList(GetManagedFiles);
            assetNotifier.OnKnownFilesChanged += OnKnownFilesChanged;
        }

        private void OnKnownFilesChanged(FilesChange filesChange)
        {
            _listChangeNotificationSuspended = true; // @LATER try to move this out of this class, mb create an action with ability to be disabled, so that I don't need to call Invoke inderectly
            filesChange.Deleted.ToList().ForEach(OnAssetNotifierOnFileDeleted);
            //filesChange.Updated.ToList().ForEach(OnAssetNotifierOnFileChanged);
            filesChange.Moved.ToList().ForEach((kv)=> OnAssetNotifierOnFileMoved(kv.Key, kv.Value));
            
            _listChangeNotificationSuspended = false;
            ThrowListChangedEvent();
        }

        private void OnAssetNotifierOnFileMoved(string from, string to)
        {
            var movedManifest = _manifests.Find(m => m.ContainerPath == from);

            // if will be implemented by a change of path, don't forget to check if path is still valid
            Remove(movedManifest);
            Add(ManifestInfoFactory.CreateManifestInfo(to)); 
        }

        private void ThrowListChangedEvent()
        {
            if(!_listChangeNotificationSuspended){
                OnManifestListChanged.InvokeSafe();
            }
        }

        private void OnAssetNotifierOnFileDeleted(string filePath)
        {
            var deletedManifest = _manifests.Find(m => m.ContainerPath == filePath);
            if (deletedManifest == null) return;
            Remove(deletedManifest);
        }

        // returns all the files we care about
        private IEnumerable<string> GetManagedFiles()
        {
            return _manifests.ConvertAll(m => m.ContainerPath);
        }

        // @LATER change to just getting the path
        public AddManifestResultHolder Add(IManifestInfo manifest)
        {            
            var resultHolder = CanAdd(manifest);

            if (resultHolder.Result == AddManifestResult.OK)
            {               
                _manifests.Add(manifest);

                ThrowListChangedEvent();
            }

            return resultHolder;
        } 
        
        private AddManifestResultHolder CanAdd(IManifestInfo manifest)
        {            
            if(string.IsNullOrEmpty(manifest.XmlPath)) return AddManifestResult.InvalidPath;
            if(!ManifestConditionChecker.InAndroidFolder(manifest.XmlPath)) return AddManifestResult.PathOutsideAndroidFolder;
            if(_manifests.Any(m => m.XmlPath == manifest.XmlPath)) return AddManifestResult.SamePathExists;

            string error = manifest.IsValid();
            if (!error.IsNullOrEmpty())
            {
                return new AddManifestResultHolder(AddManifestResult.InvalidManifest, error);
            }
            
            return  AddManifestResult.OK;
        }

        // Note: does not compare paths, should be the exact instance from the Collection
        public void Remove(IManifestInfo manifest)
        {
            _manifests.Remove(manifest);
            ThrowListChangedEvent();
        }

        // Note: manifests should not be changed via this return value
        public IList<IManifestInfo> GetAllManifests()
        {
            return _manifests;
        }

        // @LATER - actually call the dispose on this and Manipulators (not only in dtor)
        public void Dispose()
        {
            AssetImporingNotifier.RemoveProcessor(_assetNotifier);
            _assetNotifier.UnregisterKnownList(GetManagedFiles);
            _assetNotifier.OnKnownFilesChanged -= OnKnownFilesChanged;
        }
    }
}