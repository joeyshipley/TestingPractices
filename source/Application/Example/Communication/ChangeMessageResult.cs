using Application.Infrastructure;
using Domain.Example.Entity;

namespace Application.Example.Communication
{
    public class ChangeMessageResult : BaseResult
    {
        public ChangeMessageResult()
        {
            Conversation = new UnknownConversation();
        }

        public Conversation Conversation { get; set; }
    }
}