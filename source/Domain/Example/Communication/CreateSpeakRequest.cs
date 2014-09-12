namespace Domain.Example.Communication
{
    public class CreateSpeakRequest
    {
        public Rules.Being Source { get; set; }
        public string Message { get; set; }
    }
}