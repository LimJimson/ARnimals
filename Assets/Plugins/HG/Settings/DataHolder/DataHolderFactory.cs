
using System.Xml;
using UnityEngine;
using HG.Extensions;

namespace HG
{
    public class DataHolderFactory
    {
        public static DataHolder CreateData()
        {
            var data = new DataHolder();

            var xmlDoc = GetXml();
            var root = xmlDoc.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
               
                if (node.LocalName == "Permissions")
                {
                   data.Permissions = GetPermissionsData(node);

                }
            }
            
            
            return data;
        }


        private static XmlDocument GetXml()
        {
            XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.

            var xmlFile = Resources.Load<TextAsset>("permissions_info");
            if (xmlFile != null)
            {
                xmlDoc.LoadXml(xmlFile.text); // load the file.
                return xmlDoc;
            }
            else
            {
                HGLogger.LogError("permissions_info.xml not found");
                return null;
            }
        }

        private static DataHolder.PermissionsData GetPermissionsData(XmlNode node)
        {
            var permissions = new DataHolder.PermissionsData();

            foreach (XmlNode xmlPermission in node.ChildNodes)
            {
                
                //&& xmlPermission.Attributes["dangerous"].BoolOrDefault(false))
                if (xmlPermission != null && xmlPermission.Attributes != null)
                {                    
                    permissions.AllPermissions.Add(
                        new DataHolder.Permission{
                            Category = xmlPermission.Attributes["category"].StringOrDefault(""),
                            ShortName = xmlPermission.Attributes["name"].StringOrDefault(""),
                            FullName = xmlPermission.Attributes["constantValue"].StringOrDefault(""),
                            Description = xmlPermission.Attributes["description"].StringOrDefault(""),
                            ProtectionLevel = xmlPermission.Attributes["protectionLevel"].StringOrDefault("")
                        });
                }
            }
            
            return permissions;
        }
    }
}