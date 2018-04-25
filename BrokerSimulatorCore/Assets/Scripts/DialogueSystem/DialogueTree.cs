using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.DialogueSystem
{
    public class DialogueTree
    {
        public List<DialogueNode> DialogueNodes { get; private set; }

        #region Constructors

        public DialogueTree()
        {
            DialogueNodes = new List<DialogueNode>();
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