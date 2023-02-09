namespace CleanAdArch.Application.Exceptions;

public class UserDoesNotAdminException : Exception
{
    public UserDoesNotAdminException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    public UserDoesNotAdminException()
        : base($"User does not Admin")
    {
    }
}