using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.UpdateSubCategory;

public class UpdateSubCategoryHandler : IRequestHandler<UpdateSubCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateSubCategoryHandler(IUserAccessor userAccessor, ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository)
    {
        _userAccessor = userAccessor;
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCat = await _categoryRepository.OnById(request.categoryId, cancellationToken);
        if (isExistCat == null)
            throw new EntityExistsException();
        var isExistSub =
            await _subCategoryRepository.OnById(request.subCategoryId,cancellationToken);
        if (isExistSub == null)
            throw new EntityExistsException();
        isExistSub.SubCategoryProduct = request.NewName;
        await _subCategoryRepository.Save(isExistSub, cancellationToken);
        return Unit.Value;
    }
}