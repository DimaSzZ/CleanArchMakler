using CleanAdArch.Domain.Models.User;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;

namespace CleanAdArch.Domain.Interface.Utils.Tokens;

public interface ITokenService
{
    GenerateTokenResponse Generate(User user);
}