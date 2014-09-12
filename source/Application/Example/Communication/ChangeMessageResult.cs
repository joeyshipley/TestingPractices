using Application.Example.Entity;
using Application.Infrastructure;

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