using Assets.Scripts.DialogueSystem.SerializationData;

namespace Assets.Scripts.DialogueSystem.Components
{
    // TODO ADD OWN ID AND DESTINATION ID
    public class DialogueOption
    {
        public string Content { get; private set; }
        public int Id { get; private set; }

        public DialogueOption()
        {
        }

        public DialogueOption(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public DialogueOption(DialogueOptionData data)
            : this(data.Id, data.Content)
        {

        }
    }
}