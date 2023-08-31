namespace HG
{
    public interface ISkipPermissionsDialogManipulator : ICollectionManipulator
    {
        bool IsPermissionDialogsSkipped();
        void RemoveSkipPermissionDialog();
        void AddSkipPermissionDialog();
    }
}