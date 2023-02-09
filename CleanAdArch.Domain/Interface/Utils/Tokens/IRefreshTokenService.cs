namespace CleanAdArch.Domain.Interface.Utils.Tokens;

public interface IRefreshTokenService: ITokenService
{
    bool Validate(string refreshToken);
}