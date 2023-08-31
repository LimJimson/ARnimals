using System;
using System.Collections.Generic;
using System.Xml;

namespace HG.ManifestManipulator.Changers
{
    public static class ManifestXmlExtensions
    {

        private static XmlElement CreateManifestElement(this XmlDocument xmlDoc, string elementName, string name, string value = null)
        {
            var elem = xmlDoc.CreateElement(elementName);
            // @LATER namespace may be not present - then should add it (or better fix all that when adding a manifest)
            elem.SetAttribute("name", xmlDoc.DocumentElement.Attributes["xmlns:android"].Value, name);

            if (value != null)
            {
                elem.SetAttribute("value", xmlDoc.DocumentElement.Attributes["xmlns:android"].Value, value);
            }

            return elem;
        }

        public static void AddManifestElement(this XmlDocument xmlDoc, string elementName, string name, string value = null)
        {
            var elem = xmlDoc.CreateManifestElement(elementName, name, value);

            // @LATER someone could have added an empty file
            xmlDoc.DocumentElement.AppendChild(elem);
        }

        public static void AddMetaData(this XmlDocument xmlDoc, string name, string value)
        {
            // @LATER check there is only one application & add application if no application found

            XmlNode application;
            
            var applicationNodes = xmlDoc.GetElementsByTagName("application");
            if (applicationNodes.Count != 0)
            {
                application = xmlDoc.GetElementsByTagName("application")[0];
            }
            else
            {
                var appElem = xmlDoc.CreateElement("application");
                // @LATER - fix what if no FirstChild was found
                application = xmlDoc.DocumentElement.AppendChild(appElem);
            }


            var elem = xmlDoc.CreateManifestElement("meta-data", name, value);
            
            application.AppendChild(elem);
        }

        // removes all mentions of this element where value of "android:name" == name
        public static bool RemoveManifestElementByName(this XmlDocument xmlDoc, string elementName, string name)
        {
            bool removed = false;
            List<XmlNode> toRemove = new List<XmlNode>();
            
            var elements = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode element in elements)
            {
                if (element.Attributes == null) continue;
                
                XmlAttribute xmlName = element.Attributes["android:name"];
                
                if (xmlName.Value.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    toRemove.Add(element);
                }
            }

            foreach (var element in toRemove)
            {
                if (element.ParentNode != null)
                {
                    element.ParentNode.RemoveChild(element);
                }

                removed = true;
            }

            return removed;
        }
    }
}