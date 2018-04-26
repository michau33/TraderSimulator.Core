using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("DialogueTrees")]
    public class DialoguesTreesListData
    {
        [XmlElement("DialogueTree")]
        public DialogueTreeData[] DialogueTrees;
    }
}