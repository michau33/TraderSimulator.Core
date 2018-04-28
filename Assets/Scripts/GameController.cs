using System;
using System.Collections.Generic;
using Assets.Scripts.DialogueSystem;
using Assets.Scripts.DialogueSystem.Components;
using Assets.Scripts.Utility;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : Singleton<GameController>
    {
        IXmlDataProvider _dataProvider;
        DialogueTreesProvider _dialogueTreesProvider;

        void Awake()
        {
            _dataProvider = new XmlDataProvider();
            _dialogueTreesProvider = new DialogueTreesProvider(_dataProvider);
            _dialogueTreesProvider.DialoguesTreesFetched += DialoguesTreesFetched; 
        }

        void DialoguesTreesFetched(object sender, EventArgs e)
        {

        }

        public void FetchDialogueOptions()
        {
            var nodes = new List<DialogueNode>
            {
                new DialogueNode(0, "Title_1", "Content_1", null),
                new DialogueNode(1, "Title_2", "Content_2", null),
            };

            var tree = new DialogueTree(0, "SampleCategory_1", nodes);
            _dialogueTreesProvider.SaveTreeToXml(tree, "seks.xml");
        }
    }
}