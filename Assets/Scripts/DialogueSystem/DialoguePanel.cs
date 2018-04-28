using System;
using System.Linq;
using Assets.Scripts.DialogueSystem.Components;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DialogueSystem
{
    public class DialoguePanel : Singleton<DialoguePanel>
    {
        public Text CurrentDialogueTitle;
        public Text CurrentDialogueContent;

        DialogueTree _currentTree;

        public DialogueTree CurrentTree
        {
            get { return _currentTree;}
            set { _currentTree = value; RefreshPanel(); }
        }

        void RefreshPanel()
        {
            Debug.Log("Jazduniaaa");
            var currentNode = _currentTree.DialogueNodes.First();
            CurrentDialogueTitle.text = currentNode.Title;
            CurrentDialogueContent.text = currentNode.Content;
        }

    }
}