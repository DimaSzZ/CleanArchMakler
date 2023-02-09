using CleanAdArch.Domain.Models.RefreshToken;
using CleanAdArch.Domain.Models.User;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;

namespace CleanAdArch.Domain.Interface.Utils.Tokens;

public interface IAuthenticateService
{
    public Task<AuthenticateResponse> Authenticate(
        User user,
        CancellationToken cancellationToken,
        RefreshToken? validRefreshToken = null
    );
}