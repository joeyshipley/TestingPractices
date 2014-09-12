using Domain.Example.Communication;
using Domain.Example.Entity;

namespace Domain.Example.Contract
{
    public interface IConversationFactory
    {
        Conversation Create(CreateSpeakRequest request);
    }
}