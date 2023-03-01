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
    [HttpPost("append")]
    public async Task<IActionResult> CategoryAppend(CreateCategoryCommand category, CancellationToken cancellationToken)
    {
        await Mediator.Send(category, cancellationToken);
        return Ok("Category added");
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> CategoryDelete(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Category deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> CategoryUpdate(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Category updated");
    }
    [AllowAnonymous]
    [HttpGet("get-all")]
    public async Task<IActionResult> CategoryAppend(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCategoriesQuery() , cancellationToken);
        return Ok(response);
    }
}