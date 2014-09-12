using Application.Example.Communication;
using Domain.Example.Communication;

namespace Application.DomainAdapter.Contract
{
    public interface IRequestMapper
    {
        CreateSpeakRequest MapFrom(SpeakRequest request);
    }
}