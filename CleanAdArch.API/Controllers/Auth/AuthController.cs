using CleanAdArch.Application.Commands.Auth.ChangePassword;
using CleanAdArch.Application.Commands.Auth.Login;
using CleanAdArch.Application.Commands.Auth.Refresh;
using CleanAdArch.Application.Commands.Auth.Registration;
using CleanAdArch.Application.Commands.Auth.Revoke;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.Auth;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
    {
        var credentials = await Mediator.Send(command, cancellationToken);
        return Ok(credentials);
    }
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Registration was successful");
    }
    [HttpPost("refresh-token")]
    public async Task<IActionResult> Refresh(RefreshTokenCommand tokenCommand, CancellationToken cancellationToken)
    {
        var credentials = await Mediator.Send(tokenCommand, cancellationToken);
        return Ok(credentials);
    }
    [HttpPost("revoke-token")]
    public async Task<IActionResult> Revoke(RevokeTokenCommand tokenCommand, CancellationToken cancellationToken)
    {
        await Mediator.Send(tokenCommand, cancellationToken);
        return Ok();
    }
    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}