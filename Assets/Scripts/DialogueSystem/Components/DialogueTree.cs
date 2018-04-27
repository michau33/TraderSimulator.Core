using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DialogueSystem.SerializationData;

namespace Assets.Scripts.DialogueSystem.Components
{
    public class DialogueTree
    {
        public int Id { get; private set; }
        public string DialogueTreeCategory { get; private set; }
        public List<DialogueNode> DialogueNodes { get; private set; }


        public DialogueTree()
        {
        }

        public DialogueTree(int id, string dialogueTreeCategory, List<DialogueNode> nodesList)
        {
            Id = id;
            DialogueTreeCategory = dialogueTreeCategory;
            DialogueNodes = nodesList;
        }

        public DialogueTree(DialogueTreeData dialogueTreeData)
            : this(dialogueTreeData.DialogueId, dialogueTreeData.DialogueCategory, 
                dialogueTreeData.DialogueNodes.Select(n => new DialogueNode(n)).ToList())
        {

        }

        public override bool Equals(object obj)
        {
            var tree = obj as DialogueTree;
            return tree != null 
                   && DialogueTreeCategory == tree.DialogueTreeCategory 
                   && Id == tree.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = -1495643445;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DialogueTreeCategory);
            hashCode = hashCode * -1521134296 + EqualityComparer<int>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}