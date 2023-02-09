using Newtonsoft.Json;

namespace CleanAdArch.Application.Exceptions;

public class ValidationRequestException : Exception
{
    public ValidationRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ValidationRequestException(IEnumerable<string> errors)
        : base(JsonConvert.SerializeObject(errors))
    {
    }

    public ValidationRequestException(string error)
        : base(error)
    {
    }
}