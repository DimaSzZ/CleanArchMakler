using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Utils.PasswordHasher;
using CleanAdArch.Domain.Interface.Utils.Tokens;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Refresh;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, AuthenticateResponse>
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IUserRepository _userRepository;
    public RefreshTokenHandler(IPasswordHasher passwordHasher, IUserAccessor userAccessor, IUserRepository userRepository, IAuthenticateService authenticateService, IRefreshTokenRepository refreshTokenRepository, IRefreshTokenService refreshTokenService)
    {
        _userRepository = userRepository;
        _authenticateService = authenticateService;
        _refreshTokenRepository = refreshTokenRepository;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<AuthenticateResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var validByService = _refreshTokenService.Validate(request.RefreshToken);
        if (!validByService)
            throw new InvalidRefreshTokenException();
        var user = await _userRepository.OnByEmail(request.Email, cancellationToken);

        if (user == null)
            throw new InvalidRefreshTokenException("User for refresh token by provided email not found");
        var token = await _refreshTokenRepository.OneByToken(request.RefreshToken, cancellationToken);
        if (token == null || token.Revoked || DateTime.Compare(token.ExpiresAt, DateTime.Now) > 0)
            throw new InvalidRefreshTokenException();

        return await _authenticateService.Authenticate(user, cancellationToken, token);
    }
}