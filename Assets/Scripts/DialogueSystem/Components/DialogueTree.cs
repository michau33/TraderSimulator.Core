using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DialogueSystem.SerializationData;

namespace Assets.Scripts.DialogueSystem.Components
{
    public class DialogueTree
    {
        public string DialogueTreeCategory { get; private set; }
        public List<DialogueNode> DialogueNodes { get; private set; }


        public DialogueTree()
        {
        }

        public DialogueTree(string dialogueTreeCategory, List<DialogueNode> nodesList)
        {
            DialogueTreeCategory = dialogueTreeCategory;
            DialogueNodes = nodesList;
        }

        public DialogueTree(DialogueTreeData dialogueTreeData)
            : this(dialogueTreeData.DialogueCategory, 
                dialogueTreeData.DialogueNodes.Select(n => new DialogueNode(n)).ToList())
        {

        }
    }
}