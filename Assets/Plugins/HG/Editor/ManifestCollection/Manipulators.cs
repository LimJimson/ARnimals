using System;
using HG.ManifestManipulator;
using UnityEngine;

namespace HG
{
    public class Manipulators : IDisposable
    {
        private readonly IManifestCollection _collection;
        
        public IPermissionsManipulator PermissionsManipulator { get; private set; }
        public ISkipPermissionsDialogManipulator SkipPermissionsDialogManipulator { get; private set; }

        public Manipulators(IManifestCollection collection, DataHolder data)
        {
            _collection = collection;
            
            PermissionsManipulator = new PermissionsManipulator(_collection, _collection.GetAllManifests(), data.Permissions);
            SkipPermissionsDialogManipulator = new SkipPermissionsDialogManipulator(_collection, _collection.GetAllManifests());
        }


        public void Dispose()
        {
            PermissionsManipulator.Dispose();
            SkipPermissionsDialogManipulator.Dispose();
        }
    }
}