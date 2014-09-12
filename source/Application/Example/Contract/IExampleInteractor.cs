using Application.Example.Communication;

namespace Application.Example.Contract
{
    public interface IExampleInteractor
    {
        SpeakResult Speak(SpeakRequest request);
        ChangeMessageResult Change(ChangeMessageRequest request);
        CensorResult Censor(CensorRequest request);
    }
}