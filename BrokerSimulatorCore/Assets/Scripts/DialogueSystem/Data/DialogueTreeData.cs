using System.Collections.Generic;

namespace Assets.Scripts.DialogueSystem.Data
{
    public class DialogueTreeData
    {
        public Data DataInstance;
        
        public DialogueTreeData()
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