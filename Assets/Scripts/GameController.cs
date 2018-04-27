using System;
using Assets.Scripts.DialogueSystem;
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
        }

        public void FetchDialogueOptions()
        {
            _dialogueTreesProvider.FetchDialogueTreesData();
        }
    }
}