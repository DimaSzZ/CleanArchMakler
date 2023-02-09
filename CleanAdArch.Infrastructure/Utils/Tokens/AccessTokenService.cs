using System.Security.Claims;
using CleanAdArch.Domain.Interface.Utils.Tokens;
using CleanAdArch.Domain.Models.User;
using CleanAdArch.Domain.Settings.Utils.Tokens;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;

namespace CleanAdArch.Infrastructure.Utils.Tokens;

public class AccessTokenService : IAccessTokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly ITokenGenerator _tokenGenerator;

    public AccessTokenService(JwtSettings jwtSettings,ITokenGenerator tokenGenerator)
    {
        _jwtSettings = jwtSettings;
        _tokenGenerator = tokenGenerator;
    }
    public GenerateTokenResponse Generate(User user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
        };
        return _tokenGenerator.Generate(_jwtSettings.AccessTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,
            _jwtSettings.AccessTokenExpirationMinutes, claims);
    }
}
    
