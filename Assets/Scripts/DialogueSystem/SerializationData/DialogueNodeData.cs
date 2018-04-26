using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("DialogueNode")]
    public class DialogueNodeData
    {
        [XmlElement("Id")] public int Id { get; set; }
        [XmlElement("Title")] public string Title { get; set; }
        [XmlElement("Content")] public string Content { get; set; }
    }
}