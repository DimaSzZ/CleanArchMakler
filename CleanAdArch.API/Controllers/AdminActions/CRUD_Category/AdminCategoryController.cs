using CleanAdArch.Application.Commands.AdminActions.CUD_Category.CreateCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_Category.DeleteCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_Category.UpdateCategory;
using CleanAdArch.Application.Queries.GetCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.AdminActions.CRUD_Category;

[ApiController]
[Authorize]
[Route("api/admin/category")]
public class AdminCategoryController: BaseController
{
    [HttpPost("append/{category}")]
    public async Task<IActionResult> CategoryAppend(string category, CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(category);
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads added");
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> CategoryDelete(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> CategoryUpdate(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Ads updated");
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> CategoryAppend(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query , cancellationToken);
        return Ok(response);
    }
}