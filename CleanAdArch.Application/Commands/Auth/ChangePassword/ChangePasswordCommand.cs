using MediatR;

namespace CleanAdArch.Application.Commands.Auth.ChangePassword;

public record ChangePasswordCommand(string OldPassword, string NewPassword) : IRequest;