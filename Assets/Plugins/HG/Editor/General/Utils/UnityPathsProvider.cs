using System.IO;
using System.Runtime.CompilerServices;
using HG.Extensions;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace HG
{
    public class UnityPathsProvider : IPathsProvider
    {
        public string[] GetPathsByName(string filter)
        {
            var guids = AssetDatabase.FindAssets(filter);

            string[] paths = new string[guids.Length];
            for (var index = 0; index < guids.Length; index++)
            {
                paths[index] = AssetDatabase.GUIDToAssetPath(guids[index]);
            }

            return paths;
        }

        public string[] GetPathsByExtension(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
                return null;

            if (fileExtension.First() == '*')
                fileExtension = fileExtension.Substring(1);
            
            if (fileExtension.First() == '.')
                fileExtension = fileExtension.Substring(1);

            DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*." + fileExtension, SearchOption.AllDirectories);

            List<string> paths = new List<string>();
            foreach (var file in fileInfos)
            {
                var assetPath = file.FullName.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
                paths.Add(assetPath);
            }

            return paths.ToArray();
        }
    }
}