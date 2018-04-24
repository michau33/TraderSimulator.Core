using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Assets.Scripts.DialogueSystem.Data;
using Assets.Scripts.Xml;

namespace Assets.Scripts.DialogueSystem
{
    public class DialogueProvider
    {
        private readonly IXmlDataProvider xmlDataProvider;

        public DialogueProvider(IXmlDataProvider xmlDataProvider)
        {
            this.xmlDataProvider = xmlDataProvider;
        }

        public DialogueTree FetchTreeFromXml(string pathToFile)
        {
            throw new NotImplementedException();
        }

        public void SaveTreeToXml(DialogueTree tree)
        {
            var dialogueTree = new DialogueTree();

            string dataToWrite = xmlDataProvider.SerializeObject<DialogueNodeData>(dialogueTree);
            xmlDataProvider.CreateXmlFileOutput("mock","data.xml", dataToWrite);
        }
    }
}