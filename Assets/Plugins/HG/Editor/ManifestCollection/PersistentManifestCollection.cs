using System;
using System.Collections.Generic;
using System.Linq;
using HG.Extensions;
using HG.ManifestManipulator;
using UnityEditor;

namespace HG
{
    public class PersistentManifestCollection : IManifestCollection
    {
        public event Action OnManifestListChanged;

        private IManifestCollection _collection;
        private AndroidManifestToolSettings _settings;

        public PersistentManifestCollection(IManifestCollection collection, AndroidManifestToolSettings settings)
        {
            _collection = collection;
            _settings = settings;

            _collection.OnManifestListChanged += () =>
            {
                OnManifestListChanged.InvokeSafe();
            };
        }


        public AddManifestResultHolder Add(IManifestInfo manifest)
        {
            var result =_collection.Add(manifest);

            if (result.Result == AddManifestResult.OK)
            {
                Save();
            }
            
            return result;
        }

        public void Remove(IManifestInfo manifest)
        {
            _collection.Remove(manifest);
            Save();
        }

        public IList<IManifestInfo> GetAllManifests()
        {
            return _collection.GetAllManifests();
        }

        private void Save()
        {
            _settings.SetManifests(_collection.GetAllManifests().ToList());
        }

        public void Dispose()
        {
            if (_collection != null) _collection.Dispose();
            OnManifestListChanged = null;
        }
    }
}