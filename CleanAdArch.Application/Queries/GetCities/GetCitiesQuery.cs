using CleanAdArch.Domain.Models.City;
using MediatR;

namespace CleanAdArch.Application.Queries.GetCities;

public record GetCitiesQuery() : IRequest<List<City>>;