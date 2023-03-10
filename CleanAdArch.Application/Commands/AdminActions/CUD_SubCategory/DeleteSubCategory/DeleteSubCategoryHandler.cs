using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;

public class DeleteSubCategoryHandler : IRequestHandler<DeleteSubCategoryCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ISubCategoryRepository _subCategoryRepository;
   

    public DeleteSubCategoryHandler(IUserAccessor userAccessor, ISubCategoryRepository subCategoryRepository)
    {
        _userAccessor = userAccessor;
        _subCategoryRepository = subCategoryRepository;
    }

    public async Task<Unit> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistSub =
            await _subCategoryRepository.OnById(request.SubCategoryId,cancellationToken);
        if (isExistSub == null)
            throw new EntityExistsException();
        await _subCategoryRepository.Delete(isExistSub,cancellationToken);
        return Unit.Value;
    }
}