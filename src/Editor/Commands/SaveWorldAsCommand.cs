﻿using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class SaveWorldAsCommand : EditorCommand
    {
        public SaveWorldAsCommand(IEditor editor)
            : base(editor)
        {
            SubscribeToMessageThatAffectsCanExecute<WorldLoadedMessage>();
            SubscribeToMessageThatAffectsCanExecute<WorldClosedMessage>();
        }

        protected override bool OnCanExecute(object data = null)
        {
            return Editor.World != null;
        }

        protected override void OnExecute(object data = null)
        {
            Editor.MessageBus.Publish(new WorldSavingMessage(true));
        }
    }
}