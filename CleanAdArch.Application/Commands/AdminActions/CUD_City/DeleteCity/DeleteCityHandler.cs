using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.DeleteCity;

public class DeleteCityHandler: IRequestHandler<DeleteCityCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICityRepository _cityRepository;
    public DeleteCityHandler(IUserAccessor userAccessor, ICityRepository cityRepository)
    {
        _userAccessor = userAccessor;
        _cityRepository = cityRepository;
    }

    public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isIdExist = await _cityRepository.OneById(request.Id, cancellationToken);
        if (isIdExist == null)
            throw new EntityExistsException();
        await _cityRepository.Delete(isIdExist, cancellationToken);
        return Unit.Value;
    }
}