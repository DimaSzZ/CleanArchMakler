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
    [HttpPost("append/{city}")]
    public async Task<IActionResult> CityAppend(string city, CancellationToken cancellationToken)
    {
        var command = new CreateCityCommand(city);
        await Mediator.Send(command, cancellationToken);
        return Ok("City added");
    }
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> CityAppend(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteCityCommand(id);
        await Mediator.Send(command, cancellationToken);
        return Ok("City deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> CityAppend(UpdateCityCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("City updated");
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> CityGet(GetCitiesQuery query, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}