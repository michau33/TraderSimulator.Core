using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.Data
{
    [XmlRoot("DialogueTree")]
    public class DialogueTreeData
    {
        [XmlElement("DialogueNode")] public DialogueNodeData[] DialogueNodes { get; set; }
        [XmlAttribute("category")] public string DialogueCategory { get; set; }
        //    public Data DataInstance;

        //    public DialogueTreeData()
        //    {
        //    }

        //    public struct Data
        //    {
        //        [XmlElement("DialogueNode")]
        //        public DialogueNodeData[] DialogueNodes;
        //    }
        //}
    }
}