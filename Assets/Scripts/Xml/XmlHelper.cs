using System.Text;

namespace Assets.Scripts.Xml
{
    public static class XmlHelper
    {     
        public static string ByteArrToString(byte[] bytes) 
        {      
            UTF8Encoding encoding = new UTF8Encoding(); 
            return encoding.GetString(bytes); 
        } 
 
        public static byte[] StringToByteArr(string xmlString) 
        { 
            UTF8Encoding encoding = new UTF8Encoding(); 
            return encoding.GetBytes(xmlString); 
        } 
    }
}