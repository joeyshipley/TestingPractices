using Application.DomainAdapter.Contract;
using Application.Example.Communication;
using Domain.Example.Communication;

namespace Application.DomainAdapter
{
    public class RequestMapper : IRequestMapper
    {
        public CreateSpeakRequest MapFrom(SpeakRequest request)
        {
            return new CreateSpeakRequest
            {
                Source = request.Source,
                Message = request.Message
            };
        }
    }
}