namespace CleanAdArch.Application.Exceptions;

public class InvalidRefreshTokenException : Exception
{
    public InvalidRefreshTokenException()
        : base("This refresh token isn't valid")
    {
    }
    
    public InvalidRefreshTokenException(string message)
        : base(message)
    {
    }
}