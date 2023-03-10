using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.CreateAd;

public record CreateAdCommand(
    string City,
    string Heading,
    string? Description,
    IFormFile? File,
    string? Phone,
    double Price,
    Guid CategoryId,
    Guid? SubCategoryId,
    Guid CityId 
): IRequest;