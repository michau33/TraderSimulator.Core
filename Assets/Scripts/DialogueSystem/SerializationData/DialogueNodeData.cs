﻿using System.Xml.Serialization;

namespace Assets.Scripts.DialogueSystem.SerializationData
{
    [XmlRoot("node")]
    public class DialogueNodeData
    {
        [XmlAttribute("id")] public int Id { get; set; }

        [XmlElement("title")] public string Title { get; set; }
        [XmlElement("content")] public string Content { get; set; }
        [XmlElement("responses")] public DialogueResponseData[] DialogueResponses { get; set; }
    }
}