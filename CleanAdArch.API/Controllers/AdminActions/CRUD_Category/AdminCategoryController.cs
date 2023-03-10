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
public class 
    AdminCategoryController: BaseController
{
    [HttpPost("append")]
    public async Task<IActionResult> CategoryAppend( CreateCategoryCommand category, CancellationToken cancellationToken)
    {
        await Mediator.Send(category, cancellationToken);
        return Ok("Category added");
    }
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> CategoryDelete(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        return Ok("Category deleted");
    }
    [HttpPut("update")]
    public async Task<IActionResult> CategoryUpdate([FromBody]UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Category updated");
    }
    [AllowAnonymous]
    [HttpGet("get-all")]
    public async Task<IActionResult> CategoryGet(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCategoriesQuery() , cancellationToken);
        return Ok(response);
    }
}