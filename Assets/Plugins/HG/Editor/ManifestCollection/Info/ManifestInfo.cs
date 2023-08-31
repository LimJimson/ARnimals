using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using HG.Extensions;
using HG.Utils;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public interface IManifestInfo
    {
        string XmlPath { get; }
        string ContainerPath { get; }
        bool IsPrimary();

        // can return null if reading XML failed
        XmlDocument GetXML();
        void SetXML(XmlDocument doc);
        string IsValid(); // returns non empty string of error that happened if invalid
    }

    [Serializable]
    public class ManifestInfo : IManifestInfo
    {
        public virtual string XmlPath
        {
            get { return _path; }
        }

        public virtual string ContainerPath
        {
            get { return XmlPath; }
        }

        [SerializeField]
        protected string _path;

        public ManifestInfo(string manifestPath)
        {
            _path = manifestPath.RemoveStartSubStr("/");
        }
        
        public static string PrimaryManifestPath = "Assets/Plugins/Android/AndroidManifest.xml";

        public virtual bool IsPrimary()
        {
            return XmlPath.EndsWith("Plugins/Android/AndroidManifest.xml") || XmlPath.EndsWith("Plugins/android/AndroidManifest.xml");
        }

        public virtual XmlDocument GetXML()
        {
            XmlDocument xmlDoc = new XmlDocument(); 

            try
            {
                if (!File.Exists(XmlPath))
                {
                    HGLogger.LogError("no file found at path: " + XmlPath);
                    return null;
                }

                var stream = new FileStream(XmlPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (var reader = new StreamReader(stream)){

                    var xmlFile = reader.ReadToEnd();
                    
                    // @TODO fix what happens if this returns null outside
                    xmlDoc.LoadXml(xmlFile);
                    return xmlDoc;
                }
            }
            catch (Exception e)
            {
                HGLogger.LogError("failed to read manifest xml at path: " + XmlPath + " with error: " + e);
                return null;
            }
        }

        public virtual void SetXML(XmlDocument xmlDoc)
        {
            xmlDoc.Save(XmlPath);
            AssetDatabase.ImportAsset(XmlPath);
        }

        public virtual string IsValid()
        {
            return null;
        }
    }


}