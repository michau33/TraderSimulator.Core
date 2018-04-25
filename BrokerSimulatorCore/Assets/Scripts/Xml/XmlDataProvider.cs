using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Xml
{
    //TODO test this class
    public class XmlDataProvider : IXmlDataProvider
    {
        public string SerializeObject<T>(object obj)
        {
            string xmlString = null;

            var memoryStream = new MemoryStream();
            var serializer = new XmlSerializer(typeof(T));
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                
            serializer.Serialize(xmlTextWriter, obj);
            memoryStream = xmlTextWriter.BaseStream as MemoryStream;

            if (memoryStream != null) 
                xmlString = XmlHelper.ByteArrToString(memoryStream.ToArray());

            return xmlString;
        }

        public object DeserializeObject<T>(string xmlString)
        {
            byte[] bytes = XmlHelper.StringToByteArr(xmlString);

            var serializer = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream(bytes);
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
           
            return serializer.Deserialize(memoryStream);
        }

        public void CreateXmlFileOutput(string fileLocation, string fileName, string data)
        {
            StreamWriter writer;
            FileInfo fileInfo = new FileInfo(fileLocation + "\\" + fileName);

            if (fileInfo.Exists)
            {
                writer = fileInfo.CreateText();
            }
            else
            {
                fileInfo.Delete();
                writer = fileInfo.CreateText();
            }

            writer.Write(data);
            writer.Close();
        }

        public string LoadDataFromXml(string fileLocation, string fileName)
        {
            using (StreamReader r = File.OpenText(fileLocation + "\\" + fileName))
            {
                string data = r.ReadToEnd();
                return data;
            }
        }
    }
}