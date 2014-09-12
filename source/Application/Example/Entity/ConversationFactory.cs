using System;
using Application.Example.Communication;
using Application.Example.Contract;

namespace Application.Example.Entity
{
    public class ConversationFactory : IConversationFactory
    {
        public Conversation Create(SpeakRequest request)
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