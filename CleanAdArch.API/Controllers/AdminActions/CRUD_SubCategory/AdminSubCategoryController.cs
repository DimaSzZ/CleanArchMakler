using CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;
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
    public async Task<IActionResult> SubCategoryAppend(CreateSubCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Subcategory added");
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> SubCategoryDelete(CreateSubCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Subcategory deleted");
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> SubCategoryUpdate(UpdateSubCategoryCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Subcategory updated");
    }
    [AllowAnonymous]
    [HttpGet("get-all")]
    public async Task<IActionResult> SubCategoryGetAll(GetSubCategoriesQuery query, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}