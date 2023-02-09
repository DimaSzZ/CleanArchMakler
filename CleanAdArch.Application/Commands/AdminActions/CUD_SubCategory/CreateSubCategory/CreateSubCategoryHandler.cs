using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;
using SubCategory = CleanAdArch.Domain.Models.SubCategory.SubCategory;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;

public class CreateSubCategoryHandler : IRequestHandler<CreateSubCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    public CreateSubCategoryHandler(IUserAccessor userAccessor,ISubCategoryRepository subCategoryRepository,ICategoryRepository categoryRepository )
    {
        _userAccessor = userAccessor;
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCat = await _categoryRepository.OnById(request.IdCategory, cancellationToken);
        if (isExistCat == null)
            throw new EntityExistsException();
        var isExistSub =
            await _subCategoryRepository.IsExistSubCategory(request.SubCategory, request.IdCategory, cancellationToken);
        if (isExistSub)
            throw new EntityExistsException();
        var sub = new SubCategory(request.SubCategory,request.IdCategory);
        await _subCategoryRepository.Save(sub, cancellationToken);
        return Unit.Value;
    }
}