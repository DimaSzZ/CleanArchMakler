using CleanAdArch.Application.Commands.AdminActions.CUD_City.CreateCity;
using CleanAdArch.Application.Commands.AdminActions.CUD_City.DeleteCity;
using CleanAdArch.Application.Commands.AdminActions.CUD_City.UpdateCity;
using CleanAdArch.Application.Queries.GetCities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.AdminActions.CRUD_City;

[ApiController]
[Authorize]
[Route("api/admin/city")]
public class AdminCityController : BaseController
{
    [HttpPost("append")]
    public async Task<IActionResult> CityAppend(CreateCityCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("City added");
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> CityDelete([FromQuery] string id, CancellationToken cancellationToken)
    {
        var guid = Guid.Parse(id);
        await Mediator.Send(new DeleteCityCommand(guid), cancellationToken);
        return Ok("City deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> CityUpdate([FromBody] UpdateCityCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("City updated");
    }
    [AllowAnonymous]
    [HttpGet("get-all")]
    public async Task<IActionResult> CityGet(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCitiesQuery(), cancellationToken);
        return Ok(response);
    }
}