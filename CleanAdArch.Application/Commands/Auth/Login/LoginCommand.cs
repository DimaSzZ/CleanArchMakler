using CleanAdArch.Domain.Settings.Utils.TokensResponse;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest<AuthenticateResponse>;
