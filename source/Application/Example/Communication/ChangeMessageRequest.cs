using System;

namespace Application.Example.Communication
{
    public class ChangeMessageRequest
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}