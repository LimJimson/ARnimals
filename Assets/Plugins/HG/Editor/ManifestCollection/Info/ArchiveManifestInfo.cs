using System;
using System.IO;
using System.Xml;
using HG.Extensions;
using HG.Window;
using Ionic.Zip;
using UnityEditor;

namespace HG
{
    public class ArchiveManifestInfo : ManifestInfo
    {
        public static readonly string[] ArchiveExtensions = {"aar", "jar"};

        private const string ManifestXml = "AndroidManifest.xml";
        
        public ArchiveManifestInfo(string manifestPath) : base(manifestPath)
        {
        }

        public override string XmlPath
        {
            get { return base.XmlPath + "/" + ManifestXml; }
        }

        public override string ContainerPath
        {
            get { return _path; }
        }

        public override bool IsPrimary()
        {
            return false; // there is no way they are in the main manifest path
        }

        public override XmlDocument GetXML()
        {
            using (ZipFile file = new ZipFile(_path))
            {
                if (file.ContainsEntry(ManifestXml))
                {
                    var xml = file[ManifestXml];
                
                    using (var stream = xml.OpenReader())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            XmlDocument xmlDoc = new XmlDocument(); 
                            xmlDoc.LoadXml(reader.ReadToEnd());
                            return xmlDoc;
                        }
                    }
                }
            }

            HGLogger.LogError("failed to find manifest inside " + ContainerPath);
            return null;
        }
        

        public override void SetXML(XmlDocument xmlDoc)
        {
            ShowConfirmDialog(() =>
            {
                using (ZipFile file = new ZipFile(_path))
                {
                    if (file.ContainsEntry(ManifestXml))
                    {
                        file.UpdateEntry(ManifestXml, xmlDoc.ToPrettyXml());
                        file.Save();
                        AssetDatabase.ImportAsset(ContainerPath);
                    }
                }
            });
            

        }
/*
 *“Are you sure you want to delete com.android.PERMISSION_NAME from /Assets/Plugins/Android/plugin.jar? This may effect its functionality“
 * 
 */
        private void ShowConfirmDialog(Action OnConfirm)
        {
            DisplayDialog.Create("Modify xml inside an archive?", "Are you sure you want to modify the AndroidManifest.xml inside the " + _path + "?\nThis may affect its functionality", "OK", () =>
            {
                OnConfirm.InvokeSafe();
            }, "Cancel");   
        }

        public override string IsValid()
        {
            string error = base.IsValid();
            if (!error.IsNullOrEmpty()) return error;
                  
            using (ZipFile file = new ZipFile(_path))
            {
                if (!file.ContainsEntry(ManifestXml))
                {
                    return string.Format("{0} wasn't found in {1}", ManifestXml, ContainerPath);
                }
            }

            return null;
        }
    }
}