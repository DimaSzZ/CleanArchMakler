using Newtonsoft.Json;

namespace CleanAdArch.Application.Exceptions;

public class EntityExistsException: Exception
{
    public EntityExistsException():base()
    {
    }
    public EntityExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    public EntityExistsException(IEnumerable<string> errors)
        : base(JsonConvert.SerializeObject(errors))
    {
    }
    public EntityExistsException(string entity,string field)
        : base($"{entity} with provided {field} already exists")
    {
    }
}