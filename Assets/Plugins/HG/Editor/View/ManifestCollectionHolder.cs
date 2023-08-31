using Assets.Plugins.HG.PermissionManager;
using Plugins.HG.General.Utils;
using UnityEngine;
using UnityEditor;

namespace HG
{
    [InitializeOnLoad]
    public class ManifestCollectionHolder
    {
        private static IManifestCollection _manifestCollection;
        public static IManifestCollection ManifestCollection
        {
            get {
                if (_manifestCollection == null)
                {
                    Setup();
                }

                return _manifestCollection;
            }
        }

        ~ManifestCollectionHolder()
        {
            if(_manipulators != null) _manipulators.Dispose();
            if(_manifestCollection != null) _manifestCollection.Dispose();
            _manipulators = null;
        }

        private static Manipulators _manipulators;
        public static Manipulators Manipulators
        {
            get {
                if (_manipulators == null)
                {
                    Setup();
                }

                return _manipulators;
            }
        }

        static ManifestCollectionHolder()
        {
            EditorApplication.update += RunOnce;
        }

        private static void RunOnce()
        {
            EditorApplication.update -= RunOnce;
            Setup();
        }

        // Need to call this at startup to initialize BehaviourSelector so that Testing can work without EditorWindow opened
        private static void Setup()
        {
            if(_manifestCollection != null) return;
            
            var settings = Load<AndroidManifestToolSettings>("AndroidManifestSettings", "Assets/Plugins/HG/Editor");
            var data = SettingsHolder.Instance.GetDataHolder();

            var model = new ManifestCollection(settings.GetManifests(), new KnownListNotifier());
            _manifestCollection = new PersistentManifestCollection(model, settings);
            _manipulators = new Manipulators(_manifestCollection, data);
            
            BehaviourSelector.Instance.SetManipulators(_manipulators.PermissionsManipulator,
                _manipulators.SkipPermissionsDialogManipulator);
        }
        
        private static T Load<T>(string filename, string path) where T : ScriptableObject
        {           
            var asset = AssetHelper.FindAssetByType<T>();
            
            if (asset == null)
            {
                asset = ScriptableHelper.Create<T>(filename, path);
            }
            
            return asset;
        }
    }
}