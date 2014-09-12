using System.Collections.Generic;

namespace Application.Infrastructure
{
    public class BaseResult
    {
        public BaseResult()
        {
            WasSuccessful = true;
            Errors = new List<HandledError>();
        }

        public bool WasSuccessful { get; set; }
        public List<HandledError> Errors { get; set; } 

        public void AddError(string key, string message)
        {
            WasSuccessful = false;
            Errors.Add(new HandledError { Key = key, Error = message });
        }
    }
}