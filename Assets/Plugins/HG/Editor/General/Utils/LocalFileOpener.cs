using System;
using System.Linq;
using HG;
using HG.Extensions;

namespace Plugins.HG.Editor.General.Utils
{
    public static class LocalFileOpener
    {
        public static void OpenLocalFile(string relativeFilePath, string uniqueFileName = null)
        {
            var path = GetPathToOpen(relativeFilePath, uniqueFileName);

            if (path.IsNullOrEmpty())
            {
                HGLogger.LogError("Couldn't find file at path: {0}", relativeFilePath);
                return;
            }

            AssetHelper.OpenLocalFile(path);
        }

        private static string GetPathToOpen(string relativeFilePath, string uniqueFileName = null)
        {
            if (AssetHelper.ExistsInAssets(relativeFilePath))
            {
                return relativeFilePath;
            }
            else if(uniqueFileName != null)
            {
                var path = FindRelativePath(uniqueFileName);

                if (path != null)
                {
                    return path;
                }
            }

            return null;
        }

        private static string FindRelativePath(string uniqueFilename){
            var pathsProvider = new UnityPathsProvider();
            var foundPaths = pathsProvider.GetPathsByName(uniqueFilename);
            if (foundPaths.Length == 1)
            {
                var selectedPath = foundPaths.First();
                selectedPath = selectedPath.RemoveStartSubStr("Assets");
                selectedPath = selectedPath.RemoveStartSubStr("/Assets");

                return selectedPath;
            }
            else
            {
                return null;
            }
        }
    }
    
    
}