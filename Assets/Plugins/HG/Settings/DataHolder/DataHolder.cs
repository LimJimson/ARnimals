using System;
using System.Collections.Generic;

namespace HG
{
    public class DataHolder
    {

        public class Permission
        {
            public string Category;
            public string ShortName;

            public string Description;
            public string FullName;

            public string ProtectionLevel;

            public bool IsDangerous()
            {
                return ProtectionLevel.Contains("dangerous");
            }
            
            public bool IsNormal()
            {
                return ProtectionLevel.Contains("normal");
            }
        }

        public class PermissionsData
        {
            public List<Permission> AllPermissions = new List<Permission>();

            public List<Permission> GetAllPermissions()
            {
                return AllPermissions;
            }

            // Note: returns null if not found
            public Permission FindPermissionByShortName(string shortName)
            {
                return AllPermissions.Find(p => p.ShortName == shortName);
            }
            
            // Note: returns null if not found
            public Permission FindPermissionByFullName(string fullName)
            {
                return AllPermissions.Find(p => p.FullName == fullName);
            }

            public IList<Permission> FindPermissionsByCategory(string categoryName)
            {
                return AllPermissions.FindAll(p => p.Category.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public PermissionsData Permissions;
    }
}