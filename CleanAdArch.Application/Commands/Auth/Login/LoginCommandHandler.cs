using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Utils.PasswordHasher;
using CleanAdArch.Domain.Interface.Utils.Tokens;
using CleanAdArch.Domain.Settings.Utils.TokensResponse;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Login;

public class LoginCommandHandler :IRequestHandler<LoginCommand,AuthenticateResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuthenticateService _authenticateService;

    public LoginCommandHandler(IUserRepository userRepository, IAuthenticateService authenticateService,
        IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _authenticateService = authenticateService;
    }

    public async Task<AuthenticateResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.OnByEmail(request.Email, cancellationToken);
        if (user == null)
            throw new InvalidLoginMethodException();
        var valid = _passwordHasher.Check(user.HashedPassword, request.Password);
        if (!valid)
            throw new InvalidLoginMethodException();
        return await _authenticateService.Authenticate(user, cancellationToken);
    }
}