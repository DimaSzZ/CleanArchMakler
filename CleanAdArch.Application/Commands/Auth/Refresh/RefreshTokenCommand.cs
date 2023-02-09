using CleanAdArch.Domain.Settings.Utils.TokensResponse;
using MediatR;

namespace CleanAdArch.Application.Commands.Auth.Refresh;

public record RefreshTokenCommand(string RefreshToken, string Email) : IRequest<AuthenticateResponse>;