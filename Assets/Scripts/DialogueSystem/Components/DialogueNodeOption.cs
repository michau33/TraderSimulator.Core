﻿namespace Assets.Scripts.DialogueSystem.Components
{
    public class DialogueNodeOption
    {
        public readonly string Content;
        public readonly int Id;

        public DialogueNodeOption()
        {
        }

        public DialogueNodeOption(string content, int id)
        {
            Content = content;
            Id = id;
        }
    }
}