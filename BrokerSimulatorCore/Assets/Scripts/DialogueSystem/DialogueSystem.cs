using System;
using System.Collections.ObjectModel;
using Assets.Scripts.DialogueSystem.EventArgs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.DialogueSystem
{
    public class DialogueSystem : Singleton<DialogueSystem>
    {
        public string DialogueTitle;
        public string DialogueContent;
        public Button ContinueButton;
        public Button ExitButton;
        public GameObject DialoguePanelGameobject;

        public EventHandler<System.EventArgs> DialogueStarted;
        public EventHandler<System.EventArgs> DialogueEnded;
        public EventHandler<DialogueContinuedEventArgs> DialogueContinued;

        public void EnableDialogueBox(string dialogueTitle, string dialogueContent, UnityAction continueEvent, UnityAction exitAction)
        {
            DialoguePanelGameobject.SetActive(true);
            OnDialogueStarted(System.EventArgs.Empty);

            ContinueButton.onClick.AddListener(() =>
            {
                OnDialogueContinued(new DialogueContinuedEventArgs());
                continueEvent.Invoke();
            });

            ExitButton.onClick.AddListener(() =>
            {
                OnDialogueEnded(System.EventArgs.Empty);
                exitAction.Invoke();
            });
        }

        public void StartConversation(Collection<Dialogue> dialogueCollection)
        {

        }

        protected virtual void OnDialogueStarted(System.EventArgs e)
        {
            if (DialogueStarted != null)
                DialogueStarted(this, e);
        }

        protected virtual void OnDialogueContinued(DialogueContinuedEventArgs e)
        {
            if (DialogueContinued != null)
                DialogueContinued(this, e);
        }

        protected virtual void OnDialogueEnded(System.EventArgs e)
        {
            if (DialogueEnded != null)
                DialogueEnded(this, e);
        }
    }
}   