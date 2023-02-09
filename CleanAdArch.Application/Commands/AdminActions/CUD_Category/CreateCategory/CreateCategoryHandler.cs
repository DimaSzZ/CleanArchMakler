using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Utils.Logger;
using CleanAdArch.Domain.Models.Category;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(IUserAccessor userAccessor, ICategoryRepository categoryRepository)
    {
        _userAccessor = userAccessor;
        _categoryRepository = categoryRepository;
    }
    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCat = await _categoryRepository.IsExistCategory(request.Category, cancellationToken);
        if (isExistCat)
            throw new EntityExistsException("Category",$"{request.Category}");
        var category = new Category(request.Category);
        await _categoryRepository.Save(category,cancellationToken);
        return Unit.Value;
    }
}