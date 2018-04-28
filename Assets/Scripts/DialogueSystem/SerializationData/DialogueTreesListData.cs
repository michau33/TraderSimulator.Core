using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlInclude(typeof(DialogueTreeData))]
    [XmlRoot("trees")]
    public class DialoguesTreesListData
    {
        [XmlElement("tree")] public DialogueTreeData[] DialogueTrees;
    }
}