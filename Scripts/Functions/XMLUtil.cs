using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

public class XmlUtil
{
    public enum LoadFrom
    {
        Unspecified = 0,
        StreamingAssets,

        ItemNum
    }

    // シリアライズ
    public static string Seialize<T>(T data, bool useContract = false)
    {
        using (var writer = new StringWriter())
        {
            if (!useContract)
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, data);
            }
            else
            {
                var serializer = new DataContractSerializer(typeof(T));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new System.Text.UTF8Encoding(false);
                XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
                serializer.WriteObject(xmlWriter, data);
                xmlWriter.Close();
            }

            return writer.ToString();
        }
    }

    // デシリアライズ
    public static T Deserialize<T>(string xmlData, bool useContract = false)
    {
        XmlReader reader = XmlReader.Create(new StringReader(xmlData));
        if (!useContract)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }
        else
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(reader);
        }
    }
}