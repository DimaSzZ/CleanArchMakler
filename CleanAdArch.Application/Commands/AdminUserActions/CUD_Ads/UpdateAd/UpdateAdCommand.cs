using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.UpdateAd;

public record UpdateAdCommand(
    Guid Id,
    string? City,
    string? Heading,
    string? Description,
    string? OldPicture,
    string? Phone,
    double Price,
    Guid CategoryId,
    Guid SubCategoryId,
    Guid CityId,
    Guid UserId,
    IFormFile File
    ) : IRequest;