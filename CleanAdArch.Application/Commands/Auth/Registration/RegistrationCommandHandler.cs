using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Utils.PasswordHasher;
using CleanAdArch.Domain.Models.User;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Registration;

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public RegistrationCommandHandler(IUserRepository userRepository,IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(RegistrationCommand command, CancellationToken cancellationToken)
    {
        var isExist = await _userRepository.IsExist(command.Email,command.Password,cancellationToken);
        if(isExist)
            throw new EntityExistsException("User", "email");
        var passwordHash = _passwordHasher.Hash(command.Password);
        var user = new User(
            command.Name,
            command.Admin,
            command.SecondName,
            command.Phone,
            command.Password,
            command.Email,
            passwordHash
        );
        await _userRepository.Save(user, cancellationToken);
        return Unit.Value;
    }
}