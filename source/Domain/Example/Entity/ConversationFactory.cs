using System;
using Domain.Example.Communication;
using Domain.Example.Contract;

namespace Domain.Example.Entity
{
    public class ConversationFactory : IConversationFactory
    {
        public Conversation Create(CreateSpeakRequest request)
        {
            if(request == null)
                return new UnknownConversation();

            return new Conversation
            {
                Source = request.Source,
                Message = request.Message,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };
        }
    }
}