using CleanAdArch.Domain.Models.Ads;
using MediatR;

namespace CleanAdArch.Application.Queries.Search;

public record SearchQuery(Guid UserId,string? Heading,Guid ?Category, Guid ?SubCategory, string ?City) : IRequest<List<AdsShort>>;