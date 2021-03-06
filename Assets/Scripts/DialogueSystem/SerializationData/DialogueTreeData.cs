﻿using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("tree")]
    public class DialogueTreeData
    {
        [XmlAttribute("id")] public int DialogueId { get; set; }
        [XmlAttribute("category")] public string DialogueCategory { get; set; }

        [XmlElement("node")] public DialogueNodeData[] DialogueNodes { get; set; }
    }
}