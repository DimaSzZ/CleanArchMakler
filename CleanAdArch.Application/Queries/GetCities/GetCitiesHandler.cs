using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.City;
using MediatR;

namespace CleanAdArch.Application.Queries.GetCities;

public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, List<City>>
{
    private readonly ICityRepository _cityRepository;

    public GetCitiesHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<City>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        return await _cityRepository.GetAll(cancellationToken);
    }
}