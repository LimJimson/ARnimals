using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HG.Extensions;
using UnityEngine;

namespace HG
{
    public class ManifestFinder
    {
        private IPathsProvider _pathsProvider;
        
        public ManifestFinder(IPathsProvider pathsProvider)
        {
            _pathsProvider = pathsProvider;
        }

        // fins all manifests inside /Android folder (main + non-archive libraries)
        private IList<IManifestInfo> FindXmlManifests()
        {
            var paths = _pathsProvider.GetPathsByName("AndroidManifest").AsEnumerable();
            
            FilterInvalidFilename(ref paths);
            FilterEditorPaths(ref paths);
            FilterNonAndroidPaths(ref paths);

            return paths.ToList().ConvertAll(path => new ManifestInfo(path) as IManifestInfo);
        }

        // finds all manifests that are inside archive based libraries
        private IList<IManifestInfo> FindArchiveManifests()
        {
            IEnumerable<string> archivePaths = new List<string>();
            foreach (var extension in ArchiveManifestInfo.ArchiveExtensions)
            {
                archivePaths = archivePaths.Concat(_pathsProvider.GetPathsByExtension(extension));
            }
            
            FilterNonAndroidPaths(ref archivePaths);
            FilterEditorPaths(ref archivePaths);
            
            return archivePaths.ToList().ConvertAll(path => new ArchiveManifestInfo(path) as IManifestInfo);
        }

        public IList<IManifestInfo> FindAllManifests()
        {
            var manifests = FindXmlManifests().Concat(FindArchiveManifests());
            FilterInvalidManifests(ref manifests);
            return manifests.ToList();
        }

        private void FilterNonAndroidPaths(ref IEnumerable<string> paths)
        {
            paths = paths.Where(path => ManifestConditionChecker.InAndroidFolder(path) );
        }

        private void FilterEditorPaths(ref IEnumerable<string> paths)
        {
            paths = paths.Where(path => !path.Contains("/Editor/"));
        }

        private void FilterInvalidFilename(ref IEnumerable<string> paths)
        {
            paths = paths.Where(path => path.EndsWith("/AndroidManifest.xml", true, CultureInfo.InvariantCulture));
        }

        private void FilterInvalidManifests(ref IEnumerable<IManifestInfo> manifests)
        {
            manifests = manifests.Where(m =>
            {
                try
                {
                    return m.IsValid().IsNullOrEmpty();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    return false;
                }
            });
        }
    }
}