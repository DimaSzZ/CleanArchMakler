using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanAdArch.Domain.Interface.Utils.Tokens;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;
using Microsoft.IdentityModel.Tokens;

namespace CleanAdArch.Infrastructure.Utils.Tokens;

public class TokenGenerator : ITokenGenerator
{
    public GenerateTokenResponse Generate(string secretKey, string issuer, string audience, double expires,
        IEnumerable<Claim>? claims = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiresAt = DateTime.Now.AddMinutes(expires);
        JwtSecurityToken securityToken = new(issuer, audience,
            claims,
            DateTime.Now,
            expiresAt,
            credentials);
        return new GenerateTokenResponse(
            new JwtSecurityTokenHandler().WriteToken(securityToken),
            expiresAt
        );
    }
}
