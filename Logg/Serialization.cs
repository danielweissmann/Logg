using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Logg
{
    public class StringWriterUtf8 : System.IO.StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

    public class Serialization
    {
        public static bool Serialize<T>(T value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T), "");
                //StringWriter stringWriter = new StringWriter();
                StringWriterUtf8 stringWriter = new StringWriterUtf8();
                XmlWriter writer = XmlWriter.Create(stringWriter);

                xmlserializer.Serialize(writer, value);

                serializeXml = stringWriter.ToString();

                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T Deserialize<T>(string xmlString)
        {
            Type conversionType = typeof(T);

            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(conversionType);
            var instance = (T)serializer.Deserialize(reader);

            return (T)Convert.ChangeType(instance, conversionType);
        }
    }
}
