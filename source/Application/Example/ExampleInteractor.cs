using System;
using System.Linq;
using Application.Example.Communication;
using Application.Example.Contract;
using Application.Infrastructure;

namespace Application.Example
{
    public class ExampleInteractor : IExampleInteractor
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IConversationFactory _conversationFactory;

        public ExampleInteractor(IConversationRepository conversationRepository, IConversationFactory conversationFactory)
        {
            _conversationRepository = conversationRepository;
            _conversationFactory = conversationFactory;
        }

        public SpeakResult Speak(SpeakRequest request)
        {
            var result = new SpeakResult();
            var conversation = _conversationFactory.Create(request);
            
            if(conversation.Source == Rules.Being.Unknown)
            {
                result.AddError("InvalidData", "The source of the conversation was not known. Please provide the source and try again.");
                return result;
            }

            var validationErrors = conversation.Validate();
            if(validationErrors.Any())
            {
                validationErrors.ForEach(err => 
                    result.AddError("InvalidData", err.ErrorMessage));
                return result;
            }

            var addedConversation = _conversationRepository.Insert(conversation);
            if(addedConversation.IsUnknown)
            {
                result.AddError("DidNotAdd", "We were unable to add the new conversation, please try again at a later time.");
                return result;
            }

            result.Conversation = addedConversation;
            return result;
        }

        public ChangeMessageResult Change(ChangeMessageRequest request)
        {
            throw new NotImplementedException();
        }

        public CensorResult Censor(CensorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}