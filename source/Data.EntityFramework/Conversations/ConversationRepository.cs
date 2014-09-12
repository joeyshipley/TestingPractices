using System;
using System.Collections.Generic;
using System.Linq;
using Data.EntityFramework.Infrastructure;
using Domain.Example.Contract;
using Domain.Example.Entity;

namespace Data.EntityFramework.Conversations
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly IDatabaseContext context;

        public ConversationRepository(IDatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public Conversation Find(Guid id)
        {
            var entity = context.Conversations
                .FirstOrDefault(e => e.Id == id)
                ?? new UnknownConversation();
            return entity;
        }

        public List<Conversation> Find(Func<Conversation, bool> filter)
        {
            var entities = context.Conversations
                .Where(filter)
                .ToList();
            return entities;
        }

        public Conversation Insert(Conversation conversation)
        {
            try
            {
                var entity = context.Conversations.Add(conversation);
                context.Commit();
                return entity;
            }
            catch(Exception exception)
            {
                return new UnknownConversation();
            }
        }

        public Conversation Change(Conversation conversation)
        {
            try
            {
                context.Commit();
                return conversation;
            }
            catch(Exception exception)
            {
                return new UnknownConversation();
            }
        }

        public Conversation Remove(Guid id)
        {
            var entityToRemove = Find(id);
            context.Conversations.Remove(entityToRemove);
            context.Commit();

            var entity = Find(id);
            return entity ?? new UnknownConversation();
        }
    }
}