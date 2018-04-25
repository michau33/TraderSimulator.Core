using System.Collections.Generic;

namespace Assets.Scripts.DialogueSystem
{
    public class DialogueNode
    {
        public int Id = -1;

        public readonly string Title;
        public readonly string Content;
        public readonly List<DialogueNodeOption> Options;

        #region Constructors

        public DialogueNode()
        {
            Options = new List<DialogueNodeOption>();
        }

        public DialogueNode(int id, string content)
            : this()
        {
            Id = id;
            Content = content;
        }

        public DialogueNode(int id, string content, string title) 
            : this(id, content)
        {
            Title = title;
        }

        public DialogueNode(int id, string content, string title, IEnumerable<DialogueNodeOption> options) 
            : this(id, content, title)
        {
            Options = new List<DialogueNodeOption>(options);
        }

        #endregion

        #region Dialogue options management

        public void AddDialogueOption(DialogueNodeOption option)
        {
            if (Options.Contains(option))
                return;
            
            Options.Add(option);
        }

        public void RemoveDialogueOption(DialogueNodeOption option)
        {
            if (!Options.Contains(option))
                return;

            Options.Remove(option);
        }

        #endregion

        public override bool Equals(object obj)
        {
            var node = obj as DialogueNode;
            return node != null &&
                   Id == node.Id;
        }
        public override int GetHashCode()
        {
            return -1065341352 + Id.GetHashCode();
        }
    }
}