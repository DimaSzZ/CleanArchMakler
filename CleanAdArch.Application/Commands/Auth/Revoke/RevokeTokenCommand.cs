using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Revoke;

public record RevokeTokenCommand(string RefreshToken) : IRequest;