using Application.Infrastructure;
using Domain.Example.Entity;

namespace Application.Example.Communication
{
    public class SpeakResult : BaseResult
    {
        public SpeakResult()
        {
            Conversation = new UnknownConversation();
        }

        public Conversation Conversation { get; set; }
    }
}