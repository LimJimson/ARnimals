namespace HG
{
    public interface IPathsProvider
    {
        string[] GetPathsByName(string filter);
        string[] GetPathsByExtension(string fileExtension);
    }
}