using HG.Extensions;

namespace HG
{
    public static class ManifestConditionChecker
    {
        public static bool InAndroidFolder(string path)
        {
            return path.StartsWithAny("Assets/Plugins/Android/", "/Assets/Plugins/Android/");
        }
    }
}