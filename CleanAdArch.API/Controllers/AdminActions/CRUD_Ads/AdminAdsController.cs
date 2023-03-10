using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.CreateAd;
using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.DeleteAd;
using CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.UpdateAd;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.AdminActions.CRUD_Ads;

[ApiController]
[Authorize]
[Route("api/admin/ads")]
public class AdminAdsController : BaseController
{
    [HttpPost("append")]
    public async Task<IActionResult> AddAppend(CreateAdCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads added");
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> AddDelete(DeleteAdCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> AddUpdate(UpdateAdCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads updated");
    }
}