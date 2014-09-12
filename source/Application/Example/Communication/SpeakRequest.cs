namespace Application.Example.Communication
{
    public class SpeakRequest
    {
        public Rules.Being Source { get; set; }
        public string Message { get; set; }
    }
}