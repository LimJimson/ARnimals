using System;
using System.Collections.Generic;
using System.Xml;

namespace HG.ManifestManipulator.Changers
{
    // <meta-data android:name="unityplayer.SkipPermissionsDialog" android:value="true" />
    
    // @LATER add a meta-data Changer and just use its methods
    // @LATER test if unity things that when no "android:value="true"" -- will it count as true or false? (& write a test for it)
    public static class SkipPermissionsDialogChanger
    {
        private const string UnityPlayerSkipPermissionsDialog = "unityplayer.SkipPermissionsDialog";

        public static bool IsPermissionDialogsSkipped(IManifestInfo manifestInfo)
        {
            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return false;
            var metas = xmlDoc.GetElementsByTagName("meta-data");

            foreach (XmlNode data in metas)
            {
                XmlAttribute name = data.Attributes["android:name"];
                if(name == null) continue;

                if (name.Value.Equals(UnityPlayerSkipPermissionsDialog, StringComparison.InvariantCultureIgnoreCase))
                {
                    XmlAttribute value = data.Attributes["android:value"];
                    if(value == null) continue; // Note: we count no value as false, so just continue looking

                    if (value.Value == "true") return true;
                }
            }

            return false;
            
        }

        public static void AddSkipPermissionDialog(IManifestInfo manifestInfo)
        {
            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return;

            xmlDoc.AddMetaData(name: UnityPlayerSkipPermissionsDialog, value: "true");

            manifestInfo.SetXML(xmlDoc);
        }

        // @LATER remove all mentions in Manifest file, not just one
        public static void RemoveSkipPermissionDialog(IManifestInfo manifestInfo)
        {
            var xmlDoc = manifestInfo.GetXML();
            if (xmlDoc == null) return;
            
            var removedAny = xmlDoc.RemoveManifestElementByName("meta-data", UnityPlayerSkipPermissionsDialog);
            if (removedAny)
            {
                manifestInfo.SetXML(xmlDoc);
            }
        }
    }
}