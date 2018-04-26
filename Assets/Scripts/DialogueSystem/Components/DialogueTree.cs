using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DialogueSystem.SerializationData;

namespace Assets.Scripts.DialogueSystem.Components
{
    public class DialogueTree
    {
        public string DialogueTreeCategory { get; private set; }
        public List<DialogueNode> DialogueNodes { get; private set; }

        #region Constructors

        public DialogueTree()
        {
            DialogueNodes = new List<DialogueNode>();
        }

        public DialogueTree(DialogueTreeData dialogueTreeData)
            : this()
        {
            DialogueTreeCategory = dialogueTreeData.DialogueCategory;
            DialogueNodes = dialogueTreeData.DialogueNodes
                .Select(node => new DialogueNode(node)).ToList<DialogueNode>();
        }

        #endregion

        public void CreateNode()
        {

        }

        public void CreateNode(DialogueNode node)
        {
            if (node == null || DialogueNodes.Contains(node))
                return;

           
            DialogueNodes.Add(node);
            node.Id = DialogueNodes.IndexOf(node);
        }

        public void AddDialogueNodeOption(DialogueNodeOption option, DialogueNode node, DialogueNode dest)
        {

        }

        public DialogueNode GetDialogueNode(int id)
        {
            return DialogueNodes
                .First(node => node.Id == id);
        }
    }
}