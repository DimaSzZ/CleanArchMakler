using System.Security.Claims;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;

namespace CleanAdArch.Domain.Interface.Utils.Tokens;

public interface ITokenGenerator
{
    GenerateTokenResponse Generate(string secretKey, string issuer, string audience, double expires, IEnumerable<Claim>? claims = null);
}