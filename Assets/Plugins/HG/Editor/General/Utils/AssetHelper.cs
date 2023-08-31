using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public static class AssetHelper
    {
        public static List<T> FindAssetsByType<T>() where T : UnityEngine.Object
        {
            List<T> assets = new List<T>();
            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T)));
            for( int i = 0; i < guids.Length; i++ )
            {
                string assetPath = AssetDatabase.GUIDToAssetPath( guids[i] );
                T asset = AssetDatabase.LoadAssetAtPath<T>( assetPath );
                if( asset != null )
                {
                    assets.Add(asset);
                }
            }
            return assets;
        }

        // returns null if didn't find
        public static T FindAssetByType<T>() where T : UnityEngine.Object
        {
            var assets = FindAssetsByType<T>();
            
            if (assets.Count == 0) return null;
            Debug.Assert(assets.Count == 1, "There should be only one .asset file of type + " + typeof(T));
            
            return assets[0];
        }

        public static void SelectAssetByType<T>() where T: UnityEngine.Object
        {
            Selection.activeObject = AssetHelper.FindAssetByType<T>();
            // @LATER - what if inspector is not visible
        }

        /// <summary>
        /// path passed in should be relative to Assets folder
        /// </summary>
        public static void OpenLocalFile(string relativePath)
        {
            if (!relativePath.StartsWith("/"))
            {
                relativePath = relativePath.Insert(0, "/");
            }

            string path = Application.dataPath + relativePath;
            
            #if UNITY_EDITOR_OSX
                path = "File://" + path;
            #elif UNITY_EDITOR_WIN
                ; // path already correct        
            #else
                Debug.LogError("Unsupported platform");
            #endif
            
            HGLogger.LogInfo("Opening {0}", relativePath);
            Application.OpenURL (path);    
        }

        public static bool ExistsInAssets(string relativePath)
        {
            if (!relativePath.StartsWith("/"))
            {
                relativePath = relativePath.Insert(0, "/");
            }
            
            var path = Application.dataPath + relativePath;
            return (System.IO.File.Exists(path));
        }
    }
}