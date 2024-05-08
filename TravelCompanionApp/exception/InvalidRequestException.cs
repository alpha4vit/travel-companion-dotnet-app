namespace TravelCompanionApp.exception;

public class InvalidRequestException : Exception
{
    public Dictionary<string, string> Errors { get; private set; }

    public InvalidRequestException(string message, Dictionary<string, string> errors) : base(message)
    {
        Errors = errors;
    }
}