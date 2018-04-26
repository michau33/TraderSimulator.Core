using System;
using Assets.Scripts.DialogueSystem;
using Assets.Scripts.Utility;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] DialogueTree dialogueTree;

        IXmlDataProvider dataProvider;

        void Awake()
        {
            dataProvider = new XmlDataProvider();
        }

        public void FetchDialogueOptions()
        {
            if (dataProvider == null || dialogueTree != null) 
                return;
        
            DialogueTreesProvider dialoguesTreesProvider = new DialogueTreesProvider(dataProvider);
            dialogueTree = dialoguesTreesProvider.FetchTreeFromXml("dialogue.xml");
        }
    }
}