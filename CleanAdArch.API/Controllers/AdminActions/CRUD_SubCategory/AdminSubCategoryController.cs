using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;
using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.UpdateSubCategory;
using CleanAdArch.Application.Queries.GetSubCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanAdArch.API.Controllers.AdminActions.CRUD_SubCategory;

[ApiController]
[Authorize]
[Route("api/admin/sub-category")]
public class AdminSubCategoryController : BaseController
{
    [HttpPost("append")]
    public async Task<IActionResult> SubCategoryAppend([FromBody]CreateSubCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Subcategory added");
    }
    
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> SubCategoryDelete(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteSubCategoryCommand(id), cancellationToken);
        return Ok("Subcategory deleted");
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> SubCategoryUpdate([FromBody]UpdateSubCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Subcategory updated");
    }
    [AllowAnonymous]
    [HttpGet("get-all/{id:guid}")]
    public async Task<IActionResult> SubCategoryGetAll(Guid id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetSubCategoriesQuery(id), cancellationToken);
        return Ok(response);
    }
}