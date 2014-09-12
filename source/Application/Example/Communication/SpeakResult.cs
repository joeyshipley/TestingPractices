using Application.Example.Entity;
using Application.Infrastructure;

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