namespace HG
{
    public interface IPermissionInfo
    {
        string FullName { get; set; }
        bool IsDangerous { get; }
        string Description { get; set; }
        bool IsNormal { get; set; }
        string GetShortName();

        bool Equals(string name);
    }
}