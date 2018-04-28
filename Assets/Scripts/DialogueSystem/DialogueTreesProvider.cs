using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DialogueSystem.Components;
using Assets.Scripts.DialogueSystem.SerializationData;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.DialogueSystem
{
    //TODO remember that you are using Application.dataPath temporary. It won't work in production
    public class DialogueTreesProvider
    {
        const string FileName = "dialogue.xml"; // later file should be moved to static resources or repository

        readonly IXmlDataProvider _xmlDataProvider;
        readonly List<DialogueTreeData> _dialogueTreesData;

        public DialogueTreesProvider(IXmlDataProvider xmlDataProvider)
        {
            _xmlDataProvider = xmlDataProvider;
            _dialogueTreesData = new List<DialogueTreeData>();
        }

        public void FetchDialogueTreesData()
        {
            var data = FetchTreeFromXml(FileName);

            if (data == null)
                return;

            foreach (var dialogueTree in data.DialogueTrees)
            {
                if (_dialogueTreesData.Contains(dialogueTree))
                    return;

                _dialogueTreesData.Add(dialogueTree);
            }

            OnDialoguesFetched();
        }

        DialoguesTreesListData FetchTreeFromXml(string fileName)
        {
            return (DialoguesTreesListData)_xmlDataProvider
                .DeserializeObject<DialoguesTreesListData>(
                    _xmlDataProvider.LoadDataFromXml(Application.dataPath, fileName));
        }

        public void SaveTreeToXml(DialogueTree tree, string fileName)
        {
            string dataToWrite = _xmlDataProvider.SerializeObject<DialogueTree>(tree);
            _xmlDataProvider.CreateXmlFileOutput(Application.dataPath, fileName, dataToWrite);
        }

        #region Getters

        public DialogueTree GetTreeById(int id)
        {
            var wantedTree = _dialogueTreesData
                .Select(treeData => new DialogueTree(treeData)).First(tree => tree.Id == id);

            return wantedTree ?? new DialogueTree();
        }

        public DialogueTree GetTreeByCategory(string dialogueCategory)
        {
            var wantedTree = _dialogueTreesData
                .Select(dialogueData => new DialogueTree(dialogueData)).First(tree => tree.DialogueTreeCategory == dialogueCategory);

            return wantedTree ?? new DialogueTree();
        }

        public DialogueNode GetNodeById(int treeId, int nodeId)
        {
            var wantedNode = _dialogueTreesData
                .Select(treeData => new DialogueTree(treeData))
                .First(tree => tree.Id == treeId).DialogueNodes
                .First(node => node.Id == nodeId);

            return wantedNode ?? new DialogueNode();
        }

        #endregion

        #region Events

        public EventHandler DialoguesTreesFetched;

        protected void OnDialoguesFetched()
        {
            if (DialoguesTreesFetched != null)
                DialoguesTreesFetched.Invoke(this, System.EventArgs.Empty);
        }

        #endregion
    }
}