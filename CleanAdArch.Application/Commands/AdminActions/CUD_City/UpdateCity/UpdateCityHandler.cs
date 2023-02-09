using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.UpdateCity;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICityRepository _cityRepository;
    public UpdateCityHandler(IUserAccessor userAccessor,ICityRepository cityRepository )
    {
        _userAccessor = userAccessor;
        _cityRepository = cityRepository;
    }

    public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCat = await _cityRepository.IsExistCity(request.City, cancellationToken);
        if (!isExistCat)
            throw new EntityExistsException();
        var city = await _cityRepository.OneById(request.Id, cancellationToken);
        city.CityName = request.City;
        await _cityRepository.Save(city,cancellationToken);
        return Unit.Value;
    }
}