using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("DialogueOption")]
    public class DialogueOptionData
    {
        [XmlElement("Id")] public int Id { get; set; }
        [XmlElement("Content")] public string Content { get; set; }
    }
}