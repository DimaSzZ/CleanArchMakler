using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.City;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.CreateCity;

public class CreateCityHandler : IRequestHandler<CreateCityCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly ICityRepository _cityRepository;
    public CreateCityHandler(IUserAccessor userAccessor,ICityRepository cityRepository)
    {
        _userAccessor = userAccessor;
        _cityRepository = cityRepository;
    }
    public async Task<Unit> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user.Admin != true)
            throw new UserDoesNotAdminException();
        var isExistCity = await _cityRepository.IsExistCity(request.City, cancellationToken);
        if (isExistCity)
            throw new EntityExistsException();
        var newCity = new City(request.City);
        await _cityRepository.Save(newCity,cancellationToken);
        return Unit.Value;
    }
}