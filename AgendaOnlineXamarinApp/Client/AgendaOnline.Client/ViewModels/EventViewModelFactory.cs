﻿using AgendaOnline.Client.Model.Entities.Messages;

namespace AgendaOnline.Client.ViewModels
{
    public class EventViewModelFactory
    {
        public EventViewModel Get(Event @event, string currentUserName)
        {
            if (@event is TextMessage)
                return new TextMessageViewModel(@event as TextMessage, currentUserName);

            return new EventViewModel(@event);
        }
    }
}