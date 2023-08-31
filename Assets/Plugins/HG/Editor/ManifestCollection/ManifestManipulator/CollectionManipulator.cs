using System;
using System.Collections.Generic;
using HG.Extensions;

namespace HG.ManifestManipulator
{
    public class CollectionManipulator : ICollectionManipulator
    {
       
        public event Action OnRefreshRequired;
        
        protected IList<IManifestInfo> _manifests;
        protected IManifestCollection _collection;

        public CollectionManipulator(IManifestCollection collection, IList<IManifestInfo> manifests)
        {
            _collection = collection;
            _manifests = manifests;
            
            _collection.OnManifestListChanged += delegate { OnRefreshRequired.InvokeSafe(); };
        }

        protected void RequireRefresh()
        {
            OnRefreshRequired.InvokeSafe();
        }

        protected IManifestInfo GetAdditionManifest()
        {
            var target = ManifestCreator.GetAdditionManifest(_manifests, _collection);
            _collection.Add(target); 
            return target;
        }

        public void Dispose()
        {
            OnRefreshRequired = null;
        }
    }
}