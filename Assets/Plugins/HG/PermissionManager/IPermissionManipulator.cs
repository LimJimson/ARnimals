using System.Collections.Generic;
using HG;

namespace HG
{
    public enum AddPermissionResult
    {
        OK,
        AlreadyExists,
        Invalid
    }

    public interface IPermissionsManipulator : ICollectionManipulator
    {
        IEnumerable<IPermissionInfo> GetAllPermissions();
        void RemovePermission(IPermissionInfo permission);
        AddPermissionResult AddPermission(string text);
    }
}