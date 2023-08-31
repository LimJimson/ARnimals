using System.Collections.Generic;
using System.Xml;
using HG;
using UnityEditor;
using UnityEngine;

namespace HG.ManifestManipulator.Changers
{
    public static class PermissionsChanger
    {
        public static List<IPermissionInfo> GetPermisions(IManifestInfo manifestInfo, DataHolder.PermissionsData permissionsData)
        {
            var resultPermissions = new List<IPermissionInfo>();

            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return resultPermissions;
         
            var permissions = xmlDoc.GetElementsByTagName("uses-permission");

            foreach (XmlNode permission in permissions)
            {
                XmlAttribute name = permission.Attributes["android:name"];
                if(name == null) continue;

                resultPermissions.Add(new PermissionInfo(name.Value, permissionsData));
            }
            

            return resultPermissions;
        }

        public static void RemovePermission(IManifestInfo manifestInfo, IPermissionInfo permission)
        {
            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return;
            
            bool removedAny = xmlDoc.RemoveManifestElementByName("uses-permission", permission.FullName);

            if (removedAny)
            {
                manifestInfo.SetXML(xmlDoc);
            }
        }

        public static void AddPermission(IManifestInfo manifestInfo, string text)
        {
            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return;

            xmlDoc.AddManifestElement("uses-permission", name: text);

            manifestInfo.SetXML(xmlDoc);

        }
    }
}