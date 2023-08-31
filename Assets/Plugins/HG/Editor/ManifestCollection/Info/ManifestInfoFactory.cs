using System.Linq;
using HG.Extensions;
using System.Collections.Generic;

namespace HG
{
    public static class ManifestInfoFactory
    {
        public static IManifestInfo CreateManifestInfo(string path)
        {
            var extensions = ArchiveManifestInfo.ArchiveExtensions.ToList().ConvertAll(m => string.Format(".{0}", m));
            if (path.EndsWithAny(extensions.ToArray()))
            {
                return new ArchiveManifestInfo(path);
            }
            else
            {
                return new ManifestInfo(path);   
            }
        }
    }
}