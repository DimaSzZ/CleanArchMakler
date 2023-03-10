using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryHandler(IUserAccessor userAccessor, ICategoryRepository categoryRepository)
    {
        _userAccessor = userAccessor;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCat = await _categoryRepository.OnById(request.Id, cancellationToken);
        if (isExistCat == null)
            throw new EntityExistsException();
        await _categoryRepository.Delete(request.Id,cancellationToken);
        return Unit.Value;
    }
}