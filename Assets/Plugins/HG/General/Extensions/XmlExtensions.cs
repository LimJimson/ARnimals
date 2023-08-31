using System;
using System.IO;
using System.Text;
using System.Xml;

namespace HG.Extensions
{
    public static class XmlExtensions
    {
        public static string StringOrDefault(this XmlAttribute attr, string defaultValue = null)
        {
            if (attr == null) return defaultValue;

            return attr.Value;
        }

        public static bool BoolOrDefault(this XmlAttribute attr, bool defaultValue = false)
        {
            if (attr == null) return defaultValue;

            bool resultBool;
            if (bool.TryParse(attr.Value, out resultBool))
            {
                return resultBool;
            }
            else
            {
                return defaultValue;
            }

        }
        
        public static String ToPrettyXml(this XmlDocument document)
        {
            if (document == null) return "";
            
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);

            try
            {

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }
    }
}
