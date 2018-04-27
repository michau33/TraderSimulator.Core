using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DialogueSystem.SerializationData;

namespace Assets.Scripts.DialogueSystem.Components
{
    public class DialogueNode
    {
        public int Id = -1;

        public string Title { get; private set; }
        public string Content { get; private set; }
        public List<DialogueOption> Options { get; private set; }

        #region Constructors

        public DialogueNode()
        {
        }

        public DialogueNode(int id, string title, string content, List<DialogueOption> options)
        {
            Id = id;
            Title = title;
            Content = content;
            Options = options;
        }
        
        public DialogueNode(DialogueNodeData data)
            : this(data.Id, data.Title, data.Content, data.DialogueOptions.Select(o => new DialogueOption(o)).ToList())
        {

        }

        #endregion

        public override bool Equals(object obj)
        {
            var node = obj as DialogueNode;
            return node != null
                   && Id == node.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = -1492648413;
            hashCode = hashCode * -1541538291 + EqualityComparer<int>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}