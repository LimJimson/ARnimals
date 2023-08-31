using System;
using System.Collections.Generic;
using HG.ManifestManipulator;

namespace HG
{
    public enum AddManifestResult
    {
        OK,
        SamePathExists,
        InvalidPath,
        PathOutsideAndroidFolder,
        InvalidManifest
    }

    public class AddManifestResultHolder
    {
        public AddManifestResultHolder(AddManifestResult result, string errorMessage = null)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }

        public AddManifestResult Result;
        public readonly string ErrorMessage = null; // optional message about what exactly happened
        
        public static implicit operator AddManifestResultHolder(AddManifestResult result)
        {
            return new AddManifestResultHolder(result);
        }
    }

    public interface IManifestCollection : IDisposable
    {
        event Action OnManifestListChanged;
        AddManifestResultHolder Add(IManifestInfo manifest);
        void Remove(IManifestInfo manifest);
        
        // @LATER - somehow return a readonly list (IReadOnlyList & IImmutableList are only 4.5+)
        IList<IManifestInfo> GetAllManifests();
    }
}