using Application.Example.Communication;
using Application.Example.Entity;

namespace Application.Example.Contract
{
    public interface IConversationFactory
    {
        Conversation Create(SpeakRequest request);
    }
}