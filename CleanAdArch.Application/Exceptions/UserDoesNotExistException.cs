namespace CleanAdArch.Application.Exceptions;

public class UserDoesNotExistException : Exception
{
    public UserDoesNotExistException()
        : base($"User referenced by this token does not exist")
    {
    }
    
    public UserDoesNotExistException(string field)
        : base($"User referenced by this {field} does not exist")
    {
    }
}