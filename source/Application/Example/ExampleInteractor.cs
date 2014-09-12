using System;
using System.Linq;
using Application.DomainAdapter.Contract;
using Application.Example.Communication;
using Application.Example.Contract;
using Application.Infrastructure;
using Domain;
using Domain.Example.Contract;

namespace Application.Example
{
    public class ExampleInteractor : IExampleInteractor
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IConversationFactory _conversationFactory;
        private readonly IRequestMapper _requestMapper;

        public ExampleInteractor(
            IConversationRepository conversationRepository, 
            IConversationFactory conversationFactory,
            IRequestMapper requestMapper)
        {
            _conversationRepository = conversationRepository;
            _conversationFactory = conversationFactory;
            _requestMapper = requestMapper;
        }

        public SpeakResult Speak(SpeakRequest request)
        {
            var result = new SpeakResult();
            var createRequest = _requestMapper.MapFrom(request);
            var conversation = _conversationFactory.Create(createRequest);
            
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