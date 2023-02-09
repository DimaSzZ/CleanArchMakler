using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}