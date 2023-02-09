using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Revoke;

public class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;

    public RevokeTokenHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await _refreshTokenRepository.OneByToken(request.RefreshToken, cancellationToken);

        if (token == null)
            throw new NotFoundException("Refresh Token", "token");
        var user = await _userRepository.OnById(token.UserId, cancellationToken);
        if (user == null)
            throw new UserDoesNotExistException("id");

        if (token.Revoked)
            throw new TokenAlreadyRevokedException();

        token.Revoke();
        await _refreshTokenRepository.Save(token, cancellationToken);
        return Unit.Value;
    }
}