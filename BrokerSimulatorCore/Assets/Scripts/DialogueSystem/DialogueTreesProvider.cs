using System;
using Assets.Scripts.DialogueSystem.Data;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.DialogueSystem
{
    //TODO remember that you are using Application.dataPath temporary. It won't work in production
    public class DialogueTreesProvider
    {
        private readonly IXmlDataProvider xmlDataProvider;

        public DialogueTreesProvider(IXmlDataProvider xmlDataProvider)
        {
            this.xmlDataProvider = xmlDataProvider;
        }

        // for now load xml from assets folder to use it in editor window.
        public DialogueTree FetchTreeFromXml(string fileName)
        {
            string xmlData = xmlDataProvider.LoadDataFromXml(Application.dataPath, fileName);

            Debug.Log(xmlData);

            var dialogueTreeData = xmlDataProvider.DeserializeObject<DialogueTreeData>(xmlData);
            DialogueTreeData dialogueTree = ((DialogueTreeData) dialogueTreeData);

            Debug.Log(dialogueTree.DialogueCategory);

            foreach (var dialogueNode in dialogueTree.DialogueNodes)
            {
                Debug.Log(dialogueNode.Id + " " + dialogueNode.Title + " " + dialogueNode.Content);
                
            }

            
            return new DialogueTree();
        }

        public void SaveTreeToXml(DialogueTree tree, string fileName)
        {
            string dataToWrite = xmlDataProvider.SerializeObject<DialogueNodeData>(tree);
            xmlDataProvider.CreateXmlFileOutput(Application.dataPath, fileName, dataToWrite);
        }
    }
}