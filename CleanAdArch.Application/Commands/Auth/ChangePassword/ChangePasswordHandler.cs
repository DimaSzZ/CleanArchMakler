using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Utils.PasswordHasher;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserAccessor _userAccessor;
    private readonly IUserRepository _userRepository;

    public ChangePasswordHandler(IPasswordHasher passwordHasher, IUserAccessor userAccessor, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userAccessor = userAccessor;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.HashedPassword == null)
            throw new InvalidLoginMethodException("You can't change password for account created via google login");
        var validOldPassword = _passwordHasher.Check(user.HashedPassword!, request.OldPassword);
        if (!validOldPassword)
            throw new Exception("Provided old password doesn't equal to current");
        var newPasswordHash = _passwordHasher.Hash(request.NewPassword);
        user.UpdatePassword(newPasswordHash);

        await _userRepository.Save(user, cancellationToken);
        return Unit.Value;
    }
}