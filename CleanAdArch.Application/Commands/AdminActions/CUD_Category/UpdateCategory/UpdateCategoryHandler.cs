using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryHandler(IUserAccessor userAccessor,ICategoryRepository categoryRepository)
    {
        _userAccessor = userAccessor;
        _categoryRepository = categoryRepository;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var category = await _categoryRepository.OnById(request.Id, cancellationToken);
        if (category == null)
            throw new EntityExistsException();
        category.CategoryProduct = request.Category;
        await _categoryRepository.Save(category,cancellationToken);
        return Unit.Value;
    }
}