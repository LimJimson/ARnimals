using System.Collections.Generic;
using System.IO;
using System.Linq;
using HG.General.Utils;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public static class ManifestCreator
    {
        // returns the manifestInfo to which things should be added
        public static IManifestInfo GetAdditionManifest(IList<IManifestInfo> _manifests, IManifestCollection manifestCollection)
        {
            var selectedManifest = FindExistngManifest(_manifests);

            if (selectedManifest != null)
            {
                FixManifest(selectedManifest);
            }
            else
            {
                selectedManifest = CreateNewPrimaryManifest();
                manifestCollection.Add(selectedManifest); // we just created or found a new one, so add it
            }

            return selectedManifest;
        }

        
        private static void FixManifest(IManifestInfo selectedManifest)
        {
        }

        // Note: don't use anything aside from primary manifest because they may be inside some library user will want to remove later
        private static IManifestInfo FindExistngManifest(IList<IManifestInfo> _manifests)
        {
            foreach (var manifest in _manifests)
            {
                if (manifest.IsPrimary())
                {
                    return manifest;
                }
            }

            return null;
        }

        // Create a file and returns its ManifestInfo
        private static ManifestInfo CreateNewPrimaryManifest()
        {
            var manifestPath = ManifestInfo.PrimaryManifestPath;
                       
            // Only create new if file doesn't already exist
            if (AssetDatabase.LoadAssetAtPath<TextAsset>(manifestPath) == null)
            {
                FileHelper.CreateDirectory("Assets/Plugins/Android/");
                File.WriteAllText(manifestPath, GetTemplateManifestText());
                AssetDatabase.ImportAsset(manifestPath);
                
                HGLogger.LogInfo("Created a new manifest at '{0}'", manifestPath);
            }
            else
            {
                HGLogger.LogInfo("Started using manifest at '{0}'", manifestPath);
            }

            var newManifest = new ManifestInfo(manifestPath);
            Debug.Assert(newManifest.IsPrimary(), "Created manifest should be a primary one");
            
            return newManifest;
        }

        private static string GetTemplateManifestFilename()
        {
            #if UNITY_2018_1_OR_NEWER
                return "APM_Manifest2018UpTemplate";
            #else
                return "APM_ManifestTemplate";
            #endif
        }

        private static string GetTemplateManifestText()
        {
            var paths = new UnityPathsProvider().GetPathsByName(GetTemplateManifestFilename());
            Debug.Assert(paths.Length == 1, "There should be only one APM_ManifestTemplate file");
            
            string manifestPath = paths.First();
            var textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(manifestPath);
            if (textAsset != null)
            {
                return textAsset.text;
            }
            else
            {
                HGLogger.LogError(manifestPath + " wasn't found");
                return null;
            }
        }
    }
}