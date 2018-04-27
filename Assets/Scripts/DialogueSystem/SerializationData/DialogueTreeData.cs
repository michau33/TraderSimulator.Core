using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("DialogueTree")]
    public class DialogueTreeData
    {
        [XmlElement("DialogueNode")] public DialogueNodeData[] DialogueNodes { get; set; }
        [XmlAttribute("Id")] public int DialogueId { get; set; }
        [XmlAttribute("category")] public string DialogueCategory { get; set; }
    }
}