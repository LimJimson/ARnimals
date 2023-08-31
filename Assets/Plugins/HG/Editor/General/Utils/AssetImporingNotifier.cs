using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HG.Extensions;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public class FilesChange
    {
        public IEnumerable<string> Deleted = new List<string>();
        public IEnumerable<string> Updated = new List<string>(); // Update or Created files
        public IEnumerable<KeyValuePair<string, string>> Moved = new List<KeyValuePair<string, string>>(); // from, to

        public bool AnyChanged()
        {
            return Deleted.Any() || Updated.Any() || Moved.Any();
        }
    }

    public interface IFileChangeNotifier
    {
        event Action<FilesChange> OnKnownFilesChanged;
    }
    
    public interface IAssetProcessor
    {
        void ProcessAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths);
    }

    public class BaseAssetProcessor : IFileChangeNotifier, IAssetProcessor
    {
        public event Action<FilesChange> OnKnownFilesChanged;
        
        public virtual void ProcessAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            var change = new FilesChange();

            change.Deleted = Match(deletedAssets);
            change.Updated = Match(importedAssets);

            var moved = new List<KeyValuePair<string, string>>();
            for (var index = 0; index < movedFromAssetPaths.Length; index++)
            {
                var asset = movedFromAssetPaths[index];
                if (Match(asset))
                {
                    moved.Add(new KeyValuePair<string, string>(movedFromAssetPaths[index], movedAssets[index]));
                    break;
                }
            }

            change.Moved = moved;

            if (change.AnyChanged())
            {
                OnKnownFilesChanged.InvokeSafe(change);
            }
        }

        private IEnumerable<string> Match(string[] assets)
        {
            var list = new List<string>();
            foreach (var asset in assets)
            {
                if (Match(asset))
                {
                    list.Add(asset);
                }
            }

            return list;
        }

        protected virtual bool Match(string path)
        {
            return true;
        }

        protected static string NormalizePath(string path)
        {
            return Path.GetFullPath(path)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();
        }
    }

    public interface IKnownListNotifier : IFileChangeNotifier, IAssetProcessor
    {
        void RegisterKnownList(Func<IEnumerable<string>> knownListDelegate);
        void UnregisterKnownList(Func<IEnumerable<string>> knownListDelegate);
    }

    public class KnownListNotifier : BaseAssetProcessor, IKnownListNotifier
    {
        private Func<IEnumerable<string>> _knownListDelegate;
        private IEnumerable<string> _cachedNormalizedList = null;
        
        public void RegisterKnownList(Func<IEnumerable<string>> knownListDelegate)
        {
            _knownListDelegate = knownListDelegate;
        }

        public void UnregisterKnownList(Func<IEnumerable<string>> knownListDelegate)
        {
            _knownListDelegate = null;
        }

        public override void ProcessAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            // cache the list for all the Match() calls
            if(_knownListDelegate == null) return;
            var knownList = _knownListDelegate.Invoke();
            if (knownList == null) return;
            _cachedNormalizedList = knownList.Select(NormalizePath);
            
            base.ProcessAssets(importedAssets, deletedAssets, movedAssets, movedFromAssetPaths);
            _cachedNormalizedList = null;
        }

        protected override bool Match(string path)
        {
            var normalizedPath = NormalizePath(path);
            
            foreach (var knownNormalizedPath in _cachedNormalizedList)
            {
                if (normalizedPath == knownNormalizedPath)
                {
                    return true;
                }
            }

            return false;
        }
    }
    
    public class FileExtensionNotifier: BaseAssetProcessor
    {
        private List<string> extensions = new List<string>();
        
        public void AddExtension(string extension)
        {
            extensions.Add(extension.ToLower());
        }

        protected override bool Match(string path)
        {
            foreach (var extension in extensions)
            {
                if (path.ToLower().EndsWith(extension))
                {
                    return true;
                }
            }

            return false;

        }
    }

    class AssetImporingNotifier : AssetPostprocessor
    {
        private static List<IAssetProcessor> _processors = new List<IAssetProcessor>();
        
        public static void AddProcessor(IAssetProcessor processor)
        {
            _processors.Add(processor);
        }

        public static void RemoveProcessor(IAssetProcessor processor)
        {
            _processors.Remove(processor);
        }

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            for (var index = 0; index < _processors.Count; index++)
            {
                var processor = _processors[index];
                processor.ProcessAssets(importedAssets, deletedAssets, movedAssets, movedFromAssetPaths);
            }
        }
    }

    public class SuspendableFileChangeNotifier : IFileChangeNotifier
    {
        public event Action<FilesChange> OnKnownFilesChanged;
        
        private readonly IFileChangeNotifier _notifier;
        private bool _suspended = false;

        public SuspendableFileChangeNotifier(IFileChangeNotifier notifier)
        {
            _notifier = notifier;
            _notifier.OnKnownFilesChanged += FilesChanged;
        }

        private void FilesChanged(FilesChange change)
        {
            if (!_suspended)
            {
                OnKnownFilesChanged.InvokeSafe(change);
            }
        }

        public void SetSuspended(bool suspended)
        {
            Debug.Assert(_suspended != suspended);
            _suspended = suspended;
        }
        
    }
}