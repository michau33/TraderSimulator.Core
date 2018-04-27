using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Scripts.DialogueSystem.Components;
using Assets.Scripts.DialogueSystem.SerializationData;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.DialogueSystem
{
    //TODO remember that you are using Application.dataPath temporary. It won't work in production
    public class DialogueTreesProvider
    {
        public List<DialogueTreeData> LoadedDialogueTrees { get; private set; }

        private readonly IXmlDataProvider _xmlDataProvider;

        // later file should be moved to static resources or repository
        const string FileName = "dialogue.xml";


        public DialogueTreesProvider(IXmlDataProvider xmlDataProvider)
        {
            _xmlDataProvider = xmlDataProvider;

            LoadedDialogueTrees = new List<DialogueTreeData>();
        }

        public void FetchDialogueTreesData()
        {
            var dialogueTreesData = FetchTreeFromXml(FileName);

            foreach (var dialogueTree in dialogueTreesData.DialogueTrees)
            {
                if (LoadedDialogueTrees.Contains(dialogueTree))
                    return;

                LoadedDialogueTrees.Add(dialogueTree);
            }
        }

        // for now load xml from assets folder to use it in editor window.
        private DialoguesTreesListData FetchTreeFromXml(string fileName)
        {
            return (DialoguesTreesListData)_xmlDataProvider
                .DeserializeObject<DialoguesTreesListData>(
                    _xmlDataProvider.LoadDataFromXml(Application.dataPath, fileName));
        }

        public DialogueTree FetchTreeByCategory(string dialogueCategory)
        {
            var wantedTree = LoadedDialogueTrees
                .Select(dialogueData => new DialogueTree(dialogueData)).First(tree => tree.DialogueTreeCategory == dialogueCategory);

            return wantedTree ?? new DialogueTree();
        }

        // I'll probably add that functionality later
        //public void SaveTreeToXml(DialogueTree tree, string fileName)
        //{
        //    string dataToWrite = _xmlDataProvider.SerializeObject<DialogueNodeData>(tree);
        //    _xmlDataProvider.CreateXmlFileOutput(Application.dataPath, fileName, dataToWrite);
        //}
    }

}