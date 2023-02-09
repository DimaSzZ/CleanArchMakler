using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Registration;

public record RegistrationCommand(
    string? Name,
    bool Admin,
    string? SecondName,
    string? Phone,
    string? Password,
    string? Email
) : IRequest;
