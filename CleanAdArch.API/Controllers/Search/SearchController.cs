using CleanAdArch.Application.Queries.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.Search;
[ApiController]
[AllowAnonymous]
[Route("api/search")]
public class SearchController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Search(SearchQuery query,CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query,cancellationToken);
        return Ok(response);
    }
}