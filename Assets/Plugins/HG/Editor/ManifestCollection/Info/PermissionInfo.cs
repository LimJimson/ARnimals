using System;

namespace HG
{
    public class PermissionInfo : IPermissionInfo
    {
        public PermissionInfo(string fullNameValue, DataHolder.PermissionsData data)
        {
            FullName = fullNameValue;

            var permissionData = data.FindPermissionByShortName(GetShortName());
            if (permissionData != null)
            {
                IsDangerous = permissionData.IsDangerous();
                IsNormal = permissionData.IsNormal();
                Description = permissionData.Description;
            }
        }

        public string FullName { get; set; }

        public bool IsDangerous { get; private set; }
        public string Description { get; set; }
        public bool IsNormal { get; set; }

        // returns the part after the last '.'
        public string GetShortName()
        {
            var index = FullName.LastIndexOf('.');
            if (index == -1) return FullName;
            return FullName.Substring(index + 1, FullName.Length - index - 1);
        }

        public bool Equals(string name)
        {
            return FullName.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                   GetShortName().Equals(name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}