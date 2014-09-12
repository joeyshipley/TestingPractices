using System;
using System.Collections.Generic;
using Domain.Example.Entity;

namespace Domain.Example.Contract
{
    public interface IConversationRepository
    {
        Conversation Find(Guid id);
        List<Conversation> Find(Func<Conversation, bool> filter);
        Conversation Insert(Conversation conversation);
        Conversation Change(Conversation conversation);
        Conversation Remove(Guid id);
    }
}