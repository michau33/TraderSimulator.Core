using System.Collections.Generic;

namespace Assets.Scripts.DialogueSystem.Data
{
    public class DialogueNodeData
    {
        public Data DataInstance;

        public DialogueNodeData()
        {
        }

        public struct Data
        {
            public int NodeId;
            public string Title;
            public string Content;

            public List<DialogueNodeOption> DialogueOptions;      
        }
    }
}