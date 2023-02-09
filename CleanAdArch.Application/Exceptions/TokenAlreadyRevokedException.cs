namespace CleanAdArch.Application.Exceptions;

public class TokenAlreadyRevokedException : Exception
{
    public TokenAlreadyRevokedException()
        : base("The token you provided has already been revoked")
    {
    }
}