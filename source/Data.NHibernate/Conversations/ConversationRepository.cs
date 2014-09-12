using System;
using System.Collections.Generic;
using System.Linq;
using Data.NHibernate.Infrastructure;
using Domain.Example.Contract;
using Domain.Example.Entity;
using NHibernate.Linq;

namespace Data.NHibernate.Conversations
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ISessionWorker _worker;

        public ConversationRepository(ISessionWorker sessionWorker)
        {
            _worker = sessionWorker;
        }

        public Conversation Find(Guid id)
        {
            return _worker.Perform((session) =>
                session.Query<Conversation>()
                    .FirstOrDefault(v => v.Id == id)
                ?? new UnknownConversation()
            );
        }

        public List<Conversation> Find(Func<Conversation, bool> filter)
        {
            return _worker.Perform((session) =>
                session.Query<Conversation>()
                    .Where(filter)
                    .ToList()
            );
        }

        public Conversation Insert(Conversation conversation)
        {
            _worker.Perform((session) => 
                session.SaveOrUpdate(conversation)
            );
            return conversation.Id != Guid.Empty
                ? conversation
                : new UnknownConversation();
        }

        public Conversation Change(Conversation conversation)
        {
            _worker.Perform((session) => 
                session.SaveOrUpdate(conversation)
            );
            return conversation;
        }

        public Conversation Remove(Guid id)
        {
            var entity = Find(id);
            _worker.Perform((session) => 
                session.Delete(entity)
            );
            var conversation = Find(id);
            return conversation;
        }
    }
}